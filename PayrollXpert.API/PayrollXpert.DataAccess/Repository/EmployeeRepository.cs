using Bulky.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.DataAccess.Data;

namespace PayrollXpert.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Employee obj)
        {
            var objFromDb = _db.Employees.Include(e => e.ShiftInformation)
                                           .Include(e => e.Qualification)
                                           .FirstOrDefault(x => x.EmployeeId == obj.EmployeeId);
            if (objFromDb != null)
            {

                objFromDb.PersonType = obj.PersonType;
                objFromDb.EmployeeNumber = obj.EmployeeNumber;
                objFromDb.FirstName = obj.FirstName;
                objFromDb.LastName = obj.LastName;
                objFromDb.Gender = obj.Gender;
                objFromDb.NationalId = obj.NationalId;
                objFromDb.StartDate = obj.StartDate;
                objFromDb.EndDate = obj.EndDate;
                objFromDb.DateOfBirth = obj.DateOfBirth;
                objFromDb.Country = obj.Country;
                objFromDb.Province = obj.Province;
                objFromDb.City = obj.City;
                objFromDb.Nationality = obj.Nationality;
                objFromDb.Religion = obj.Religion;
                objFromDb.FatherOrHusbandName = obj.FatherOrHusbandName;
                objFromDb.MotherName = obj.MotherName;
                objFromDb.MaritalStatus = obj.MaritalStatus;
                objFromDb.SpouseName = obj.SpouseName;
                objFromDb.Contact = obj.Contact;
                objFromDb.EmergencyContact = obj.EmergencyContact;
                objFromDb.ProfileImagePath = obj.ProfileImagePath;


                if (obj.ShiftInformation != null)
                {
                    if (objFromDb.ShiftInformation != null)
                    {
                        objFromDb.ShiftInformation.ShiftName = obj.ShiftInformation.ShiftName;
                        objFromDb.ShiftInformation.StartTime = obj.ShiftInformation.StartTime;
                        objFromDb.ShiftInformation.EndTime = obj.ShiftInformation.EndTime;
                    }
                    else
                    {
                        objFromDb.ShiftInformation = obj.ShiftInformation;
                    }
                }

                if (obj.Qualification != null)
                {
                    if (objFromDb.Qualification != null)
                    {
                        objFromDb.Qualification.QualificationType = obj.Qualification.QualificationType;
                        objFromDb.Qualification.DegreeTitle = obj.Qualification.DegreeTitle;
                        objFromDb.Qualification.MajorSubject = obj.Qualification.MajorSubject;
                        objFromDb.Qualification.MarksOrCGPA = obj.Qualification.MarksOrCGPA;
                        objFromDb.Qualification.StartDate = obj.Qualification.StartDate;
                        objFromDb.Qualification.EndDate = obj.Qualification.EndDate;
                        objFromDb.Qualification.Institute = obj.Qualification.Institute;
                    }
                    else
                    {

                        objFromDb.Qualification = obj.Qualification;
                    }
                }
            }
        }
    }
}
