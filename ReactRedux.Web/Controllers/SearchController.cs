using ReactRedux.DAL.Entities.Catalogs;
using ReactRedux.Logic.Services;
using ReactRedux.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System;
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

            var result = query
                .OrderByDescending(p => p.Created)
                .Select(p =>
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
            IList<string> where = new List<string>();
            IList<object> parameters = new List<object>();

            var properties = criteria.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(criteria);
                if (propValue == null || string.IsNullOrWhiteSpace(propValue.ToString()))
                {
                    continue;
                }

                var attr = prop.GetCustomAttribute<InfoBlockAttribute>();
                var fieldName = $"{(attr != null ? $"{attr.BlockName}." : string.Empty)}{prop.Name}";

                if (prop.PropertyType == typeof(string) && prop.Name != nameof(PersonVm.Sex))
                {
                    where.Add($"it.{fieldName}.ToLower().Contains(@{parameters.Count})");
                    parameters.Add(propValue.ToString().ToLower());
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    where.Add($"it.{fieldName} == @{parameters.Count}");
                    parameters.Add(((DateTime)propValue).Date);
                }
                else
                {
                    where.Add($"it.{fieldName} == @{parameters.Count}");
                    parameters.Add(propValue);
                }
            }

            return (string.Join(" AND ", where), parameters.ToArray());
        }
    }
}