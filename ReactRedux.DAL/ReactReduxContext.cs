using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactRedux.Common.Extensions;
using ReactRedux.DAL.Entities;
using ReactRedux.DAL.Entities.Catalogs;
using ReactRedux.DAL.Enums;
using System;
using System.Linq;

namespace ReactRedux.DAL
{
    public class ReactReduxContext : DbContext
    {
        public ReactReduxContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<FederalDistrict> FederalDistricts { get; set; }
        public DbSet<IdentityDocument> IdentityDocuments { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<WorkArea> WorkAreas { get; set; }
        public DbSet<ManagementLevel> ManagementLevels { get; set; }
        public DbSet<ManagementExperience> ManagementExperiences { get; set; }
        public DbSet<EmployeesNumber> EmployeesNumbers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitHistoryFields(modelBuilder);
            InitCatalogs(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MiddleName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Sex).HasConversion(new EnumToStringConverter<Sex>()).HasMaxLength(20);
                entity.Property(e => e.BirthDate).HasColumnType("Date");
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(100).IsRequired();
                entity.Property(e => e.IdentityDocumentNumber).HasMaxLength(50).IsRequired();
                entity.Property(e => e.BirthPlace).HasMaxLength(200).IsRequired();
                entity.Property(e => e.FamilyStatus).HasConversion(new EnumToStringConverter<FamilyStatus>()).HasMaxLength(50);
                entity.Property(e => e.ChildrenInfo).HasMaxLength(100);
            });

            modelBuilder.Entity<IdentityDocument>(entity =>
            {
                entity.Property(e => e.NumberFormat).HasMaxLength(50).IsRequired();
                entity.Property(e => e.NumberRegex).HasMaxLength(100);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Weight).HasDefaultValue(0);
            });

            modelBuilder.Entity<SocialNetwork>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(50);
                entity.Property(e => e.IconColor).HasMaxLength(50);
                entity.Property(e => e.Type).HasConversion(new EnumToStringConverter<SocialNetworkType>()).HasMaxLength(30);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(500);
                entity.Property(e => e.AlphaCode2).HasColumnType("nchar(2)").IsRequired();
                entity.Property(e => e.AlphaCode3).HasColumnType("nchar(3)").IsRequired();
            });

            modelBuilder.Entity<PersonJob>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(250).IsRequired();
                entity.Property(e => e.Position).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PreviousJobs).HasMaxLength(4000);
            });

            modelBuilder.Entity<PersonEducation>(entity =>
            {
                entity.Property(e => e.University).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Specialty).HasMaxLength(200).IsRequired();
                entity.Property(e => e.ExtraInfo).HasMaxLength(4000);
            });

            modelBuilder.Entity<FederalDistrict>().HasData(ReactReduxSeed.GetSeedData<FederalDistrict>());
            modelBuilder.Entity<IdentityDocument>().HasData(ReactReduxSeed.GetSeedData<IdentityDocument>());
            modelBuilder.Entity<EducationLevel>().HasData(ReactReduxSeed.GetSeedData<EducationLevel>());
            modelBuilder.Entity<Industry>().HasData(ReactReduxSeed.GetSeedData<Industry>());
            modelBuilder.Entity<WorkArea>().HasData(ReactReduxSeed.GetSeedData<WorkArea>());
            modelBuilder.Entity<ManagementLevel>().HasData(ReactReduxSeed.GetSeedData<ManagementLevel>());
            modelBuilder.Entity<ManagementExperience>().HasData(ReactReduxSeed.GetSeedData<ManagementExperience>());
            modelBuilder.Entity<EmployeesNumber>().HasData(ReactReduxSeed.GetSeedData<EmployeesNumber>());
            modelBuilder.Entity<Language>().HasData(ReactReduxSeed.GetSeedData<Language>());
            modelBuilder.Entity<LanguageLevel>().HasData(ReactReduxSeed.GetSeedData<LanguageLevel>());
            modelBuilder.Entity<SocialNetwork>().HasData(ReactReduxSeed.GetSeedData<SocialNetwork>());
            modelBuilder.Entity<Country>().HasData(ReactReduxSeed.GetSeedData<Country>());

            base.OnModelCreating(modelBuilder);
        }

        private void InitHistoryFields(ModelBuilder modelBuilder)
        {
            var historicalEntities = GetType().Assembly.GetTypes()
                .Where(t => t.Namespace != null
                            && t.Namespace.StartsWith("ReactRedux.DAL.Entities")
                            && !t.IsAbstract
                            && t.IsSubclassOfRawGeneric(typeof(HistoryEntity<>)));

            foreach (Type entity in historicalEntities)
            {
                modelBuilder.Entity(entity, e =>
                {
                    e.Property(nameof(IHistoryEntity<object>.Created)).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
                    e.Property(nameof(IHistoryEntity<object>.Author)).IsRequired().HasMaxLength(100);
                    e.Property(nameof(IHistoryEntity<object>.Modifier)).HasMaxLength(100);
                });
            }
        }

        public void InitCatalogs(ModelBuilder modelBuilder)
        {
            var catalogs = GetType().Assembly.GetTypes()
                .Where(t => t.Namespace != null
                            && t.Namespace.StartsWith("ReactRedux.DAL.Entities.Catalogs")
                            && !t.IsAbstract
                            && t.IsSubclassOf(typeof(CatalogItemBase)));

            foreach (Type catalog in catalogs)
            {
                modelBuilder.Entity(catalog, e =>
                {
                    e.Property(nameof(CatalogItemBase.Code)).HasMaxLength(50).IsRequired();
                    e.Property(nameof(CatalogItemBase.Name)).HasMaxLength(400).IsRequired();
                    e.HasIndex(nameof(CatalogItemBase.Code)).IsUnique().HasName($"UX_{catalog.Name}_{nameof(CatalogItemBase.Code)}");
                });
            }
        }
    }
}