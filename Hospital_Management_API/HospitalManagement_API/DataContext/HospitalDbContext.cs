using HospitalManagement_API.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement_API.DataContext
{
    public class HospitalDbContext:DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInformation>()
            .HasOne(p => p.DiseaseInformation)
            .WithMany(d => d.Patients)
            .HasForeignKey(p => p.DiseaseId);

            modelBuilder.Entity<NCD_Details>()
            .HasOne(p => p.PatientInformation)
            .WithMany(d => d.NCD_Details)
            .HasForeignKey(p => p.PatientInformationID);

            modelBuilder.Entity<Allergies_Details>()
            .HasOne(p => p.PatientInformation)
            .WithMany(d => d.Allergies_Details)
            .HasForeignKey(p => p.PatientInformationID);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<PatientInformation> PatientInformation { get; set; }
        public DbSet<Allergies_Details> AllergiesDetails { get; set; }
        public DbSet<NCD_Details> NCDDetails { get; set; }
    }
}
