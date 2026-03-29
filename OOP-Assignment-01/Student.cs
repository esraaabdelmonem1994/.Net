using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_01
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentLevel Level { get; set; }

        public Address Address { get; set; }

        public Student(int id)
        {
            Id = id;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Level: {this.Level}");
            Console.WriteLine($"Address: {this.Address.City}, {this.Address.Street}, {this.Address.ZipCode}");
        }

        public void UpdateStudentLevel(StudentLevel studentLevel)
        {
            this.Level = studentLevel;

        }
    }
}
