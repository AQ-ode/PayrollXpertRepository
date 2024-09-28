using PayrollXpert.Models.Employees;
namespace PayrollXpert.API.Api_Models.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Person Type is required.")]
        public string PersonType { get; set; }

        [Required(ErrorMessage = "Employee Number is required.")]
        public int EmployeeNumber { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        public string? ProfileImagePath { get; set; }


        [Required(ErrorMessage = "National ID is required.")]
        [StringLength(15, ErrorMessage = "National ID cannot exceed 15 characters.")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province name cannot exceed 50 characters.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        [StringLength(50, ErrorMessage = "Nationality cannot exceed 50 characters.")]
        public string Nationality { get; set; }

        [StringLength(50, ErrorMessage = "Religion name cannot exceed 50 characters.")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Father or Husband's Name is required.")]
        [StringLength(100, ErrorMessage = "Father or Husband's Name cannot exceed 100 characters.")]
        public string FatherOrHusbandName { get; set; }

        [StringLength(100, ErrorMessage = "Mother's Name cannot exceed 100 characters.")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Marital Status is required.")]
        public string MaritalStatus { get; set; }

        [StringLength(100, ErrorMessage = "Spouse Name cannot exceed 100 characters.")]
        public string SpouseName { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Emergency Contact is required.")]
        public string EmergencyContact { get; set; }

        public EmployeeShiftInformation ShiftInformation { get; set; }

        public EmployeeQualification Qualification { get; set; }
    }

}
