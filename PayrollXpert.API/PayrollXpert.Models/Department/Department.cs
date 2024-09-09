using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PayrollXpert.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Department Name")]

        public string Name { get; set; }
    }
}
