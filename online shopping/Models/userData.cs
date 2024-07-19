using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soft.Models
{
    public class userData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required ]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="Passwords not matchs")]
        public string ConfirmPassword { get; set; }

        public string Phone { get; set; } = string.Empty;
    
        public string Address { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public ICollection<Deliveries>? Deliveries { get; set; }
        public ICollection<TransactionReports>? TransactionReports { get; set; }
        public ICollection<ShoppingOrder>?ShoppingOrders { get; set; }
        public ICollection<ProductSold>? ProductSold { get; set; }
        public ICollection<Carts>? MyCarts { get; set; }

    }
}








