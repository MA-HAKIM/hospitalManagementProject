using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement_API.Model
{
    public class DiseaseInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseID { get; set; }
        [StringLength(100)]
        public string DiseaseName { get; set; }

        public List<PatientInformation> Patients { get; set; } // Navigation property
    }
}
