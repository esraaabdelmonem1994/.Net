using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_02
{
    public class Employee
    {
        private int id;
        private string name;
        private double salary;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Salary { get { return salary; } set { salary = (salary >= 0) ? value : throw new Exception("Salary cannot be negative!"); } }

        public virtual void DisplayInfo()
        {
            Console.Write($"ID: {Id}, Name: {Name}, Salary: {Salary}");
        }
    }
}
