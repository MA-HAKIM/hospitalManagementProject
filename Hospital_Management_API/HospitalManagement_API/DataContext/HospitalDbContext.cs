using HospitalManagement_API.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement_API.DataContext
{
    public class HospitalDbContext:DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Patients_Information> PatientInformation { get; set; }
        public DbSet<Allergies_Details> AllergiesDetails { get; set; }
        public DbSet<NCD_Details> NCDDetails { get; set; }
    }
}
