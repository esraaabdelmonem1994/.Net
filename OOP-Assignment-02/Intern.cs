using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_02
{
    public class Intern : Employee
    {
        public int DurationMonths { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine("Intern:");
            base.DisplayInfo();
            Console.WriteLine($", DurationMonths: {DurationMonths}");
        }

    }
}
