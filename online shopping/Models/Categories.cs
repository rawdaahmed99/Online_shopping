using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace soft.Models
{
    public class Categories
    {
        [Key]
        public int category_Id { get; set; }
        [Required(ErrorMessage="please enter category")]
        public string category_Name { get; set; }
        [Required(ErrorMessage = "Please enter category_type")]
        public string category_type { get; set;}

        public ICollection<products>?products { get; set; }


    }
}
