using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement_API.Model
{
    public class Allergies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllergiesID { get; set; }
        [StringLength(100)]
        public string AllergiesName { get; set; }
    }
}
