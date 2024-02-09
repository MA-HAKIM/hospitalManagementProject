using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagement_API.Model
{
    public class Allergies_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("PatientInformation")]
        public int PatientID { get; set; }
        [AllowNull]
        public int AllergiesID { get; set; }

        //Navigation Properties

        public Patients_Information PatientsInformation { get; set; }
    }
}
