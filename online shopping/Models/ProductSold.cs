using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace soft.Models
{
    [PrimaryKey(nameof(product_Id), nameof(Id))]
    public class ProductSold
    {
        [Key]
        public int productsold_Id { get; set; }
        public int product_Id { get; set; }
        [ForeignKey("product_Id")]
        public products ?products { get; set; }


        public int Id { get; set; }
        [ForeignKey("Id")]
        public userData? userData { get; set; }

    }
}
