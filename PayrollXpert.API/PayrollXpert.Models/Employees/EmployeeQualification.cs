using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PayrollXpert.API.Api_Models.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PayrollXpert.Models.Employees
{
    public class EmployeeQualification
    {
        [Key]
        public int QualificationId { get; set; }

        [Required(ErrorMessage = "Qualification Type is required.")]
        [StringLength(50, ErrorMessage = "Qualification Type cannot exceed 50 characters.")]
        public string QualificationType { get; set; }

        [Required(ErrorMessage = "Degree Title is required.")]
        [StringLength(100, ErrorMessage = "Degree Title cannot exceed 100 characters.")]
        public string DegreeTitle { get; set; }

        [Required(ErrorMessage = "Major Subject is required.")]
        [StringLength(100, ErrorMessage = "Major Subject cannot exceed 100 characters.")]
        public string MajorSubject { get; set; }

        [Required(ErrorMessage = "Marks or CGPA is required.")]
        public int MarksOrCGPA { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Institute is required.")]
        [StringLength(150, ErrorMessage = "Institute name cannot exceed 150 characters.")]
        public string Institute { get; set; }
        [ForeignKey("EmployeeId")]
        [JsonIgnore]
        [ValidateNever]
        public Employee Employee { get; set; }

    }
}
