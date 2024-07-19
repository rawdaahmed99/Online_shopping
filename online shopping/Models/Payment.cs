using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soft.Models
{
    public class Payment
    {
        [Key]
        public int payment_Id { get; set; }
        [Required(ErrorMessage = "Please enter your data")]
        public string data { get; set; }
        //add
        [ForeignKey("order_Id")]
        public ShoppingOrder? MyshoppingOrder { get; set; }
       


        [Required]
        public double totalprice { get; set; }

        public ICollection<TransactionReports>? TransactionReports { get; set; }
    }


}

