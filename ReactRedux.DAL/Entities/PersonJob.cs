using ReactRedux.DAL.Entities.Catalogs;

namespace ReactRedux.DAL.Entities
{
    public class PersonJob : HistoryEntity<int>
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public int IndustryId { get; set; }

        public Industry Industry { get; set; }

        public int WorkAreaId { get; set; }

        public WorkArea WorkArea { get; set; }

        public int ManagementLevelId { get; set; }

        public ManagementLevel ManagementLevel { get; set; }

        public int ManagementExperienceId { get; set; }

        public ManagementExperience ManagementExperience { get; set; }

        public int EmployeesNumberId { get; set; }

        public EmployeesNumber EmployeesNumber { get; set; }

        public int? HireYear { get; set; }

        public string PreviousJobs { get; set; }
    }
}