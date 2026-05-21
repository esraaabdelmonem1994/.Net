using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO.Pipelines;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.(Where) Given a list of integers: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10].
            // Return all even numbers.[2, 4, 6, 8, 10]
            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evenNumbers = ints.Where(number => number % 2 == 0).ToList();

            Console.Write("1. Even Numbers: ");
            foreach (int number in evenNumbers)
            { Console.Write($"{number} "); }
            Console.WriteLine();


            //2.(Where) Given a list of product prices: [15, 90, 120, 45, 200].
            //Return prices greater than 100. [120, 200]
            List<int> prices = new List<int> { 15, 90, 120, 45, 200 };
            List<int> filteredPrices = prices.Where(number => number > 100).ToList();
            Console.Write("2. Prices greater than 100: ");
            foreach (int price in filteredPrices)
            { Console.Write($"{price} "); }
            Console.WriteLine();


            //3. (Select)  Given names: ["Ali", "Mona", "Sara"].
            //Return all names in uppercase.  ["ALI", "MONA", "SARA"]
            List<string> names = new List<string> { "Ali", "Mona", "Sara" };
            List<string> upperNames = names.Select(name => name.ToUpper()).ToList();
            Console.Write("3. Uppercase Names: ");
            foreach (string name in upperNames)
            { Console.Write($"{name} "); }
            Console.WriteLine();


            //4. (Count) Given scores: [50, 80, 90, 40, 70].
            //Count how many scores are >= 60.    3
            List<int> scores = new List<int> { 50, 80, 90, 40, 70 };
            int scoreCount = scores.Count(s => s >= 60);
            Console.WriteLine($"4. Score Count: {scoreCount} ");


            //5.(FirstOrDefault) Given employees with Id and Name.	
            // Find the employee whose Id equals 3.Employee object or null
            var employees = new[]
             {
                 new { Id=1, Name= "Esraa"},
                 new { Id=2, Name= "Ahmed"},
                 new { Id=3, Name= "Mostafa"}
             };
            var employee = employees.FirstOrDefault(e => e.Id == 3);
            Console.WriteLine($"5. Employee whose Id equals 3: {employee?.Id} , {employee?.Name} ");


            //6. (OrderBy) Given students with Name and Age.	
            //Sort students by Age ascending.Youngest to oldest
            var students = new[]
             {
                 new { Name= "Ali", Age=30},
                 new { Name= "Hossam", Age = 15},
                 new { Name= "Basha", Age = 40}
             };
            var sortedStudents = students.OrderBy(s => s.Age).ToList();
            Console.Write("6. Sort students by Age ascending: ");
            foreach (var student in sortedStudents)
            { Console.Write($"{student.Age} "); }
            Console.WriteLine();


            //7. (OrderByDescending)   Given products with Name and Price.	
            //Sort products by Price descending.Highest price first
            var products = new[]
             {
                 new { Id=1, Name= "Product 01", Price=30},
                 new { Id=2, Name= "Product 02", Price = 15},
                 new { Id=3,  Name= "Product 03", Price = 40}
             };
            var sortedProducts = products.OrderByDescending(p => p.Price).ToList();
            Console.Write("7. Sort products by Price descending: ");
            foreach (var product in sortedProducts)
            { Console.Write($"{product.Price} "); }
            Console.WriteLine();


            //8. (Any) Given orders with OrderId and Total.	
            //Check if any order total is greater than 1000.  true / false
            var orders = new[]
             {
                 new { OrderId= 1, Total=550},
                 new { OrderId= 2, Total = 1150},
                 new { OrderId= 3, Total = 1100}
             };
            bool greaterOrder = orders.Any(o => o.Total > 1000);
            Console.WriteLine($"8. order total is greater than 1000: {greaterOrder}");


            //9. (All) Given a list of ages.Check if all ages are 18 or above.	true / false
            var ages = new List<int> { 18, 20, 50, 60, 10, 15 };
            bool allAdults = ages.All(a => a >= 18);
            Console.WriteLine($"9. All ages are 18 or above: {allAdults}");


            //10. (Contains) Given tags: ["csharp", "linq", "sql"].Check if the list contains "linq".  true
            List<string> tags = new List<string> { "csharp", "linq", "sql" };
            bool existText = tags.Contains("linq");
            Console.WriteLine($"10. List contains 'linq': {existText}");

            //11. (Skip) Given numbers 1 to 10.Skip the first 3 numbers.   [4, 5, 6, 7, 8, 9, 10]
            var numbers = Enumerable.Range(1, 10);
            var takenNumbersAfterSkip = numbers.Skip(3).ToList();
            Console.Write($"11. Given numbers 1 to 10.Skip the first 3 numbers: ");
            foreach (int number in takenNumbersAfterSkip)
            { Console.Write($"{number} "); }
            Console.WriteLine();


            //12. (Take)    Given numbers 1 to 10.Take the first 5 numbers.   [1, 2, 3, 4, 5]
            var takenNumbers = numbers.Take(5).ToList();
            Console.Write($"12. Given numbers 1 to 10.Take the first 5 numbers: ");
            foreach (int number in takenNumbers)
            { Console.Write($"{number} "); }
            Console.WriteLine();


            //13. (Distinct)    Given city names with duplicates.Return unique city names.	No duplicates
            List<string> cities = new List<string> { "Cairo", "Alex", "Alex", "Aswan" };
            var setCities = cities.Distinct().ToList();
            Console.Write("13. Unique city names: ");
            foreach (string city in setCities)
            { Console.Write($"{city} "); }
            Console.WriteLine();

            //14. (Sum) Given invoice amounts.Calculate the total invoice amount.Single numeric total
            var invoices = new List<decimal> { 100, 500, 1050, 3000 };
            var totalInvoiceAmount = invoices.Sum();
            Console.WriteLine($"14. total invoice amount: {totalInvoiceAmount}");


            //15. (Average) Given student grades.Calculate the average grade.	Single numeric average
            var studentsGrades = new[]
             {
                 new { Name= "Ali", Age=30, Grade= 75},
                 new { Name= "Hossam", Age=20, Grade= 80},
                 new { Name= "Basha", Age = 40, Grade= 50}
             };
            var averageGrade = studentsGrades.Average(s => s.Grade);
            //If I have grades data only so the answer will be => var averageGrade = grades.Average();
            Console.WriteLine($"15. The average grade: {averageGrade}");


            //16. (Max) Given product prices.Find the maximum price.	Highest price
            var maxProductPrice = products.Max(s => s.Price);
            Console.WriteLine($"16. the maximum product price: {maxProductPrice}");


            //17. (Min) Given product prices.Find the minimum price.	Lowest price
            var minProductPrice = products.Min(s => s.Price);
            Console.WriteLine($"17. the minimum product price: {minProductPrice}");

            //18. (Select)  Given employees with FirstName and LastName.	
            //Return full names as strings.   ["First Last", ...]
            var fullEmployees = new[]
             {
                 new { Id=4, FirstName= "Esraa", LastName="Abd Elmonem"},
                 new { Id=5, FirstName= "Ahmed", LastName="Ali"},
                 new { Id=6, FirstName= "Mostafa", LastName="Ahmed"}
             };
            var fullNames = fullEmployees.Select(e => $"{e.FirstName} {e.LastName}").ToList();
            Console.Write($"18. Full names:");
            foreach (string fullName in fullNames)
            { Console.WriteLine($"    {fullName} "); }


            //19. (Where + Select)  Given products with Name and Stock.	
            //Return names of products that are out of stock.	Product names only
            var productsWithStock = new[]
             {
                 new { Name= "Product 01", Stock = 100},
                 new { Name= "Product 02", Stock = 50},
                 new { Name= "Product 03", Stock = 300},
                 new { Name= "Product 04", Stock = 0}
             };
            var outOfStock = from p in productsWithStock where p.Stock == 0 select p.Name;
            Console.Write("19. Names of products that are out of stock: ");
            foreach (string name in outOfStock)
            { Console.Write($"{name} "); }
            Console.WriteLine();


            //20. (First) Given a list of numbers.
            //Return the first number greater than 50.First matching number
            List<int> listInts = new List<int> { 1, 5, 45, 7, 14, 9, 60, 11, 51 };
            int firstNumber = listInts.First(n => n > 50);
            Console.WriteLine($"20. The first number greater than 50: {firstNumber} ");


            //21. (Where +OrderBy) Given customers with Name, Country, and JoinDate.
            //Return Egyptian customers ordered by JoinDate descending.Newest Egyptian customers first
            var customers = new[]
                    {
                        new { Id= 1, Name = "Ahmed", Country = "Egypt", JoinDate = new DateTime(2023, 1, 15) },
                        new { Id= 2, Name = "John", Country = "USA", JoinDate = new DateTime(2022, 11, 20) },
                        new { Id= 3, Name = "Mona", Country = "Egypt", JoinDate = new DateTime(2024, 5, 10) },
                        new { Id= 4, Name = "Sara", Country = "Egypt", JoinDate = new DateTime(2021, 8, 5) }
                    };

            var egyptianCustomers = customers.Where(c => c.Country == "Egypt").OrderByDescending(c => c.JoinDate).ToList();
            Console.Write("21. Egyptian customers ordered by JoinDate descending: ");
            foreach (var customer in egyptianCustomers)
            { Console.WriteLine($"      {customer.Name} {customer.JoinDate} "); }


            //22. (GroupBy) Given orders with CustomerId and Total.	
            //Group orders by CustomerId and calculate total spent per customer.	CustomerId + TotalSpent
            var customerOrders = new[]
            {
                 new { CustomerId= 1, Total=550},
                 new { CustomerId= 2, Total = 1150},
                 new { CustomerId= 2, Total = 1000},
                 new { CustomerId= 3, Total = 1100}
             };

            var groupOrders = customerOrders.GroupBy(co => co.CustomerId).Select(group => new
            {
                CustomerId = group.Key,
                TotalSpent = group.Sum(c => c.Total)
            }).ToList();

            Console.WriteLine($"22. Group orders by CustomerId and calculate total spent per customer: ");
            foreach (var order in groupOrders)
            {
                Console.WriteLine($"    {order.CustomerId} : {order.TotalSpent}");
            }


            //23. (GroupBy) Given students with Department and Grade.	
            // Find average grade per department.Department + AverageGrade
            var studentDepartments = new[]
             {
                 new { StudentName= "Ali", Department= "Department 1", Grade=75},
                 new { StudentName= "Ahmed", Department= "Department 1", Grade = 80},
                 new { StudentName= "Abas",Department= "Department 3", Grade = 95},
                 new { StudentName= "Sherren",Department= "Department 2", Grade = 100}
             };
            var averageGrades = studentDepartments.
                GroupBy(sd => sd.Department).
                Select(group => new
                {
                    Department = group.Key,
                    AverageGrade = group.Sum(g => g.Grade)
                }).ToList();
            Console.WriteLine($"23. Average grade per department: ");
            foreach (var item in averageGrades)
            {
                Console.WriteLine($"    {item.Department} : {item.AverageGrade}");
            }


            //24. (Join) Given Employees and Departments lists.
            //Return employee names with their department names.EmployeeName + DepartmentName
            var departments = new[]
            {
                new {Id=1, Name = "Department 01"},
                new {Id=2, Name = "Department 02"},
                new {Id=3, Name = "Department 03"}
            };
            var EmployeeList = new[]
           {
                new {Id=1, Name = "Habiba", DepartmentId=1},
                new {Id=2, Name = "Mazen", DepartmentId=1},
                new {Id=3, Name = "Ashraf", DepartmentId=3},
                new {Id=4, Name = "Tota", DepartmentId=2}
            };
            var employeeDepartments = from e in EmployeeList
                                      join d in departments
                                      on e.DepartmentId equals d.Id
                                      select new { EmployeeName = e.Name, DepartmentName = d.Name };
            Console.WriteLine("24. Employee names with their department names: ");
            foreach (var ed in employeeDepartments)
            {
                Console.WriteLine($"    {ed.EmployeeName} , {ed.DepartmentName}");
            }

            //25. (GroupJoin) Given customers and orders.	
            //Return each customer with their order count.CustomerName + OrderCount
            var customerOrderCount = customers.GroupJoin(customerOrders, c => c.Id, co => co.CustomerId, (customer, orders) => new
            {
                CustomerName = customer.Name,
                OrderCount = orders.Count()
            });
            Console.WriteLine("25. Customer with their order count: ");
            foreach (var coc in customerOrderCount)
            {
                Console.WriteLine($"    {coc.CustomerName} , {coc.OrderCount}");
            }


            //26. (SelectMany) Given categories where each category has a list of products.	
            //Flatten all products into one list.	Single product list

            var categorieProducts = new[]
            {
                new {
                    Name="Category 01",
                    products = new []  {
                    new {Id= 1, Name = "Product 01"},
                    new {Id= 2, Name = "Product 02"},
                    new {Id= 3, Name = "Product 03"}
                }
                },
                  new {
                    Name="Category 02",
                    products = new []  {
                    new {Id= 4, Name = "Product 04"},
                    new {Id= 5, Name = "Product 05"},
                    new {Id= 6, Name = "Product 06"}
                }
                }
            };
            var productList = categorieProducts.SelectMany(c => c.products).ToList();
            Console.WriteLine("26. Flatten all products into one list: ");
            foreach (var pl in productList)
            {
                Console.WriteLine($"    {pl.Name}");
            }


            //27. (ThenBy) Given employees with Department and Salary.	
            //Sort by Department, then by Salary descending.	Grouped - style sorted output
            var employeeDepartmentList = new[]
            {
                new {Id= 1, Name= "Ahmed", Department="Department 01", Salary = 2000},
                new {Id= 2, Name= "Monem", Department="Department 02", Salary = 15000},
                new {Id= 3, Name= "Hany", Department="Department 01", Salary = 50000},
                new {Id= 4, Name= "Mervat", Department="Department 04", Salary = 80000},
                new {Id= 5, Name= "Fawzy", Department="Department 03", Salary = 3500}

            };
            var sortedEmployeeDepartmentList = employeeDepartmentList.OrderBy(ed => ed.Department).ThenByDescending(d => d.Salary).ToList();
            Console.WriteLine("27. Sort by Department, then by Salary descending: ");
            foreach (var se in sortedEmployeeDepartmentList)
            {
                Console.WriteLine($"    {se.Department}, Salary = {se.Salary}");
            }


            //28. (TakeWhile) Given sorted transaction amounts.	
            //Return transactions until the first amount greater than 500.Prefix only
            var transactionAmounts = new List<int> { 100, 400, 500, 700, 1000, 2000, 3500 };
            var transactions = transactionAmounts.TakeWhile(a => a <= 500).ToList();
            Console.WriteLine("28. Transactions until the first amount greater than 500: ");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"    {transaction}");
            }


            //29. (SkipWhile) Given sorted temperatures.Skip temperatures below 30,
            //then return the rest.Remaining sequence
            var temperatures = new List<int> { 10, 16, 18, 20, 22, 28, 30, 32 };
            var remaining = temperatures.SkipWhile(t => t < 30).ToList();
            Console.Write("29. Skip temperatures below 30: ");
            foreach (var r in remaining)
            {
                Console.Write($"    {r}  ");
            }
            Console.WriteLine();

            //30. (ToDictionary) Given products with Id and Name.	
            //Create a dictionary where key = Id and value = Name.Dictionary<int, string>
            var dictionary = products.ToDictionary(p => p.Id, p => p.Name);
            Console.WriteLine("30. Dictionary where key = Id and value = Name.Dictionary");
            foreach (var d in dictionary)
            {
                Console.WriteLine($"    Key: {d.Key} , Value: {d.Value}");
            }

            //31. (Lookup)  Given orders with CustomerId.	
            //Create a lookup of CustomerId to orders.ILookup < CustomerId, Order >
            var orderList = new[]
            {
                new {Id= 1, CustomerId = 1},
                new {Id= 2, CustomerId = 1},
                new {Id= 3, CustomerId = 2},
                new {Id= 4, CustomerId = 2},
            };
            var lookup = orderList.ToLookup(s => s.CustomerId);
            Console.WriteLine("31. Lookup of CustomerId to orders.ILookup");
            foreach (var l in lookup)
            {
                Console.WriteLine($"    Key: {l.Key} , Value:{l.Count()}");
            }


            //32. (Aggregate)   Given words: ["LINQ", "is", "powerful"].Join them into one sentence using Aggregate.    "LINQ is powerful"
            var words = new List<string> { "LINQ", "is", "powerful" };
            var sentence = words.Aggregate((current, next) => current + " " + next);
            Console.WriteLine($"32. One sentence using Aggregate: {sentence}");


            //33. (Where + Count) Given users with IsActive and LastLoginDate.	
            //Count active users who logged in in the last 30 days.Single count
            var users = new[]
            {
                new {Id=1, Name="Mohamed", IsActive= true, LastLoginDate = new DateTime(2021, 8, 5)},
                new {Id=2, Name="Ali", IsActive= false, LastLoginDate = new DateTime(2021, 8, 5)},
                new {Id=3, Name="Medhat", IsActive= false, LastLoginDate = new DateTime(2026,2, 2)},
                new {Id=4, Name="Fathy", IsActive= true, LastLoginDate = new DateTime(2026, 4, 20)}
            };
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);
            var activeUserCount = users.Where(u => u.LastLoginDate >= thirtyDaysAgo && u.IsActive).Count();
            Console.WriteLine($"33. Count active users who logged in in the last 30 days: {activeUserCount}");


            //34. (Projection)  Given orders with OrderLines.	
            //Return each order with calculated Total from its lines.OrderId + Total
            var ordersList = new[]
            {
                new {
                    Id=1,
                    Lines = new []
                    {
                        new {Price = 100, Quantity = 2},
                        new {Price = 300, Quantity = 3}
                    }
                    },
                 new {
                    Id=2,
                    Lines = new []
                    {
                        new {Price = 250, Quantity = 3},
                        new {Price = 500, Quantity = 4}
                    }
                    }
            };

            var ordersWithTotal = ordersList.Select(o => new
            {
                OrderId = o.Id,
                Total = o.Lines.Sum(l => l.Price * l.Quantity)
            }).ToList();
            Console.WriteLine("34. Each order with calculated Total");
            foreach (var o in ordersWithTotal)
            {
                Console.WriteLine($"    OrderId: {o.OrderId} , Total:{o.Total}");
            }


            //35. Nested Any Given customers with a list of orders.	
            //Return customers who have at least one order above 1000.Matching customers
            var customersOrders = new[]
            {
                new {
                    Id= 1,
                    Name= "Customer 01",
                    Orders = new []
                    {
                        new {Id= 5, Total = 500},
                        new {Id= 6, Total = 1000}
                    }
                },
                new {
                Id= 2,
                 Name= "Customer 02",
                Orders = new []
                {
                    new {Id= 3, Total = 1100},
                    new {Id= 4, Total = 2000}
                }
                }
            };
            var filteredCustomers = customersOrders.Where(c => c.Orders.Any(o => o.Total > 1000)).ToList();

            Console.WriteLine("35. Customers who have at least one order above 1000");
            foreach (var fc in filteredCustomers)
            {
                Console.WriteLine($"    Customer: {fc.Name} , Orders:{fc.Orders.Count()}");
            }

            //36. Nested All Given classes with student grades.	Return classes where all students passed.	
            //Classes only

            var classes = new[]
            {
                new
                {
                    Id=1,
                    Name = "Math",
                    Students = new []
                    {
                        new {Id= 1,Name = "Mohamed", Grade = 49 },
                        new {Id= 2,Name = "Ali", Grade = 70 },
                        new {Id= 3,Name = "Fawzya", Grade = 80 },
                    }
                },
                 new
                {
                    Id=1,
                    Name = "Sciense",
                    Students = new []
                    {
                        new {Id= 1,Name = "Mohamed", Grade = 80 },
                        new {Id= 2,Name = "Ali", Grade = 100 },
                        new {Id= 3,Name = "Fawzya", Grade = 95 },
                    }
                }
            };
            var passes = classes.Where(c => c.Students.All(s => s.Grade >= 50)).ToList();
            Console.WriteLine("36. Classes where all students passed");
            foreach (var p in passes)
            {
                Console.WriteLine($"    Class: {p.Name}");
            }


            //37. (DistinctBy)  Given employees with duplicate Email values.	
            //Return unique employees by Email.One employee per email
            var employeeData = new[]
            {
                new {Id=1, Name="Employee 01", Email = "employee01@company.com"},
                new {Id=2, Name="Employee 02", Email = "employee01@company.com"},
                new {Id=3, Name="Employee 03", Email = "employee02@gmail.com"},
                new {Id=4, Name="Employee 04", Email = "employee02@gmail.com"},
            };
            var uniqueEmployee = employeeData.DistinctBy(e => e.Email).ToList();
            Console.WriteLine("37. Unique employees by Email");
            foreach (var u in uniqueEmployee)
            {
                Console.WriteLine($"    Name: {u.Name} Email: {u.Email}");
            }


            //38. (Chunk) Given 53 records.Split records into pages of size 10.    6 chunks / pages
            var records = Enumerable.Range(0, 53);
            var pages = records.Chunk(10).ToList();
            Console.WriteLine($"38. Split records into pages: {pages.Count} chunks / pages");


            //39. (Except) Given registered user IDs and attended user IDs.
            //	Find registered users who did not attend.Missing attendees
            var registeredUserIDs = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var attendedUserIDs = new List<int> { 1, 3, 4, 6, 7, 9 };
            var miisingAttendeesIDs = registeredUserIDs.Except(attendedUserIDs).ToList();
            Console.Write("39. Miising Attendees IDs: ");
            foreach (int id in miisingAttendeesIDs)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine();


            //40. (Intersect) Given two product ID lists from two stores.	
            //Find product IDs available in both stores.	Common IDs
            var FirstStoreProductIDs = new List<int> { 1, 2, 4, 6, 7, 8, 9, 10, 15 };
            var SecondStoreProductIDs = new List<int> { 1, 3, 4, 7, 9 };
            var intersectProductIds = FirstStoreProductIDs.Intersect(SecondStoreProductIDs).ToList();
            Console.Write("40. Product IDs available in both stores: ");
            foreach (int id in intersectProductIds)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine();


            //41. (Union) Given online customer IDs and branch customer IDs.	
            // Return all unique customer IDs.Combined unique list
            var onlineCustomerIDs = new List<int> { 1, 2, 4, 6, 7, 8, 9, 10, 15 };
            var branchCustomerIDs = new List<int> { 1, 3, 4, 7, 9 };
            var uniqueCustomerIDs = onlineCustomerIDs.Union(branchCustomerIDs).ToList();
            Console.Write("41. unique customer IDs: ");
            foreach (int id in uniqueCustomerIDs)
            {
                Console.Write($"{id} ,");
            }
            Console.WriteLine();


            //42. (Zip) Given product names and product prices lists.
            //Combine them into product summary strings.	Name - Price strings
            string[] productNameList = { "Product 01", "Product 02", "Product 03" };
            int[] productPriceList = { 500, 1000, 800 };
            var productSummary = productNameList.Zip(productPriceList, (n, p) => $"{n} - {p}");
            Console.WriteLine("42. Product summary strings: ");
            foreach (string ps in productSummary)
            {
                Console.WriteLine($"    {ps}");
            }

            //43. (OrderBy + Take) Given products with sales count.
            // Return top 5 best - selling products.Top 5 products
            var productWithSalesCount = new[]
            {
                new{Id=1,Name ="Product 01", SalesCount = 10 },
                new{Id=2,Name ="Product 02", SalesCount = 50 },
                new{Id=3,Name ="Product 03", SalesCount = 100 },
                new{Id=4,Name ="Product 04", SalesCount = 500 },
                new{Id=5,Name ="Product 05", SalesCount = 350 },
                new{Id=6,Name ="Product 06", SalesCount = 1000 },
                new{Id=7,Name ="Product 07", SalesCount = 200 },
            };
            var bestSalling = productWithSalesCount.OrderByDescending(p => p.SalesCount).Take(5).ToList();
            Console.WriteLine("43. Top 5 best - selling products: ");
            foreach (var bs in bestSalling)
            {
                Console.WriteLine($"    Product: {bs.Name}, Sales Count: {bs.SalesCount}");
            }


            //44. (GroupBy + Where) Given orders grouped by customer.
            //Return customers with more than 3 orders.Frequent customers
            var customerOrderList = new[]
            {
                new { CustomerId = 1, CustomerName = "Customer 01", OrderId = 1},
                new { CustomerId = 1, CustomerName = "Customer 01", OrderId = 2},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 4},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 5},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 6},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 7},
            };
            var customersHasMore3Orders = customerOrderList.GroupBy(c => c.CustomerName).Where(g => g.Count() > 3).Select(g => g.Key).ToList();
            Console.WriteLine("44. Customers with more than 3 orders: ");
            foreach (var c in customersHasMore3Orders)
            {
                Console.WriteLine($"    Customer Name: {c}");
            }


            //45. (Date Filtering) Given invoices with DueDate and IsPaid.
            //Return overdue unpaid invoices.	Invoices due before today and unpaid
            var invoiceList = new[]
            {
                new { DueDate= new DateTime(2026, 5, 5), IsPaid = true },
                new { DueDate= new DateTime(2026, 5, 5), IsPaid = false },
                new { DueDate= new DateTime(2026, 6, 6), IsPaid = false },
                new { DueDate= new DateTime(2026, 4, 3), IsPaid= true },
            };
            var overdue = invoiceList.Where(invoice => !invoice.IsPaid && invoice.DueDate < DateTime.Today).ToList();
            Console.WriteLine("45. Overdue unpaid invoices: ");
            foreach (var o in overdue)
            {
                Console.WriteLine($"    Due Date: {o.DueDate}");
            }


            //46. (String Filtering) Given employees with Email.
            //Return employees whose email domain is "company.com".Matching employees
            var matchingEmployeeEmail = employeeData.Where(e => e.Email.EndsWith("company.com")).ToList();
            Console.WriteLine("45. Employees whose email domain is \"company.com\": ");
            foreach (var e in matchingEmployeeEmail)
            {
                Console.WriteLine($"    Employee: {e.Name}, Email: {e.Email}");
            }


            //47. (Pagination)  Given products.	Return page 3 with page size 20 using Skip and Take.Items 41 - 60
            var productSize = Enumerable.Range(1, 100); //Just for test
            var pageNumber = 3;
            var pageSize = 20;
            //var thirdPage = productSize.Skip(2 * 20).Take(pageSize).ToList();
            var thirdPage = productSize.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            Console.WriteLine($"47. Page 3 with page size 20: {thirdPage.Count}");


            //48. (Select) Index Given a list of names.	
            //Return each name with its position number.Index + Name
            var nameList = new List<string> { "Esraa", "Mohamed", "Ahmed", "Fathy" };
            var nameWithPosition = nameList.Select((name, index) => new { Index = index, Name = name }).ToList();
            Console.WriteLine("48. Each name with its position: ");
            foreach (var n in nameWithPosition)
            {
                Console.WriteLine($"    Index: {n.Index} , Name: {n.Name}");
            }

            //49. (DefaultIfEmpty)  Given departments and employees.	
            //Return departments even if they have no employees.Department + employee / null
            var departmentEmployees = from d in departments
                                      join e in EmployeeList
                                      on d.Id equals e.DepartmentId
                                      into grouped
                                      from g in grouped.DefaultIfEmpty()
                                      select new { d.Name, Employee = g?.Name };
            Console.WriteLine("49. departments even if they have no employees: ");
            foreach (var d in departmentEmployees)
            {
                Console.WriteLine($"    Department: {d.Name} , Employee: {d.Employee}");
            }


            //50. (Reverse) Given recent search terms.
            //Return search terms from newest to oldest after original oldest-to -newest input.Reversed sequence
            var searchTerms = new List<string> { "Text", "Prod", "Hello" };
            var reversed = searchTerms.AsEnumerable().Reverse().ToList();
            Console.Write("50. Return search terms from newest to oldest: ");
            foreach (var r in reversed)
            {
                Console.Write($"{r} ");
            }
            Console.WriteLine();

            //51. (Multi-level GroupBy) Given orders with CustomerId, Year, and Total.	
            //Calculate total sales per customer per year.	CustomerId + Year + TotalSales
            var customerOrderList2 = new[]
            {
                new { CustomerId = 1, CustomerName = "Customer 01", OrderId = 1, Year = 2023, Total = 5000},
                new { CustomerId = 1, CustomerName = "Customer 01", OrderId = 2, Year = 2025, Total = 2500},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 4, Year = 2023, Total = 100000},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 5, Year = 2022, Total = 3500},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 6, Year = 2024, Total = 500},
                new { CustomerId = 2, CustomerName = "Customer 02", OrderId = 7, Year = 2026, Total = 1000},
            };
            var multiGroupResult = customerOrderList2.GroupBy(x => new { x.CustomerId, x.Year }).Select(g => new { Id = g.Key.CustomerId, Year = g.Key.Year, TotalSaled = g.Sum(x => x.Total) }).ToList();
            Console.WriteLine("51. Total sales per customer per year: ");
            foreach (var m in multiGroupResult)
            {
                Console.WriteLine($"    Id: {m.Id}, Total Sales = {m.TotalSaled} ");
            }


            //52. (Join + GroupBy)  Given products, categories, and order lines.	
            //Calculate total revenue per category.CategoryName + Revenue
            var categories = new[]
            {
                new {Id = 1, Name = "Category 01"},
                new {Id = 2, Name = "Category 02"},
                new {Id = 3, Name = "Category 03"}
            };

            var productHasCategories = new[]  {
                new {Id= 1, Name = "Product 01", CategoryId = 2, Price = 1000},
                new {Id= 2, Name = "Product 02", CategoryId = 1, Price = 500},
                new {Id= 3, Name = "Product 03", CategoryId = 3, Price = 5000},
                new {Id= 4, Name = "Product 04", CategoryId = 1, Price = 5000}
            };

            var orderLines = new[]  {
                new {Id= 1, ProductId = 2, Quantity = 1, Price = 570},
                new {Id= 2, ProductId = 1, Quantity = 5, Price = 5500},
                new {Id= 3, ProductId = 3, Quantity = 4, Price = 21000},
                new {Id= 4, ProductId = 4, Quantity = 2, Price = 1200}
            };

            var categoryTotalRevenu = orderLines
                .Join(productHasCategories, ol => ol.ProductId, p => p.Id, (ol, p) => new { ol, p })
                .Join(categories, previousData => previousData.p.CategoryId, c => c.Id, (previousData, c) => new
                {
                    CategoryName = c.Name,
                    Revenu = previousData.ol.Quantity * previousData.ol.Price
                }).GroupBy(c => c.CategoryName).Select(v => new
                {
                    CategoryName = v.Key,
                    TotalRevenu = v.Sum(c => c.Revenu)
                });
            Console.WriteLine("52. Total revenue per category: ");
            foreach (var item in categoryTotalRevenu)
            {
                Console.WriteLine($"    CategoryName: {item.CategoryName} | Total Revenu: {item.TotalRevenu}");
            }


            //53. (Nested SelectMany + GroupBy) Given customers with nested orders and lines.
            //Find the most purchased product per customer.Customer + Product + Quantity
            var cnOrders = new[]
                {
                    new {
                        Name = "Alice",
                        Orders = new[] {
                            new { Lines = new[] { (Product: "Laptop", Quantity: 1), (Product: "Mouse", Quantity: 2) } },
                            new { Lines = new[] { (Product: "Mouse", Quantity: 3) } }
                        }
                    },
                    new {
                        Name = "Bob",
                        Orders = new[] {
                            new { Lines = new[] { (Product: "Keyboard", Quantity: 2), (Product: "Monitor", Quantity: 1) } },
                            new { Lines = new[] { (Product: "Keyboard", Quantity: 1) } }
                        }
                    }
                };

            var mostPurchasedProduct = cnOrders.Select(c => new
            {
                Customer = c.Name,
                Product = c.Orders
                .SelectMany(o => o.Lines)
                .GroupBy(x => x.Product)
                .OrderByDescending(g => g.Sum(x => x.Quantity))
                .FirstOrDefault()
            });
            Console.WriteLine("53. Most purchased product per customer: ");
            foreach (var item in mostPurchasedProduct)
            {
                Console.WriteLine($"    Customer: {item.Customer} | Product: {item.Product?.Key}");
            }

            //54. (Aggregate) Given bank transactions with Credit and Debit.
            //Calculate running balance using Aggregate.Final balance or running list
            var bankTransactions = new[]
            {
                new { LineId = 1, Type = "Credit", Amount = 1000.00m },
                new { LineId = 2, Type = "Debit", Amount = 400.00m },
                new { LineId = 3, Type = "Credit", Amount = 850.00m },
                new { LineId = 4, Type = "Debit", Amount = 50.00m }
            };

            decimal finalBalance = bankTransactions.Aggregate(0m, (total, n) =>
            (n.Type == "Credit") ? total + n.Amount : total - n.Amount
            );
            Console.WriteLine($"54. Running balance using Aggregate: {finalBalance}");

            //55. (Custom Projection) Given employees with Salary and BonusPercentage.
            //Return employees with calculated annual compensation.	Name + AnnualCompensation
            var emplyeesWithBonus = new[]
            {
                new { Id = 1, Name = "Employee 01", Salary = 5000, BonusPercentage = 10},
                new { Id = 2, Name = "Employee 02", Salary = 10000, BonusPercentage = 30},
                new { Id = 3, Name = "Employee 03", Salary = 2500, BonusPercentage = 15},
                new { Id = 4, Name = "Employee 04", Salary = 50000, BonusPercentage = 20}
            };
            var calculateAnnualCompensation = emplyeesWithBonus.Select(e => new
            {
                e.Name,
                AnnualCompensation = (e.Salary * 12) + (e.Salary * e.BonusPercentage)
            }).ToList();
            Console.WriteLine("55. employees with calculated annual compensation: ");
            foreach (var e in calculateAnnualCompensation)
            {
                Console.WriteLine($"    Employee: {e.Name}, Annual Compensation = {e.AnnualCompensation} ");
            }

            //56. (GroupBy + Ranking)   Given salespeople with monthly sales.
            //Rank salespeople by total sales.Rank + Salesperson + Total
            var salesPeople = new[]
            {
                new {Name = "Ahmed Ahmed", sales = 50000},
                new {Name = "Mohamed Fahmy", sales = 50000},
                new {Name = "Ahmed Ahmed", sales = 75000},
                new {Name = "Ahmed Ahmed", sales = 100000},
                new {Name = "Mohamed Fahmy", sales = 800000},
                new {Name = "Mohamed Fahmy", sales = 500000},
            };
            var rankSalesPeople = salesPeople.GroupBy(s => s.Name).Select(g => new
            {
                Name = g.Key,
                Total = g.Sum(p => p.sales)
            }).OrderByDescending(t => t.Total).Select((n, index) =>
            new
            {
                n.Name,
                n.Total,
                Rank = index + 1
            }).ToList();
            Console.WriteLine("56. total sales.Rank + Salesperson + Total ");
            foreach (var r in rankSalesPeople)
            {
                Console.WriteLine($"     Ranks: {r.Rank} , Name: {r.Name}, Total: {r.Total}");
            }


            //57. (Window-like Query) Given ordered sensor readings.
            //Find readings where value increased compared with previous reading.Pairs or readings with increase


            //58. (Duplicate Detection) Given orders with OrderNumber.
            //Find duplicate order numbers and their counts.OrderNumber + Count
            var orderNumbers = new[]
            {
                new { OrderNumber = 2 , Count = 2},
                new { OrderNumber = 3 , Count = 4},
                new { OrderNumber = 3 , Count = 2},
                new { OrderNumber = 2 , Count = 1},
                new { OrderNumber = 1 , Count = 5}
            };

            var detectDuplicateOrder = orderNumbers.GroupBy(on => on.OrderNumber).Where(g => g.Count() > 1).Select(g => new
            {
                OrderNumber = g.Key,
                Count = g.Sum(c => c.Count)
            }).ToList();
            Console.WriteLine("58. duplicate order numbers and their counts.OrderNumber + Count");
            foreach (var d in detectDuplicateOrder)
            {
                Console.WriteLine($"    Order Number: {d.OrderNumber}, Count: {d.Count}");
            }


            //59. (Complex Filter) Given tasks with Priority, DueDate, and Status.	
            //Return high-priority overdue tasks that are not completed.	Filtered tasks
            var tasks = new[]
            {
                new { Id = 1, Name = "Task 01", Priority = "High", DueDate = new DateTime(2026,5,5), Status = "Pending"},
                new { Id = 2, Name = "Task 02", Priority = "Meduim", DueDate = new DateTime(2026,6,12), Status = "In Progress"},
                new { Id = 3, Name = "Task 03", Priority = "High", DueDate = new DateTime(2026,5,12), Status = "Completed"}
            };

            var overdueTasks = tasks.Where(t => t.Priority == "High" && t.DueDate < DateTime.Today && t.Status != "Completed").ToList();
            Console.WriteLine("59. high-priority overdue tasks that are not completed ");
            foreach (var t in overdueTasks)
            {
                Console.WriteLine($"    Task: {t.Name}, Status: {t.Status}, OverDue: {t.DueDate} ");
            }

            //60. (Top N Per Group) Given products with Category and Sales.
            //Return top 3 products by Sales in each category.	Category + top 3 products
            var productCategoryWithSalesCount = new[]
            {
                new{Id=1,Name ="Product 01", Category = "Category 01", Sales = 10 },
                new{Id=2,Name ="Product 02", Category = "Category 02", Sales = 50 },
                new{Id=3,Name ="Product 03", Category = "Category 03", Sales = 100 },
                new{Id=4,Name ="Product 04", Category = "Category 01", Sales = 500 },
                new{Id=5,Name ="Product 05", Category = "Category 02", Sales = 350 },
                new{Id=6,Name ="Product 06", Category = "Category 03", Sales = 1000 },
                new{Id=7,Name ="Product 07", Category = "Category 01", Sales = 200 },
            };

            var CategoryWithTopThreeProducts = productCategoryWithSalesCount.GroupBy(t => t.Category).Select(p => new
            {
                Category = p.Key,
                Products = p.OrderByDescending(g => g.Sales).Take(3)
            });

            Console.WriteLine("60. high-priority overdue tasks that are not completed ");
            foreach (var c in CategoryWithTopThreeProducts)
            {
                Console.WriteLine($"    Category: {c.Category}");
                foreach (var p in c.Products)
                {
                    Console.WriteLine($"    Product Name: {p.Name}, Sales= {p.Sales}");
                }
            }

            //61. (Left Join) Given customers and orders.
            //Return all customers with last order date, or null if no orders.Customer + LastOrderDate
            var ordersWithDates = new[]
            {
                new { CustomerId = 1, OrderDate = new DateTime(2026, 5, 5)},
                new { CustomerId = 2, OrderDate = new DateTime(2026, 6, 15)},
                new { CustomerId = 3, OrderDate = new DateTime(2026, 4, 14)},
                new { CustomerId = 1, OrderDate = new DateTime(2026, 5, 16)},
            };
            var CustomersWithLastOrder = from c in customers
                                         join o in ordersWithDates
                                         on c.Id equals o.CustomerId
                                         into grouped
                                         select new
                                         {
                                             CustomerName = c.Name,
                                             LastOrderDate = grouped.Max(g => g?.OrderDate)
                                         };

            Console.WriteLine("61. all customers with last order date ");
            foreach (var c in CustomersWithLastOrder)
            {
                Console.WriteLine($"    Customer Name: {c.CustomerName}, Last Order Date: {c.LastOrderDate}");
            }


            //62. (Right-like Join) Given employees and submitted timesheets.	
            //Find timesheets submitted by unknown employee IDs.
            //Invalid timesheets
            var timesheets = new[]
            {
                new { EmployeeId = 1, TimeSheetNo = 1},
                new { EmployeeId = 6, TimeSheetNo = 2},
                new { EmployeeId = 2, TimeSheetNo = 3},
                new { EmployeeId = 3, TimeSheetNo = 4},
                new { EmployeeId = 9, TimeSheetNo = 5}
            };
            var invalidTimesheets = timesheets.Where(t => !employees.Any(e => e.Id == t.EmployeeId));
            Console.Write("62. Invalid Timesheets: ");
            foreach (var i in invalidTimesheets)
            {
                Console.Write($" {i.TimeSheetNo}, ");
            }
            Console.WriteLine();

            //63. (Anti Join) Given expected shipments and received shipments.
            //Find expected shipments not received.Missing shipments
            var expectedShipments = new List<int> { 1, 2, 3, 4, 5 };
            var receivedShipments = new List<int> { 3, 5 };
            var missedShipments = expectedShipments.Except(receivedShipments).ToList();
            Console.Write("63. Missing shipments: ");
            foreach (var m in missedShipments)
            {
                Console.Write($" {m}, ");
            }
            Console.WriteLine();

            //64. (Semi Join) Given customers and orders.
            //Return customers who placed orders without duplicating customers.	Customers with orders
            var distincitCustomers = customers.Where(c => customerOrders.Any(O => O.CustomerId == c.Id)).ToList();
            Console.WriteLine("64. Customers who placed orders without duplicating customers: ");
            foreach (var dc in distincitCustomers)
            {
                Console.WriteLine($"    Customer Name: {dc.Name}");
            }

            //65. (Conditional Aggregation) Given orders with Status and Total.
            //Calculate total paid amount and total pending amount in one projection.	PaidTotal + PendingTotal
            var ordersWithStatusAndTotal = new[]
            {
                new { Id = 1, Status = "Pending", Total = 1000},
                new { Id = 2, Status = "Paid", Total = 1500},
                new { Id = 3, Status = "Pending", Total = 2000},
                new { Id = 4, Status = "Paid", Total = 3000}
            };
            var totalAmounts = new
            {
                PaidAmount = ordersWithStatusAndTotal.Where(o => o.Status == "Paid").Sum(s => s.Total),
                PendingAmount = ordersWithStatusAndTotal.Where(o => o.Status == "Pending").Sum(s => s.Total)
            };
            Console.WriteLine("65. total paid amount and total pending amount in one projection: ");
            Console.WriteLine($"    Paid Amount: {totalAmounts.PaidAmount},  Pending Amount: {totalAmounts.PendingAmount}");

            //66. (Date Grouping) Given log entries with Timestamp.	
            //Group logs by day and count errors per day.Date + ErrorCount
            var logEntries = new[]
            {
                new { Timestamp = new DateTime(2026,5,5), IsError = true},
                new { Timestamp = new DateTime(2026,5,5), IsError = true},
                new { Timestamp = new DateTime(2026,5,1), IsError = false},
                new { Timestamp = new DateTime(2026,5,2), IsError = true},
                new { Timestamp = new DateTime(2026,5,4), IsError = false},
            };

            var logs = logEntries.GroupBy(l => l.Timestamp.Date).Select(g => new
            {
                Date = g.Key,
                ErrorCount = g.Count(x => x.IsError)
            });
            Console.WriteLine("66. Group logs by day and count errors per day.Date + ErrorCount :");
            foreach (var log in logs)
            {
                Console.WriteLine($"    Date: {log.Date}, Error Count: {log.ErrorCount}");

            }

            //67. (String Grouping) Given emails.
            //Group users by email domain and count each domain.Domain + Count
            var usersEmails = new[]
            {
                new {userName = "Esraa", Email = "esraa@gmail.com"},
                new {userName = "Tota", Email = "tota@gmail.com"},
                new {userName = "Ahmed", Email = "ahmed@gmail.com"},
                new {userName = "Mohamed", Email = "mohamed@outlook.com"},
                new {userName = "Ali", Email = "ali@outlook.com"}
            };
            var emailDomains = usersEmails.GroupBy(u => u.Email.Split('@')[1]).Select(g => new
            {
                Domain = g.Key,
                Count = g.Count()
            });
            Console.WriteLine("67. Group users by email domain and count each domain:");
            foreach (var ed in emailDomains)
            {
                Console.WriteLine($"    Domain: {ed.Domain}, Count: {ed.Count}");
            }

            //68. (Nested Quantifiers) Given projects with tasks and subtasks.
            //Return projects where every task has at least one completed subtask.Matching projects
            var projects = new[]
            {
                new
                {
                    Id = 1,
                    Name = "Website Redesign",
                    Tasks = new[]
                    {
                        new
                        {
                            Id = 101,
                            Title = "Frontend Development",
                            SubTasks = new[]
                            {
                                new { Id = 1001, Title = "Create landing page template", IsCompleted = true },
                                new { Id = 1002, Title = "Implement dark mode switch", IsCompleted = false }
                            }
                        },
                        new
                        {
                            Id = 102,
                            Title = "Backend API",
                            SubTasks = new[]
                            {
                                new { Id = 1003, Title = "Setup authentication endpoints", IsCompleted = true },
                                new { Id = 1004, Title = "Integrate payment gateway", IsCompleted = false }
                            }
                        }
                    }
                },
                new
                {
                    Id = 2,
                    Name = "Mobile App Launch",
                    Tasks = new[]
                    {
                        new
                        {
                            Id = 201,
                            Title = "Marketing Campaign",
                            SubTasks = new[]
                            {
                                new { Id = 2001, Title = "Draft press release", IsCompleted = false },
                                new { Id = 2002, Title = "Schedule social media teaser posts", IsCompleted = true }
                            }
                        },
                        new
                        {
                            Id = 202,
                            Title = "App Store Submission",
                            SubTasks = new[]
                            {
                                new { Id = 2003, Title = "Generate promotional screenshots", IsCompleted = false }
                            }
                        }
                    }
                }
            };

            var filteredProjects = projects.Where(p => p.Tasks.All(t => t.SubTasks.Any(s => s.IsCompleted))).ToList();
            Console.WriteLine("68. projects where every task has at least one completed subtask:");
            foreach (var fp in filteredProjects)
            {
                Console.WriteLine($"    Project: {fp.Name}");
            }


            //69. (Set Operations) Given users assigned to RoleA, RoleB, and RoleC.
            //Find users in RoleA and RoleB but not RoleC.	Target user IDs
            var roleAUserIds = new List<int> { 1, 3, 4, 5, 8 };
            var roleBUserIds = new List<int> { 1, 3, 4, 8, 9, 10 };
            var roleCUserIds = new List<int> { 1, 5, 7 };

            var filteredUsersRoles = roleAUserIds.Intersect(roleBUserIds).Except(roleCUserIds).ToList();
            Console.Write("69. users in RoleA and RoleB but not RoleC: ");
            foreach (int id in filteredUsersRoles)
            {
                Console.Write($"{id}    ");
            }
            Console.WriteLine();


            //70. (Performance Awareness) Given IQueryable<Order>.
            //Write a query that filters before projecting to avoid loading unnecessary data.	
            //Efficient query expression
            var iOrders = new[]
                {
                    new
                    {
                        Id = 1,
                        TotalAmount = 1000,
                        Status = "Shipped"
                    },
                    new
                    {
                        Id = 2,
                        TotalAmount = 500,
                        Status = "Pending"
                    }
                }.AsQueryable();
            var filteredIOrders = iOrders.Where(x => x.TotalAmount > 500).Select(x => new
            {
                x.Id,
                x.TotalAmount
            });
            Console.WriteLine("70. filters before projecting to avoid loading unnecessary data:");
            foreach (var fo in filteredIOrders)
            {
                Console.WriteLine($"    OrderId: {fo.Id}, Total Amount: {fo.TotalAmount}");
            }

            //71. (Deferred Execution) Given a LINQ query over a mutable list.
            //Predict output before and after adding an item before enumeration.
            //	Explain result

            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var query = list.Where(num => num > 2);

            Console.WriteLine("71. Predict output before and after adding an item before enumeration:");
            foreach (int num in query) { Console.Write($"    {num}"); }
            list.Add(15);

            Console.WriteLine("");
            foreach (int num in query) { Console.Write($"    {num}"); } //it displays the new adding number
            Console.WriteLine();

            //72. (Immediate Execution) Given a query followed by ToList().
            //Predict output after modifying the source list.
            var immediateExecution = list.Where(num => num > 2).ToList();
            Console.WriteLine("72. Predict output after modifying the source list:");
            foreach (int num in immediateExecution) { Console.Write($"    {num}"); }

            list.Add(20);

            Console.WriteLine("");
            foreach (int num in immediateExecution) { Console.Write($"    {num}"); } //it doesn't display the new adding number
            Console.WriteLine();


            //73. (IQueryable vs IEnumerable) Given EF Core DbSet Orders.
            //Identify which parts of the query execute in SQL and which execute in memory.
            var orderQuery = orders.Where(x => x.Total > 100); //lets consider that orders from database and this is from type IQueryable
            var result = orderQuery.AsEnumerable().Where(x => x.Total > 20);
            Console.WriteLine("73. IQueryable Filter data in Database but IEnumerable get the all data and filter it in the memory");


            //74. (Null Handling) Given customers where Orders may be null.
            //Return customers with safe order count without throwing NullReferenceException.	
            //Customer + SafeOrderCount
            var customerWithSafeOrderCount = customersOrders.Select(x => new
            {
                x.Name,
                SafeOrderCount = x.Orders?.Count()
            });
            Console.WriteLine("74. Customers with safe order count without throwing NullReferenceException:");
            foreach (var c in customerWithSafeOrderCount)
            {
                Console.WriteLine($"    Customer Name: {c.Name}, Safe Order Count: {c.SafeOrderCount}");
            }


            //75. (Multiple Joins) Given Orders, Customers, and Employees.
            //	Return order summaries with customer name and sales rep name.	
            //	OrderId + Customer + Rep
            var ordersData = new[]
                {
                    new {
                        OrderId = 1001,
                        CustomerId = 1,
                        EmployeeId = 2,
                        OrderDate = DateTime.Today.AddDays(-5),
                        Items = new[]
                        {
                            new { Product = "Laptop", Price = 1200m },
                            new { Product = "Mouse", Price = 25m }
                        }
                    },
                    new {
                        OrderId = 1002,
                        CustomerId = 2,
                        EmployeeId = 1,
                        OrderDate = DateTime.Today.AddDays(-2),
                        Items = new[]
                        {
                            new { Product = "Keyboard", Price = 75m }
                        }
                    },
                    new {
                        OrderId = 1003,
                        CustomerId = 1,
                        EmployeeId = 3,
                        OrderDate = DateTime.Today,
                        Items = new[] { new { Product = "", Price = 0m } }.Where(x => false).ToArray()
                    }
                };
            var filteredOrders = from o in ordersData
                                 join c in customers
                                 on o.CustomerId equals c.Id
                                 join e in employees
                                 on o.EmployeeId equals e.Id
                                 select new
                                 {
                                     OrderId = o.OrderId,
                                     CustomerName = c?.Name,
                                     EmployeeName = e?.Name
                                 };
            Console.WriteLine("75. Return order summaries with customer name and sales rep name:");
            foreach (var fo in filteredOrders)
            {
                Console.WriteLine($"    Order Id= {fo.OrderId}, Customer Name: {fo.CustomerName}, Employee Name: {fo.EmployeeName}");
            }


            //76. (GroupBy + HAVING style) Given invoices with CustomerId and Amount.
            //Return customers whose total invoices exceed 10000.CustomerId + Total
            var customersInvoices = new[]
            {
                new {CustomerId = 1, Amount = 25000},
                new {CustomerId = 2, Amount = 10000},
                new {CustomerId = 3, Amount = 20000},
                new {CustomerId = 1, Amount = 50000},
            };
            var filteredCustomersInvoices = customersInvoices.GroupBy(c => c.CustomerId)
                .Select(g => new
                {
                    CustomerId = g.Key,
                    TotalAmount = g.Sum(x => x.Amount),
                }).Where(i => i.TotalAmount > 10000);
            Console.WriteLine("76. customers whose total invoices exceed 10000:");
            foreach (var fo in filteredCustomersInvoices)
            {
                Console.WriteLine($"    Customer Id: {fo.CustomerId}, Total Amount: {fo.TotalAmount}");
            }


            //77. (Dynamic Query) Given optional filters: category, minPrice, maxPrice.
            //Build a query that applies only provided filters.	Filtered products
            decimal? minPrice = 500m;
            decimal? maxPrice = null;
            string? category = null;
            var productList3 = new[]
            {
                new { Category = "Category 01", Price = 200},
                new { Category = "Category 02", Price = 500},
                new { Category = "Category 03", Price = 1000}
            };

            var filteredProducts = productList3.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                filteredProducts = filteredProducts.Where(x => x.Category == category);

            if (minPrice.HasValue)
                filteredProducts = filteredProducts.Where(x => x.Price >= minPrice);

            if (maxPrice.HasValue)
                filteredProducts = filteredProducts.Where(x => x.Price <= maxPrice);
            Console.WriteLine("77. Query that applies only provided filters:");
            foreach (var fo in filteredProducts)
            {
                Console.WriteLine($"   Category: {fo.Category}, Price: {fo.Price}");
            }


            //78. (Expression Reuse) Given a reusable predicate for active customers.	
            //Use it in a LINQ query without duplicating logic.Clean reusable filter


            //79. (Hierarchical Flattening) Given departments with teams and employees.
            //Flatten into rows: Department, Team, Employee.Flat row list
            var departmentsTeams = new[]
            {
                new {
                    Name = "Department 01",
                    Teams = new []
                        {
                            new { Name = "Team 01",
                            Employees = new[]
                            {
                                new { Name= "Employee 01"},
                                new { Name= "Employee 02"}
                            }
                        }
                    }
                },
                  new {
                    Name = "Department 02",
                    Teams = new []
                        {
                            new { Name = "Team 02",
                            Employees = new[]
                            {
                                new { Name= "Employee 03"},
                                new { Name= "Employee 04"}
                            }
                        }
                    }
                }
            };
            var flattenRows = departmentsTeams.SelectMany(d => d.Teams, (d, t) => new { d, t })
                .SelectMany(x => x.t.Employees, (x, e) => new
                {
                    Department = x.d.Name,
                    Team = x.t.Name,
                    Employee = e.Name
                });

            Console.WriteLine("79. Flatten into rows: Department, Team, Employee:");
            foreach (var fr in flattenRows)
            {
                Console.WriteLine($"   Department: {fr.Department}, Team: {fr.Team}, Employee: {fr.Employee}");
            }

            //80. (Cartesian Product) Given colors and sizes.
            //Generate all product variants using SelectMany.Color + Size combinations
            var colors = new[] { Color.Red, Color.Black };
            var sizes = new[] { "sm", "lg" };
            var combinations = colors.SelectMany(c => sizes, (c, s) => new
            {
                Color = c,
                Size = s
            });

            Console.WriteLine("80. All product variants using SelectMany.Color + Size combinations");
            foreach (var c in combinations)
            {
                Console.WriteLine($"   Color: {c.Color}, Size: {c.Size}");
            }

            //81. (EF Core Translation) Given a LINQ query using a custom C# method inside Where.	
            //Explain why it may fail in EF Core and rewrite it using translatable expressions.	Correct EF-safe query
            Console.WriteLine("81. EF Core Translation");
            bool CustomMethod(string name) => name.StartsWith("P");
            var efBad = products.Where(x => CustomMethod(x.Name));   // Bad in EF Core
            var efSafe = products.Where(x => x.Name.StartsWith("P"));// Good in EF Core

            foreach (var item in efSafe)
                Console.WriteLine($"    Product Name: {item.Name}");


            //82. (N+1 Avoidance) Given customers and orders in EF Core.	
            //Write a query / projection that avoids N + 1 queries while returning order counts.	
            //Single efficient projection
            Console.WriteLine("82. Avoids N + 1 queries while returning order counts");
            var custOrdersCount = customers.Select(c => new
            {
                c.Name,
                OrderCount = customerOrderList.Count(o => o.CustomerId == c.Id)
            });
            foreach (var item in custOrdersCount)
                Console.WriteLine($"    Customer Name: {item.Name}, Orders Count: {item.OrderCount}");
        }
    }
}
