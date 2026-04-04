namespace OOP_Assignment_02
{
    public class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Developer developer = new Developer();
            Intern intern = new Intern();

            manager.Id = 1;
            manager.Name = "Ahmed";
            manager.Salary = 8000;
            manager.Bonus = 2000;

            developer.Id = 2;
            developer.Name = "Sara";
            developer.Salary = 6000;
            developer.ProgrammingLanguage = "C#";


            intern.Id = 3;
            intern.Name = "Mohamed";
            intern.Salary = 3000;
            intern.DurationMonths = 3;

            manager.DisplayInfo();
            Console.WriteLine();

            developer.DisplayInfo();
            developer.DisplayDeveloperInfo();
            Console.WriteLine();

            intern.DisplayInfo();

        }
    }
}
