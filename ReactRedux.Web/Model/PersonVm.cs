using System;
using System.Collections.Generic;

namespace ReactRedux.Web.Model
{
    public class PersonVm
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int FederalDistrictId { get; set; }

        public int RegionId { get; set; }

        public int DocumentId { get; set; }

        public string DocumentNumber { get; set; }

        public Guid? PhotoId { get; set; }

        public string FamilyStatus { get; set; }

        public string ChildrenInfo { get; set; }

        public int? NationalityId { get; set; }

        public bool ReadyMoveToRussia { get; set; }

        public DateTime Created { get; set; }

        public EducationInfo EducationInfo { get; set; }

        public WorkInfo WorkInfo { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }

        public IEnumerable<FileVm> Files { get; set; }
    }

    public class EducationInfo
    {
        public int EducationLevelId { get; set; }

        public string University { get; set; }

        public string Specialty { get; set; }

        public int? GraduationYear { get; set; }

        public string EducationExtraInfo { get; set; }
    }

    public class WorkInfo
    {
        public string CurrentCompany { get; set; }

        public string CurrentPosition { get; set; }

        public int IndustryId { get; set; }

        public int WorkAreaId { get; set; }

        public int ManagementLevelId { get; set; }

        public int ManagementExperienceId { get; set; }

        public int EmployeesNumberId { get; set; }

        public int? HireYear { get; set; }

        public string PreviousWorkPlaces { get; set; }
    }

    public class Language
    {
        public int LanguageId { get; set; }

        public int LanguageLevelId { get; set; }
    }

    public class SocialNetwork
    {
        public int NetworkId { get; set; }

        public string Value { get; set; }
    }
}