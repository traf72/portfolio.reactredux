namespace ReactRedux.DAL.Entities.Catalogs
{
    public class Language : CatalogItemBase
    {
        /// <summary>
        /// Вес языка (для сортировки по релевантности)
        /// </summary>
        public int Weight { get; set; }
    }
}