namespace OOP_Assignment_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.Create at least 2 students
            //2.Assign different levels(using enum)
            //3. Assign addresses(using struct)
            //4. Store them in a list or array
            //5. Loop through and display their info

            //I prefered to apply the task requirement at once without seperate the answer for each point to avoid redundancy



            Student student1 = new Student(1);
            Student student2 = new Student(2);

            Student[] studentList = { student1, student2 };
            string[] studentValues = Enum.GetNames(typeof(StudentLevel));


            foreach (Student student in studentList)
            {
                Console.Write("Enter the Student Name:");
                student.Name = Console.ReadLine();

                Console.WriteLine("Choose the student Level, enter your choice's number:");

                for (int i = 0; i < studentValues?.Length; i++)
                {
                    Console.WriteLine($"{i}. {studentValues[i]}");
                }

                while (true)
                {
                    string level = Console.ReadLine();
                    if (Enum.TryParse(level, out StudentLevel result) && Enum.IsDefined(typeof(StudentLevel), result))
                    {
                        student.UpdateStudentLevel(result); break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value please Enter a valid Student Level");
                    }
                }

                Address address = new Address();

                Console.Write("Enter the Student Address Street: ");
                address.Street = Console.ReadLine();

                Console.Write("Enter the Student Address City: ");
                address.City = Console.ReadLine();

                Console.Write("Enter the Student Address ZipCode: ");
                while (true)
                {
                    string zipCode = Console.ReadLine();
                    if (int.TryParse(zipCode, out int result))
                    {
                        address.ZipCode = result; break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value please Enter a valid Student Address ZipCode");
                    }
                }

                student.Address = new Address(address.Street, address.City, address.ZipCode);
            }


            Console.WriteLine("Student Details are:");
            foreach (Student student in studentList)
            {
                student.DisplayInfo();

                Console.WriteLine();
            }

        }
    }
}
