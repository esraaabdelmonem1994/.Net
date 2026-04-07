using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member
    {
        public string Name { get; set; }
        public int MemberId { get; set; }

        private List<Book> borrowedBooks = new List<Book>();

        public Member(string name, int id)
        {
            Name = name;
            MemberId = id;
        }

        public void BorrowBook(Book book)
        {
            if (!book.IsAvailable)
            {
                Console.WriteLine("Book is already borrowed.");
                return;
            }

            if (borrowedBooks.Count >= 3)
            {
                Console.WriteLine("Cannot borrow more than 3 books.");
                return;
            }

            book.IsAvailable = false;
            borrowedBooks.Add(book);
            Console.WriteLine($"{Name} borrowed {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            if (borrowedBooks.Contains(book))
            {
                book.IsAvailable = true;
                borrowedBooks.Remove(book);
                Console.WriteLine($"{Name} returned {book.Title}");
            }
            else
            {
                Console.WriteLine("This book was not borrowed by the member.");
            }
        }
    }
}
