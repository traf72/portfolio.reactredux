using ReactRedux.DAL.Enums;
using ReactRedux.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRedux.Web.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public async Task<PersonVm> CreateOrEdit(PersonVm person)
        {
            if (person.Id == 0)
            {
                person.Id = FakePersons.Keys.Max() + 1;
                person.Created = DateTime.Now;
                FakePersons[person.Id] = person;
                return await Task.FromResult(person);
            }

            FakePersons[person.Id] = person;
            return await Task.FromResult(person);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonVm>> Get(int id)
        {
            if (FakePersons.TryGetValue(id, out var person))
            {
                return await Task.FromResult(person);
            }

            return NotFound();
        }

        public static readonly IDictionary<int, PersonVm> FakePersons = new Dictionary<int, PersonVm>
        {
            [1] = new PersonVm
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Sex = Sex.Male.ToString(),
                BirthDate = new DateTime(1967, 10, 23),
                BirthPlace = "г. Рязань",
                Email = "ivanov1967@mail.ru",
                Phone = "+7 (925) 785-23-54",
                FederalDistrictId = 1,
                RegionId = 62,
                DocumentId = 1,
                DocumentNumber = "6110 343534",
                PhotoId = Guid.Parse("0cb0e841-c29e-4dcd-90fd-879aa7bd51d3"),
                FamilyStatus = FamilyStatus.Married.ToString(),
                ChildrenInfo = "2",
                NationalityId = 14,
                ReadyMoveToRussia = true,
                Created = new DateTime(2018, 12, 10),
                EducationInfo = new EducationInfo
                {
                    EducationLevelId = 4,
                    University = "Рязанский государственный радиотехнический университет",
                    Specialty = "Прикладная математика в экономике",
                    GraduationYear = 1990,
                    EducationExtraInfo = "Имеется второе высшее экономическое образование",
                },
                WorkInfo = new WorkInfo
                {
                    CurrentCompany = "ООО \"Ромашка\"",
                    CurrentPosition = "Руководитель отдела",
                    IndustryId = 6,
                    WorkAreaId = 7,
                    ManagementLevelId = 4,
                    ManagementExperienceId = 4,
                    EmployeesNumberId = 4,
                    HireYear = 2005,
                    PreviousWorkPlaces = "ООО \"Радуга\" (1997-2001), ООО \"Карусель\" (2001-2005)",
                },
                Languages = new[]
                {
                    new Language
                    {
                        LanguageId = 30,
                        LanguageLevelId = 5,
                    },
                    new Language
                    {
                        LanguageId = 79,
                        LanguageLevelId = 4,
                    }
                },
                SocialNetworks = new[]
                {
                    new SocialNetwork
                    {
                        NetworkId = 1,
                        Value = "https://facebook.com/ivanov",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 2,
                        Value = "vk.com/ivanov",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 6,
                        Value = "ivanov1971",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 7,
                        Value = "79452346523",
                    },
                },
                Files = new[]
                    {
                        new FileVm
                        {
                            Id = Guid.Parse("5a5f17da-ab10-4759-8b65-70524174ef08"),
                            Name = "Презентация.pptx",
                            MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                            Size = 4495285,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("f7a6accb-7b69-4297-8364-5066d5e48ec8"),
                            Name = "Screen.png",
                            MimeType = "image/png",
                            Size = 247146,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("3eda113f-2e37-4e5a-8430-47184e2b1632"),
                            Name = "Текстовый файл.txt",
                            MimeType = "text/plain",
                            Size = 1006,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("42c5297e-0565-47b1-9c45-798727a6e14a"),
                            Name = "Excel документ.xlsx",
                            MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            Size = 14010,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("4c137722-4b52-42ba-8d54-b2c62d1faff5"),
                            Name = "Music.mp3",
                            MimeType = "audio/mpeg",
                            Size = 9034314,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("9c21861c-77df-44e6-ab17-4fd624b7bb1c"),
                            Name = "Word документ.docx",
                            MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                            Size = 38262,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("5d2f364d-9940-4193-981d-057ecb0a4b8e"),
                            Name = "Csv документ.csv",
                            MimeType = "text/csv",
                            Size = 3446,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("0c5001bc-eaaf-47a0-b7fe-5aced6ba28a8"),
                            Name = "Pdf документ.pdf",
                            MimeType = "application/pdf",
                            Size = 13969748,
                        },
                },
            },
            [2] = new PersonVm
            {
                Id = 2,
                LastName = "Суркова",
                FirstName = "Наталья",
                MiddleName = "Алексеевна",
                Sex = Sex.Female.ToString(),
                BirthDate = new DateTime(1982, 1, 15),
                BirthPlace = "г. Москва",
                Email = "surkova@mail.ru",
                Phone = "+7 (921) 533-23-54",
                FederalDistrictId = 1,
                RegionId = 77,
                DocumentId = 1,
                DocumentNumber = "6254 645746",
                Created = new DateTime(2018, 12, 23),
                EducationInfo = new EducationInfo
                {
                    EducationLevelId = 4,
                    University = "Московский государственный университет имени М.В. Ломоносова",
                    Specialty = "Финансы, денежное обращение и кредит",
                },
                WorkInfo = new WorkInfo
                {
                    CurrentCompany = "ООО \"Импульс\"",
                    CurrentPosition = "Руководитель подразделения",
                    IndustryId = 44,
                    WorkAreaId = 21,
                    ManagementLevelId = 3,
                    ManagementExperienceId = 3,
                    EmployeesNumberId = 3,
                },
                SocialNetworks = new[]
                {
                    new SocialNetwork
                    {
                        NetworkId = 3,
                        Value = "ok.ru/surkova",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 7,
                        Value = "76547893456",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 8,
                        Value = "surkova82",
                    },
                },
            },
            [3] = new PersonVm
            {
                Id = 3,
                LastName = "Васин",
                FirstName = "Павел",
                MiddleName = "Эдуардович",
                Sex = Sex.Male.ToString(),
                BirthDate = new DateTime(1981, 3, 2),
                BirthPlace = "г. Новосибирск",
                Email = "vasin@yandex.ru",
                Phone = "+7 (765) 134-55-55",
                FederalDistrictId = 7,
                RegionId = 54,
                DocumentId = 2,
                DocumentNumber = "61 3435347",
                PhotoId = Guid.Parse("85b887d7-b04d-46f3-8b86-8edf55f88624"),
                FamilyStatus = FamilyStatus.NotMarried.ToString(),
                Created = new DateTime(2019, 1, 12),
                EducationInfo = new EducationInfo
                {
                    EducationLevelId = 4,
                    University = "Новосибирский национальный исследовательский государственный университет",
                    Specialty = "Математика и компьютерные науки",
                    GraduationYear = 1998,
                },
                WorkInfo = new WorkInfo
                {
                    CurrentCompany = "ООО \"Развитие\"",
                    CurrentPosition = "Генеральный директор",
                    IndustryId = 13,
                    WorkAreaId = 4,
                    ManagementLevelId = 1,
                    ManagementExperienceId = 3,
                    EmployeesNumberId = 4,
                    HireYear = 2008,
                },
                Languages = new[]
                {
                    new Language
                    {
                        LanguageId = 4,
                        LanguageLevelId = 5,
                    },
                },
                SocialNetworks = new[]
                {
                    new SocialNetwork
                    {
                        NetworkId = 2,
                        Value = "vk.com/vasin",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 3,
                        Value = "ok.com/vasin1981",
                    },
                },
                Files = new[]
                    {
                        new FileVm
                        {
                            Id = Guid.Parse("5a5f17da-ab10-4759-8b65-70524174ef08"),
                            Name = "Презентация.pptx",
                            MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                            Size = 4495285,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("42c5297e-0565-47b1-9c45-798727a6e14a"),
                            Name = "Excel документ.xlsx",
                            MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            Size = 14010,
                        },
                },
            },
            [4] = new PersonVm
            {
                Id = 4,
                LastName = "Самойлова",
                FirstName = "Галина",
                MiddleName = "Александровна",
                Sex = Sex.Female.ToString(),
                BirthDate = new DateTime(1977, 3, 2),
                BirthPlace = "г. Екатеринбург",
                Email = "samoylova@gmail.com",
                Phone = "+7 (543) 453-78-28",
                FederalDistrictId = 3,
                RegionId = 61,
                DocumentId = 1,
                DocumentNumber = "6234 764982",
                PhotoId = Guid.Parse("746aede8-7256-41a3-943a-08556dde496b"),
                Created = new DateTime(2019, 1, 14),
                EducationInfo = new EducationInfo
                {
                    EducationLevelId = 3,
                    University = "Институт международных связей",
                    Specialty = "Менеджмент",
                    GraduationYear = 1994,
                },
                WorkInfo = new WorkInfo
                {
                    CurrentCompany = "АО \"Эксперт\"",
                    CurrentPosition = "Директор по развитию",
                    IndustryId = 24,
                    WorkAreaId = 10,
                    ManagementLevelId = 4,
                    ManagementExperienceId = 2,
                    EmployeesNumberId = 2,
                    HireYear = 2011,
                },
                SocialNetworks = new[]
                {
                    new SocialNetwork
                    {
                        NetworkId = 3,
                        Value = "ok.com/samoylova",
                    },
                    new SocialNetwork
                    {
                        NetworkId = 8,
                        Value = "samoylova1977",
                    },
                },
                Files = new[]
                    {
                        new FileVm
                        {
                            Id = Guid.Parse("5a5f17da-ab10-4759-8b65-70524174ef08"),
                            Name = "Презентация.pptx",
                            MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                            Size = 4495285,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("42c5297e-0565-47b1-9c45-798727a6e14a"),
                            Name = "Excel документ.xlsx",
                            MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            Size = 14010,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("9c21861c-77df-44e6-ab17-4fd624b7bb1c"),
                            Name = "Word документ.docx",
                            MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                            Size = 38262,
                        },
                        new FileVm
                        {
                            Id = Guid.Parse("0c5001bc-eaaf-47a0-b7fe-5aced6ba28a8"),
                            Name = "Pdf документ.pdf",
                            MimeType = "application/pdf",
                            Size = 13969748,
                        },
                },
            },
        };
    }
}