using System;

namespace ReactRedux.Web.Model
{
    public class FilterCriteria
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [ConditionOperator(Operators.Equal)]
        public string Sex { get; set; }

        [ConditionFieldAttribute(nameof(PersonVm.Age))]
        [ConditionOperator(Operators.GraterOrEqual)]
        public int? StartAge { get; set; }

        [ConditionFieldAttribute(nameof(PersonVm.Age))]
        [ConditionOperator(Operators.LessOrEqual)]
        public int? EndAge { get; set; }

        public string BirthPlace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FederalDistrictId { get; set; }

        public int? RegionId { get; set; }

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
        public InfoBlockAttribute(string blockName)
        {
            BlockName = blockName;
        }

        public string BlockName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ConditionFieldAttribute : Attribute
    {
        public ConditionFieldAttribute(string field)
        {
            Field = field;
        }

        public string Field { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ConditionOperatorAttribute : Attribute
    {
        public ConditionOperatorAttribute(string opeartor)
        {
            Operator = opeartor;
        }

        public string Operator { get; set; }
    }

    public class Operators
    {
        public const string Equal = "==";
        public const string NotEqual = "!=";
        public const string GraterThan = ">";
        public const string GraterOrEqual = ">=";
        public const string LessThan = "<";
        public const string LessOrEqual = "<=";
    }
}