using Microsoft.AspNetCore.Mvc;
using ReactRedux.DAL.Entities.Catalogs;
using ReactRedux.Logic.Services;
using ReactRedux.Web.Model;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace ReactRedux.Web.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly CatalogService _catalogService;

        public SearchController(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IEnumerable<PersonShortVm>> Get(FilterCriteria criteria)
        {
            (string where, object[] whereParams) predicate = GetPredicate(criteria);

            var query = PersonController.FakePersons.Values.AsQueryable();
            if (!string.IsNullOrWhiteSpace(predicate.where))
            {
                query = query.Where(predicate.where, predicate.whereParams);
            }

            var result = query.OrderByDescending(p => p.Created).Select(p =>
                new PersonShortVm
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MiddleName = p.MiddleName,
                    Sex = p.Sex,
                    BirthDate = p.BirthDate,
                    BirthPlace = p.BirthPlace,
                    Phone = p.Phone,
                    Email = p.Email,
                    Region = _catalogService.GetCatalogItem<Region>(p.RegionId).Result.Name,
                    EducationLevel = _catalogService.GetCatalogItem<EducationLevel>(p.EducationInfo.EducationLevelId).Result.Name,
                    University = p.EducationInfo.University,
                    CurrentCompany = p.WorkInfo.CurrentCompany,
                    CurrentPosition = p.WorkInfo.CurrentPosition,
                    Industry = _catalogService.GetCatalogItem<Industry>(p.WorkInfo.IndustryId).Result.Name,
                    ManagementExperience = _catalogService.GetCatalogItem<ManagementExperience>(p.WorkInfo.ManagementExperienceId).Result.Name,
                    ManagementLevel = _catalogService.GetCatalogItem<ManagementLevel>(p.WorkInfo.ManagementLevelId).Result.Name,
                    PhotoId = p.PhotoId,
                }
            );

            return await Task.FromResult(result);
        }

        private (string where, object[] whereParams) GetPredicate(FilterCriteria criteria)
        {
            var where = new List<string>();
            var parameters = new List<object>();

            var properties = criteria.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo prop in properties)
            {
                object propValue = prop.GetValue(criteria);
                if (string.IsNullOrWhiteSpace(propValue?.ToString()))
                {
                    continue;
                }

                int paramNum = parameters.Count;

                var blockAttr = prop.GetCustomAttribute<InfoBlockAttribute>();
                string fieldName = $"{(blockAttr != null ? $"{blockAttr.BlockName}." : string.Empty)}{prop.Name}";

                var operatorAttr = prop.GetCustomAttribute<ConditionOperatorAttribute>();
                if (operatorAttr != null)
                {
                    where.Add($"it.{fieldName} {operatorAttr.Operator} @{paramNum}");
                    parameters.Add(propValue);
                }
                else if (prop.PropertyType == typeof(string))
                {
                    where.Add($"it.{fieldName}.ToLower().Contains(@{paramNum})");
                    parameters.Add(propValue.ToString().ToLower());
                }
                else
                {
                    where.Add($"it.{fieldName} == @{paramNum}");
                    parameters.Add(propValue);
                }
            }

            return (string.Join(" AND ", where), parameters.ToArray());
        }
    }
}