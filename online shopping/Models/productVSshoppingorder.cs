using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace soft.Models
{
    [PrimaryKey(nameof(product_Id), nameof(order_Id))]
    public class productVSshoppingorder
    {
        public int product_Id { get; set;}
        public int order_Id { get; set; }

        [ForeignKey("product_Id")]
        public products? Myproducts { get; set; }

        [ForeignKey("order_Id")]
        public ShoppingOrder? Myshoppingorder { get; set; }

    }
}
