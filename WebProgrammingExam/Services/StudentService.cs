using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using WebProgrammingExam.App.Services.Interfaces;
using WebProgrammingExam.Data;

namespace WebProgrammingExam.App.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Student> GetAllStudents
        {
            get
            {
                return this._dbContext.Students.ToList();
            }
        }

        public string CreateStudent(string facultyNumber, string major, string firstName, string lastName)
        {
            if (CanBeAdded(major))
            {
                var student = new Student
                {
                    FacultyNumber = facultyNumber,
                    FirstName = firstName,
                    LastName = lastName,
                    Mayor = major
                };

                this._dbContext.Students.Add(student);
                this._dbContext.SaveChanges();

                return "Student was added successfully!";
            }
            else
            {
                return "The limit of students for this mayor is reached!";
            }

        }

        public string EditStudent(int id, string facultyNumber, string major, string firstName, string lastName)
        {
            var student = this._dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Mayor = major;
                student.FacultyNumber = facultyNumber;

                this._dbContext.Students.Update(student);
                this._dbContext.SaveChanges();

                return "Student was edited successfully!";
            }
            else
            {
                return "Student doesn't exist!";
            }

        }

        public string DeleteStudent(int id)
        {
            var student = this._dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                this._dbContext.Students.Remove(student);
                this._dbContext.SaveChanges();

                return "Student was deleted successfully!";
            }
            else
            {
                return "Student doesn't exist!";
            }
        }

        public Student GetStudentById(int id)
        {
            return this._dbContext.Students.FirstOrDefault(s => s.Id == id);
        }

        private bool CanBeAdded(string mayor)
        {
            var studentsFromThisMayor = this._dbContext.Students.Where(s => s.Mayor == mayor).ToList();

            if (studentsFromThisMayor.Count < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
