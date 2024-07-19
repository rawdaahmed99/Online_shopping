using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace soft.Models
{
    public class Carts
    {
        [Key]
        public int CartsId { get; set; }

        public int Id { get; set; }
        [ForeignKey("Id")]
        public userData? userData { get; set; }

        public List<CartItems> Items { get; set; }

    }
}
