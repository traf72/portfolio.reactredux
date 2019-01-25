using ReactRedux.DAL.Entities.Catalogs;
using ReactRedux.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRedux.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogService _catalogService;

        public CatalogController(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IEnumerable<FederalDistrict>> FederalDistricts()
        {
            return await _catalogService.GetCatalog<FederalDistrict>();
        }

        [HttpGet]
        public async Task<IEnumerable<IdentityDocument>> IdentityDocuments()
        {
            return await _catalogService.GetCatalog<IdentityDocument>();
        }

        [HttpGet]
        public async Task<IEnumerable<EducationLevel>> EducationalLevels()
        {
            return await _catalogService.GetCatalog<EducationLevel>();
        }

        [HttpGet]
        public async Task<IEnumerable<Industry>> Industries()
        {
            return await _catalogService.GetCatalog<Industry>();
        }

        [HttpGet]
        public async Task<IEnumerable<WorkArea>> WorkAreas()
        {
            return await _catalogService.GetCatalog<WorkArea>();
        }

        [HttpGet]
        public async Task<IEnumerable<ManagementLevel>> ManagementLevels()
        {
            return await _catalogService.GetCatalog<ManagementLevel>();
        }

        [HttpGet]
        public async Task<IEnumerable<ManagementExperience>> ManagementExperiences()
        {
            return await _catalogService.GetCatalog<ManagementExperience>();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeesNumber>> EmployeesNumbers()
        {
            return await _catalogService.GetCatalog<EmployeesNumber>();
        }

        [HttpGet]
        public async Task<IEnumerable<Language>> Languages()
        {
            return (await _catalogService.GetCatalog<Language>())
                .OrderByDescending(x => x.Weight)
                .ThenBy(x => x.Name);
        }

        [HttpGet]
        public async Task<IEnumerable<LanguageLevel>> LanguageLevels()
        {
            return await _catalogService.GetCatalog<LanguageLevel>();
        }

        [HttpGet]
        public async Task<IEnumerable<SocialNetwork>> SocialNetworks()
        {
            return await _catalogService.GetCatalog<SocialNetwork>();
        }

        [HttpGet]
        public async Task<IEnumerable<object>> Countries()
        {
            return (await _catalogService.GetCatalog<Country>()).Select(x => new
            {
                x.Id,
                x.Code,
                x.Name,
            });
        }

        [HttpGet]
        public async Task<IEnumerable<object>> Regions()
        {
            //return await _catalogService.GetCatalog<Reg>();
            return null;
        }
    }
}