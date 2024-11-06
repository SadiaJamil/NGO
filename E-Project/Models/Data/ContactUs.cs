using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Project.Models.Data
{
    public class ContactUs
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name")]
        public string? CName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Email")]
        public string? CEmail { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Message")]
        public string? CMessage { get; set; }
    }
}
