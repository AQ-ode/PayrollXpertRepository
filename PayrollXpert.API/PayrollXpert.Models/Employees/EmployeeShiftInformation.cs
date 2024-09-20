using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PayrollXpert.API.Api_Models.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PayrollXpert.Models.Employees
{
    public class EmployeeShiftInformation
    {
        [Key]
        public int ShiftInformationId { get; set; }
        [Required(ErrorMessage = "Shift Name is required.")]
        [StringLength(50, ErrorMessage = "Shift Name cannot exceed 50 characters.")]
        public string ShiftName { get; set; }

        [Required(ErrorMessage = "Start Time is required.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required.")]
        public TimeSpan EndTime { get; set; }

        [ForeignKey("EmployeeId")]
        [JsonIgnore]
        [ValidateNever]
        public Employee Employee { get; set; }

    }
}
