using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Project.Models.Data
{
    public class Programmes
    {
        [Key]
        public int ProgrammeID { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter programme Name")]
        [Display(Name = "Programme Name")]
        public string? ProgrammeName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter programme starting date")]
        [Display(Name = "Programme Starting Date")]
        public DateTime ProgStartDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter programme end date")]
        [Display(Name = "Programme Ending Date")]
        public DateTime ProgEndDate { get; set; }
        [NotMapped]
        [Required]
        public IFormFile? ProgrammeFile { get; set; }

        [Required]
        public string? ProgrammeIMG { get; set; }
    }
}
