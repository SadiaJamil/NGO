using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace E_Project.Models.Data
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }

        //[Required]
        //[Column(TypeName = "varchar(50)")]
        //public string? City { get; set; }

        //[Required]
        //[Column(TypeName = "varchar(50)")]
        //public string? Country { get; set; }
    }
}
