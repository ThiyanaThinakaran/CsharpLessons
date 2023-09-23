using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace FirstMVCApp.Models
{
    public class Emp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eno { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Name must be between 3 and 20 chars")]
        public String name { set; get; }
        [Required]
        [Range(10000,50000)]
        public decimal salary { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "city must be between 3 and 20 chars")]
        public String city { set; get; }


    }
}
