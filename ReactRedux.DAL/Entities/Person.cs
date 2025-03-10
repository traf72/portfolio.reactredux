﻿using ReactRedux.DAL.Entities.Catalogs;
using ReactRedux.DAL.Enums;
using System;

namespace ReactRedux.DAL.Entities
{
    public class Person : HistoryEntity<int>
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int IdentityDocumentId { get; set; }

        public IdentityDocument IdentityDocument { get; set; }

        /// <summary>
        /// Номер документа, удостоверяющего личность
        /// </summary>
        public string IdentityDocumentNumber { get; set; }

        public string BirthPlace { get; set; }

        public DateTime BirthDate { get; set; }

        public Sex Sex { get; set; }

        public int FederalDistrictId { get; set; }

        public FederalDistrict FederalDistrict { get; set; }

        /// <summary>
        /// Идентификатор субъекта РФ
        /// </summary>
        public int RegionId { get; set; }

        public Region Region { get; set; }

        public FamilyStatus? FamilyStatus { get; set; }

        /// <summary>
        /// Информация о детях
        /// </summary>
        public string ChildrenInfo { get; set; }

        public Guid? PhotoId { get; set; }

        public int? NationalityId { get; set; }

        /// <summary>
        /// Национальность
        /// </summary>
        public Country Nationality { get; set; }

        /// <summary>
        /// Готов ли к переезду в Россию
        /// </summary>
        public bool ReadyMoveToRussia { get; set; }

        public PersonEducation PersonEducation { get; set; }

        public PersonJob PersonJob { get; set; }
    }
}