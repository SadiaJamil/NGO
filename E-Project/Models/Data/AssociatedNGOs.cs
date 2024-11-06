using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Project.Models.Data
{
    public class AssociatedNGOs
    {
        [Key]
        public int NGOId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter NGO Name")]
        [Display(Name = "NGO Name")]
        public string? NGOName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter NGO email")]
        [Display(Name = "NGO Email")]
        public string? NGOEmail { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter NGO contact")]
        [Display(Name = "NGO Contact")]
        public string? NGOContact { get; set; }
    }
}
