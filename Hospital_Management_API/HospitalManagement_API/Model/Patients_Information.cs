using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_API.Model
{
    public enum Epilepsy
    {
        Yes = 1,
        No = 0
    }
    public class Patients_Information
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        [StringLength(100)]
        public string PatientName { get; set; }
        public Epilepsy Epilepsy { get; set; }    
        public int Age { get; set; }    
        public string? Address { get; set; }
        public string? ContactNo { get; set; }

        [ForeignKey("DiseaseInformation")]
        public int DiseaseId { get; set; }
        
        //Navigation Properties

        public DiseaseInformation DiseaseInformation { get; set; }
        public ICollection<Allergies_Details> AllergiesDetails { get; set; }
        public ICollection<NCD_Details> NCDDetails { get; set; }

    }
}
