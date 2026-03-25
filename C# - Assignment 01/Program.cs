using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Text;

namespace Assignment_01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            #region InputStudents
            //1.Input Students
            //Ask the user to enter the number of students.
            int numberOfStudents;
            while (true)    //I used while(true) in all input to avoid crashing the app if I used exception to make sure that user added correct value
            {
                Console.Write("Enter the number of students: ");
                if (int.TryParse(Console.ReadLine(), out numberOfStudents))
                    break; // exit the loop
                Console.WriteLine("Invalid Value");
            }


            //Use a for loop to: Input each student’s name & Input each student’s grade(0–100)
            for (int i = 0; i < numberOfStudents; i++)
            {
                string name;
                while (true)
                {
                    Console.Write("Enter the student name: ");
                    name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("Name cannot be empty!");
                }

                while (true)
                {
                    Console.Write("Enter the student grade (0–100): ");
                    if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 0 && grade <= 100)
                    {
                        students.Add(new Student(name, grade));
                        break; // exit the loop
                    }
                    Console.WriteLine("Invalid Value, Grade must be between 0 and 100.");
                }
            }
            #endregion

            #region Grade Classification
            //2.Grade Classification(if condition)
            //For each student: Use if-else conditions to determine grade level:
            foreach (var student in students)
            {
                if (student.Grade >= 90)
                {
                    student.GradeClassification = "Excellent";
                }
                else if (student.Grade >= 75)
                {
                    student.GradeClassification = "Very Good";
                }
                else if (student.Grade >= 60)
                {
                    student.GradeClassification = "Good";
                }
                else if (student.Grade >= 50)
                {
                    student.GradeClassification = "Pass";
                }
                else
                {
                    student.GradeClassification = "Fail";
                }
            }
            #endregion

            #region Display All Students
            //3.Display All Students(foreach)
            DisplayAllStudents(students);
            #endregion

            #region Calculations
            //5.Calculations(while loop)
            //Use a while loop to: Calculate the average grade, and Find the highest grade 
            int totalGrade = 0;
            int averageGrade = 0;
            int highestGrade = 0;

            int index = 0;
            while (index < students.Count)
            {
                totalGrade += students[index].Grade;
                if (students[index].Grade > highestGrade)
                {
                    highestGrade = students[index].Grade;
                }
                index++;
            }
            if (students.Count > 0) averageGrade = totalGrade / students.Count;
            Console.WriteLine($"The average grade is: {averageGrade}");
            Console.WriteLine($"The highest grade is: {highestGrade}");
            #endregion


            #region Menu System
            //4.Menu System(do -while + switch)
            //Create a menu that keeps showing until the user exits
            //Use a do -while loop to repeat the menu, and Use a switch statement to handle user choices 
            int choice = 0;
            do
            {
                Console.WriteLine("===================================================="); //Just for reading when testing it
                Console.WriteLine("Chose one of these choices: ");
                Console.WriteLine("1.Show all students");
                Console.WriteLine("2.Show average grade");
                Console.WriteLine("3.Show highest grade");
                Console.WriteLine("4.Show failed students");
                Console.WriteLine("5.Exit");
                //Console.Write("write the number: ");
                //choice = int.Parse(Console.ReadLine());
                while (true)
                {
                    Console.Write("write the number: ");
                    if (int.TryParse(Console.ReadLine(), out choice))
                        break; // exit the loop
                    Console.WriteLine("Invalid Value");
                }


                Console.WriteLine("===================================================="); //Just for reading when testing it
                switch (choice)
                {
                    case 1: DisplayAllStudents(students); break;
                    case 2: Console.WriteLine($"The average grade is: {averageGrade}"); break;
                    case 3: Console.WriteLine($"The highest grade is: {highestGrade}"); ; break;
                    case 4: DisplayFailedStudent(students); break;
                    case 5: Console.WriteLine("Exiting..."); break;
                }
            } while (choice != 5);
            #endregion

            #region Failed Students
            //6.Failed Students
            //Display students with grade< 50 
            DisplayFailedStudent(students);
            #endregion
        }

        static void DisplayAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                DisplayStudent(student);
            }
        }

        static void DisplayFailedStudent(List<Student> students)
        {
            bool hasFailedStudent = false;
            foreach (var student in students)
            {
                if (student.Grade < 50)
                {
                    hasFailedStudent = true;
                    Console.WriteLine("Failed students: ");
                    DisplayStudent(student);
                }
            }

            if (!hasFailedStudent)
            {
                Console.WriteLine("There is no failed students.");
            }
        }
        static void DisplayStudent(Student student)
        {
            Console.WriteLine($"Student Name: {student.Name} with Grade: {student.Grade} and Grade Classification: {student.GradeClassification}");
        }
    }
}
