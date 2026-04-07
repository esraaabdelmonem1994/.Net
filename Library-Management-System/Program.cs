namespace Library_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new();

            while (true)
            {
                Console.WriteLine("\n===== Library Menu =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Register Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Show All Books");
                Console.WriteLine("6. Show Available Books");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Book Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Book Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Book ISBN: ");
                        string isbn = Console.ReadLine();

                        library.AddBook(new Book(title, author, isbn));
                        break;
                    case 2:
                        Console.Write("Member Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Member ID: ");
                        int id = int.Parse(Console.ReadLine());

                        library.RegisterMember(new Member(name, id));
                        break;
                    case 3:
                        Console.Write("Member ID: ");
                        int mId = int.Parse(Console.ReadLine());

                        Console.Write("Book ISBN: ");
                        string bisbn = Console.ReadLine();

                        var member = library.FindMember(mId);
                        var book = library.FindBook(bisbn);

                        if (member != null && book != null)
                            member.BorrowBook(book);
                        else
                            Console.WriteLine("Invalid member or book.");
                        break;

                    case 4:
                        Console.Write("Member ID: ");
                        int rmId = int.Parse(Console.ReadLine());

                        Console.Write("Book ISBN: ");
                        string rbIsbn = Console.ReadLine();

                        var rMember = library.FindMember(rmId);
                        var rBook = library.FindBook(rbIsbn);

                        if (rMember != null && rBook != null)
                            rMember.ReturnBook(rBook);
                        else
                            Console.WriteLine("Invalid member or book.");
                        break;

                    case 5:
                        library.ShowAllBooks();
                        break;

                    case 6:
                        library.ShowAvailableBooks();
                        break;

                    case 0:
                        return;
                }
            }
        }
    }
}
