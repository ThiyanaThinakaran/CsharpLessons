using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { set; get; }
        [StringLength(25, ErrorMessage = "Author Name must not have more than 25 chars")]
        [MinLength(3, ErrorMessage = "Author Name must have at least 3 chars")]
        [Required(ErrorMessage = "Author Name is Required")]
        public String AuthorName { set; get; }
     
        public String DateOfBirth { set; get; }
        public int BookPublished {set; get; }

        [StringLength(25, ErrorMessage = "Royality company must not have more than 25 chars")]
        [MinLength(3, ErrorMessage = "Royality company must have at least 3 chars")]
        [Required(ErrorMessage = "Royality company is Required")]
        public String RoyalityCompany { set; get; }
       
    }
}