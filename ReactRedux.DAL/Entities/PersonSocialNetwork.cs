using ReactRedux.DAL.Entities.Catalogs;

namespace ReactRedux.DAL.Entities
{
    public class PersonSocialNetwork : HistoryEntity<int>
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int SocialNetworkId { get; set; }

        public SocialNetwork SocialNetwork { get; set; }
    }
}