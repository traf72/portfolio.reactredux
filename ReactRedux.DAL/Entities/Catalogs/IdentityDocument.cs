namespace ReactRedux.DAL.Entities.Catalogs
{
    /// <summary>
    /// Документ, удостоверяющий личность
    /// </summary>
    public class IdentityDocument : CatalogItemBase
    {
        /// <summary>
        /// Формат номера
        /// http://www.consultant.ru/document/cons_doc_LAW_60879/fbbc2fbe3a4087853c1b520d26c8fd06e73cde09/
        /// </summary>
        public string NumberFormat { get; set; }

        /// <summary>
        /// Регулярное выражение, по которому будет проверяться формат номера
        /// </summary>
        public string NumberRegex { get; set; }
    }
}