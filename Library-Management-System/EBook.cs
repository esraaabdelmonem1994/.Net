using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class EBook : Book
    {
        public double FileSize { get; set; }
        public EBook(string title, string author, string isbn, double fileSize) : base(title, author, isbn)
        {
            FileSize = fileSize;
        }

        public override void DisplayBookInfo()
        {
            Console.WriteLine($"[EBook] Title: {Title}, Author: {Author}, Size: {FileSize}MB, Available: {IsAvailable}");
        }
    }
}
