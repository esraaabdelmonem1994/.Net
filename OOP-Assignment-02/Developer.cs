using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_02
{
    public class Developer : Employee
    {
        private string programmingLanguage;
        public string ProgrammingLanguage { get { return programmingLanguage; } set { programmingLanguage = value; } }

        public override void DisplayInfo()
        {
            Console.WriteLine("Developer:");
            base.DisplayInfo();
           
        }
        public void DisplayDeveloperInfo()
        {
            Console.WriteLine($", Language: {ProgrammingLanguage}");
        }
    }
}
