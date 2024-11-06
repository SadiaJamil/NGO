using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Project.Models.Data
{
    public class Partners
    {
        [Key]
        public int PartnerId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Partner Name")]
        public string? PartnerName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Partner Email")]
        public string? PartnerEmail { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required(ErrorMessage = "Please enter contact no")]
        [Display(Name = "Partner Contact")]
        public string? PartnerContact { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter partnership starting date")]
        [Display(Name = "Partnership Starting Date")]
        public DateTime PartnershipSDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter partnership end date")]
        [Display(Name = "Partnership End Date")]
        public DateTime PartnershipEDate { get; set; }

        [NotMapped]
       // [Required]
        public IFormFile? PartnerFILE { get; set; }

        [Required]
        public string? PartnerLOGO { get; set; }

    }
}
