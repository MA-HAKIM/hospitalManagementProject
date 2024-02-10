using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_API.Model
{
    public enum Epilepsy
    {
        Yes=1,
        No=0
    }
    public class PatientInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientInformationID { get; set; }
        [StringLength(100)]
        public string PatientName { get; set; }
        public Epilepsy Epilepsy { get; set; }    
        public int Age { get; set; }    
        public string? Address { get; set; }
        public string? ContactNo { get; set; }

        [ForeignKey("DiseaseInformation")]
        public int DiseaseId { get; set; }
        public DiseaseInformation DiseaseInformation { get; set; } // Navigation property
        public List<NCD_Details> NCD_Details { get; set; } // Navigation property
        public List<Allergies_Details> Allergies_Details { get; set; } // Navigation property

    }
}
