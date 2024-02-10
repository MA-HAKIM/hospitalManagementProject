using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagement_API.Model
{
    public class NCD_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("PatientInformation")]
        public int PatientInformationID { get; set; }
        [AllowNull]
        public int NCDID { get; set; }
        public PatientInformation PatientInformation { get; set; } // Navigation property
    }
}
