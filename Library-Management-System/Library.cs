using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        public Book FindBook(string isbn)
        {
            return books.Find(book => book.ISBN == isbn);
        }
        public void RegisterMember(Member member)
        {
            members.Add(member);
            Console.WriteLine("Member registered successfully.");
        }

        public Member FindMember(int id)
        {
            return members.Find(member => member.MemberId == id);
        }
        public void ShowAllBooks()
        {
            Console.WriteLine("All Books");
            foreach (var item in books)
            {
                Console.WriteLine($"Title: {item.Title}, Author: {item.ISBN}, Author: {item.ISBN}, IsAvailable: {item.IsAvailable}");
            }
        }
        public void ShowAvailableBooks()
        {
            Console.WriteLine("Available Books");
            foreach (var item in books)
            {
                if (!item.IsAvailable) return;

                Console.WriteLine($"Title: {item.Title}, Author: {item.ISBN}, Author: {item.ISBN}, IsAvailable: {item.IsAvailable}");
            }
        }
    }
}
