using ReactRedux.DAL.Entities.Catalogs;

namespace ReactRedux.DAL.Entities
{
    public class PersonLanguage : HistoryEntity<int>
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public int LanguageLevelId { get; set; }

        public LanguageLevel LanguageLevel { get; set; }
    }
}