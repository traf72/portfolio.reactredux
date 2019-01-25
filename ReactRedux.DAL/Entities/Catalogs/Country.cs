namespace ReactRedux.DAL.Entities.Catalogs
{
    public class Country : CatalogItemBase
    {
        public string FullName { get; set; }

        public string AlphaCode2 { get; set; }

        public string AlphaCode3 { get; set; }
    }
}