using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace soft.Models
{
    public class Deliveries
    {
        [Key]
        public int deliveries_Id { get; set; }
        [Required(ErrorMessage = "Please enter your data")]
        public string data { get; set; }

        public int Id { get; set; }
        [ForeignKey("Id")]
        public userData? userData { get; set;}

    }
}
