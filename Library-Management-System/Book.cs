using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book
    {
        private string title;
        private string author;
        private string isbn;
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string ISBN { get { return isbn; } set { isbn = value; } }
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public virtual void DisplayBookInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {ISBN}, Author: {ISBN}, IsAvailable: {IsAvailable}");
        }
    }
}
