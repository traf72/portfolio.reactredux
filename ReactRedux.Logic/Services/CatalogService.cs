using ReactRedux.DAL;
using ReactRedux.DAL.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactRedux.DAL;

namespace ReactRedux.Logic.Services
{
    public class CatalogService
    {
        private readonly ReactReduxContext _dbContext;
        private readonly IMemoryCache _cache;

        public CatalogService(ReactReduxContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<IList<TCatalogItem>> GetCatalog<TCatalogItem>() where TCatalogItem : CatalogItemBase
        {
            IList<TCatalogItem> cachedResult = GetFromCache<TCatalogItem>();
            if (cachedResult != null)
            {
                return cachedResult;
            }

            var result = await _dbContext.Set<TCatalogItem>().AsNoTracking().ToListAsync();
            PutToCache(result);
            return result;
        }

        public async Task<TCatalogItem> GetCatalogItem<TCatalogItem>(int id) where TCatalogItem : CatalogItemBase
        {
            return (await GetCatalog<TCatalogItem>()).SingleOrDefault(x => x.Id == id);
        }

        private IList<TCatalogItem> GetFromCache<TCatalogItem>() where TCatalogItem : CatalogItemBase
        {
            return _cache.Get<IList<TCatalogItem>>(GetCacheKey<TCatalogItem>());
        }

        private void PutToCache<TCatalogItem>(IList<TCatalogItem> data) where TCatalogItem : CatalogItemBase
        {
            _cache.Set(GetCacheKey<TCatalogItem>(), data);
        }

        private string GetCacheKey<TCatalogItem>() where TCatalogItem : CatalogItemBase
        {
            return $"Catalog_{typeof(TCatalogItem).Name}";
        }
    }
}