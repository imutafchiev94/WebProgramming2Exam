using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FacultyNumber { get; set; }

        public string Mayor { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
