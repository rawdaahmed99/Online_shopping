using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soft.Models
{
    public class ShoppingOrder
    {
        [Key]
        public int order_Id { get; set; }
        [Required(ErrorMessage = "Please enter your data")]
        public string data { get; set; }
        
        public int Id { get; set; }
        [ForeignKey("Id")]
        public userData? userData { get; set; }
        public ICollection<TransactionReports>? TransactionReports { get; set; }
        public ICollection<productVSshoppingorder>? productVSshoppingorder { get; set; }
    }
}
