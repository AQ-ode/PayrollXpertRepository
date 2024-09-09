﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PayrollXpert.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollXpert.API.Api_Models.Employees
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string NationalId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]

        public Department Department { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        public string EmploymentType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public double Salary { get; set; }

        [Required]
        public string PayFrequency { get; set; }

        [StringLength(20)]
        public string BankAccountNumber { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }

        [StringLength(20)]
        public string TaxId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(100)]
        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        [StringLength(50)]
        public string EmergencyContactRelationship { get; set; }

        //    [StringLength(255)]
        //    public string ProfilePictureUrl { get; set; }
        //}
    }
}
