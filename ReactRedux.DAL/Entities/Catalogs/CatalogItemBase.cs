namespace ReactRedux.DAL.Entities.Catalogs
{
    public abstract class CatalogItemBase : HistoryEntity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}