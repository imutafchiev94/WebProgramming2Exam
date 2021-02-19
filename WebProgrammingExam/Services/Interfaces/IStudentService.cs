using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebProgrammingExam.App.Services.Interfaces
{
    public interface IStudentService
    {
        ICollection<Student> GetAllStudents { get; }

        string CreateStudent (string facultyNumber, string major, string firstName, string lastName);

        string EditStudent (int id, string facultyNumber, string major, string firstName, string lastName);

        string DeleteStudent (int id);

        Student GetStudentById (int id);

    }
}
