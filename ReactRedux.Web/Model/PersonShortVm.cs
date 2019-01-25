using System;

namespace ReactRedux.Web.Model
{
    public class PersonShortVm
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

        /// <summary>
        /// Субъект РФ
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Населённый пункт
        /// </summary>
        public string Locality { get; set; }

        public string EducationLevel { get; set; }

        public string University { get; set; }

        public string CurrentCompany { get; set; }

        public string CurrentPosition { get; set; }

        public string Industry { get; set; }

        public string ManagementLevel { get; set; }

        public string ManagementExperience { get; set; }

        public Guid? PhotoId { get; set; }
    }
}