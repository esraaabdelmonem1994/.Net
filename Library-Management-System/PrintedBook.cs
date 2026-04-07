using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class PrintedBook : Book
    {
        public int CopiesNumber { get; set; }
        public PrintedBook(string title, string author, string isbn, int copiesNumber) : base(title, author, isbn)
        {
            CopiesNumber = copiesNumber;
        }

        public override void DisplayBookInfo()
        {
            Console.WriteLine($"[EBook] Title: {Title}, Author: {Author}, Copies Number: {CopiesNumber}, Available: {IsAvailable}");
        }
    }
}
