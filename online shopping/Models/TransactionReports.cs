using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace soft.Models
{
    public class TransactionReports
    {
        [Key]
        public int Report_Id { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public userData? userData { get; set; }


        public int order_Id { get; set; }
        [ForeignKey("order_Id")]
        public ShoppingOrder? ShoppingOrder { get; set; }
        public int product_Id { get; set; }
        [ForeignKey("product_Id")]
        public products? Products { get; set; }
        public int payment_Id { get; set; }
        [ForeignKey("payment_Id")]
        public Payment? Payment { get; set; }

    }
}
