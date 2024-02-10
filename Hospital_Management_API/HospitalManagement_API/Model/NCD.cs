using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement_API.Model
{
    public class NCD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCDID { get; set; }
        [StringLength(100)]
        public string NCDName { get; set; }

    }
}
