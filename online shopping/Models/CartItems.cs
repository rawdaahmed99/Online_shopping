using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace soft.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemsId { get; set; }

        public int product_Id { get; set; }
        public string product_name { get; set; }
        public decimal product_price { get; set; }
        public string product_pic { get; set; }
    }
}
