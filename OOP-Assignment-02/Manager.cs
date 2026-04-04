using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_Assignment_02
{
    public class Manager : Employee
    {
        private double bonus;
        public double Bonus { get { return bonus; } set { bonus = (value > 0) ? value : throw new Exception("Bonus cannot be negative!"); } }

        public double CalculateTotalSalary()
        {
            return Salary + bonus;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Manager:");
            base.DisplayInfo();
            Console.WriteLine($", Bonus: {Bonus}");
            Console.WriteLine($"Total Salary: {CalculateTotalSalary()}");
        }
    }
}
