using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soft.Models
{
    public class products
    {
        [Key]
        public int product_Id { get; set; }

        [Required(ErrorMessage = "Please enter the product name")]
        public string product_name { get; set; }

        [DefaultValue(0)]
        public decimal product_price { get; set; }

        public int product_state { get; set; } = 0;

        public int quantity { get; set; } = 0;

        public string description { get; set; }
        
        [Display(Name="Image")]
        [DefaultValue("default.png")]
         public string product_pic { get; set; }
      
        public string Size { get; set; }


        public int category_Id { get; set; }

        [ForeignKey("category_Id")]
        [Display(Name="category")]
        public Categories? Categories { get; set; }

        public ICollection<TransactionReports>? TransactionReports { get; set; }
        public ICollection<ProductSold>? ProductSold { get; set; }
        public ICollection<productVSshoppingorder>? productVSshoppingorder { get; set; }

    }
}
