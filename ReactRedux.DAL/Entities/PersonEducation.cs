using ReactRedux.DAL.Entities.Catalogs;

namespace ReactRedux.DAL.Entities
{
    public class PersonEducation : HistoryEntity<int>
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int EducationLevelId { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public string University { get; set; }

        public string Specialty { get; set; }

        public int? GraduationYear { get; set; }

        public string ExtraInfo { get; set; }
    }
}