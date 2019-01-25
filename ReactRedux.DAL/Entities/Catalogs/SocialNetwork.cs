using ReactRedux.DAL.Enums;

namespace ReactRedux.DAL.Entities.Catalogs
{
    /// <summary>
    /// Социальная сеть или мессенджер
    /// </summary>
    public class SocialNetwork : CatalogItemBase
    {
        public string Icon { get; set; }

        public string IconColor { get; set; }

        public SocialNetworkType Type { get; set; }
    }
}