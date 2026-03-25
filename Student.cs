using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public string? GradeClassification { get; set; }

        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }

    }
}
