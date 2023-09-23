using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace FirstMVCApp.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int mID { set; get; }
        [Required]
        [StringLength(30)]
        [MinLength(3, ErrorMessage = "Title must be between 3 and 30 chars")]
        public String title { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Language must be between 3 and 20 chars")]
        public String language { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Hero must be between 3 and 20 chars")]
        public String Hero { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "Director must be between 3 and 20 chars")]
        public String Director { set; get; }
        [Required]
        [StringLength(20)]
        [MinLength(3, ErrorMessage = "MusicDirector must be between 3 and 20 chars")]
        public String MusicDirector { set; get; }
        [Required]
        public DateTime ReleaseDate { set; get; }
        [Required]
        public decimal cost { set; get; }
        [Required]
        public int collection { set; get; }
        [Required]
        public int review { set; get; }
    }
}
