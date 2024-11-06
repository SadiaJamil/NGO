using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Project.Models.Data
{
    public class Donations
    {
        [Key]
        public int DonorId { get; set; }

        [Required(ErrorMessage ="Please enter your name")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name="Donor Name")]
        public string? DName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Donor Email")]
        public string? DEmail { get; set; }

        [Required(ErrorMessage = "Please select any donation cause")]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Donation Cause")]
        public Cause Causes { get; set; }

        [Required(ErrorMessage = "Please select your donation amount")]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Donation Amount")]
        public Amount DAmount { get; set; }

        //Transaction details
       

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter your Name")]
        [Display(Name = "Card Holder Name")]
        public string? CardHolderName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please select payment method")]
        [Display(Name = "Payment Method")]
        public PMethod PMethods { get; set; }

        [Column(TypeName = "varchar(16)")]
        [Required(ErrorMessage = "Please enter your card number")]
        [Display(Name = "Card Number")]

        public string? CardNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Please enter your card expiry date")]
        [Display(Name = "Expiration Date")]
        [NotMapped]
        public DateOnly CardExpiryDate { get; set; }

        [Column(TypeName = "varchar(4)")]
        [Required(ErrorMessage = "Please enter your card CVV")]
        [Display(Name = "Card CVV")]
        public string? CardCVV { get; set; }
    }
    public enum Cause
    {
        Children,
        Disabled,
        Education,
        Elderly,
        Employment,
        Environment,
        Health,
        Women,
        Youth
    }

    public enum Amount
    {
        Rs1000,
        Rs2500,
        Rs5000,
        Rs10000,
        Rs50000,
        Rs100000,
       
    }
    public enum PMethod
    {
        Credit_Card,
        Debit_Card
    }
}
