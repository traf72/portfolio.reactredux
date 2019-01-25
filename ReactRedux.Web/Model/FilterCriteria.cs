using System;

namespace ReactRedux.Web.Model
{
    public class FilterCriteria
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }


        public string Sex { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FederalDistrictId { get; set; }

        public Guid? RegionId { get; set; }

        public Guid? LocalityId { get; set; }

        public int? DocumentId { get; set; }

        public string DocumentNumber { get; set; }

        [InfoBlock(nameof(PersonVm.EducationInfo))]
        public int? EducationLevelId { get; set; }

        [InfoBlock(nameof(PersonVm.EducationInfo))]
        public string University { get; set; }

        [InfoBlock(nameof(PersonVm.EducationInfo))]
        public string Specialty { get; set; }

        [InfoBlock(nameof(PersonVm.EducationInfo))]
        public int? GraduationYear { get; set; }

        [InfoBlock(nameof(PersonVm.EducationInfo))]
        public string EducationExtraInfo { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public string CurrentCompany { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public string CurrentPosition { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public int? IndustryId { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public int? WorkAreaId { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public int? ManagementLevelId { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public int? ManagementExperienceId { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public int? EmployeesNumberId { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public int? HireYear { get; set; }

        [InfoBlock(nameof(PersonVm.WorkInfo))]
        public string PreviousWorkPlaces { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class InfoBlockAttribute : Attribute
    {
        public string BlockName { get; set; }

        public InfoBlockAttribute(string blockName)
        {
            BlockName = blockName;
        }
    }
}