namespace ReactRedux.DAL.Entities.Catalogs
{
    /// <summary>
    /// Субъект РФ
    /// </summary>
    public class Region : CatalogItemBase
    {
        public int FederalDistrictId { get; set; }

        public FederalDistrict FederalDistrict { get; set; }
    }
}