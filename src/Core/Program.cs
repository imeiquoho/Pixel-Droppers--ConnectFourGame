using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment_01_solution
{
    class Book  /* Note: The book class is complete. You may not change this class.*/
    {
        public string BookName { get; set; } //only book name alone is not unique
        public int Serial { get; set; } //Togather, book name and serial is unique
        public bool Status { get; set; } = false; //false means the book is available for renting

        public Book(string name, int serial)
        {
            BookName = name;
            Serial = serial;
        }
        public bool Available()
        {
            //returns true if a book is available
            if (!Status)
                return true;
            return false;
        }
        public bool Rent()
        {
            if (Status == false)
            {
                //A book can only be rented if it's rental status is false
                Status = true;
                return true;
            }
            return false; //otherwise, the book is not available.  
        }

        public bool Return()
        {
            if (Status == true)
            {
                //A book can be only returned if it is already rented.
                Status = false;
                return true;
            }
            else
            {
                // Status false means, the book is available in the store. (already returned)
                return false;
            }
        }
        public void BookInfo()
        {
            //Show name of the book, it's serial and rental status.
            Console.WriteLine("Book Name: {0}, Serial: {1}, Status: {2}", BookName, Serial, Status == true ? "Rented" : "Available");
        }
    }

    class Reader
    {
        //Fields/Properties are already provided to you.
        public string ReaderName { get; set; }
        public List<Book> readersBookList; //readers book list that will contain all books rented by that reader.
        public Reader(string name)
        {
            // The Reader Constructor is complete.
            ReaderName = name;
            readersBookList = new List<Book>();   //initialize empty book list 
        }
        public void RentABook(Book book)
        {
            //ToDo
            //user is allowed to rent maximum two books at a time.
            //issue error message, if users want to rent more than two books.
            /*
             * Example: 
             * if (readersBookList.Count >= 2)
             * {
             *   Display "You cannot rent more than two books!"  
             * }
             * else{
             *  //ToDo
             * Rent the book if available, display confirmation message.
             * if the book is already rented, display Sorry! the book is already rented message
             * }
             */
            if (readersBookList.Count >= 2)
            {
                Console.WriteLine("You cannot rent more than two books!");
                return;
            }
            if (book.Available())
            {
                if (book.Rent())
                {
                    readersBookList.Add(book);
                    Console.WriteLine($"{ReaderName} has rented the book: {book.BookName}");
                }
                else
                {
                    Console.WriteLine($"Sorry! The book {book.BookName} is already rented.");
                }
            }
            else
            {
                Console.WriteLine($"Sorry! The book {book.BookName} is not available for renting.");
            }


        }
        public void ReturnABook(Book book)
        {
            //ToDo
            //First check if the reader rented this book, 
            //if yes, change the book's status = false; meaning available
            //and remove the book for the readers book list.
            if (readersBookList.Contains(book))
            {
                if (book.Return())
                {
                    readersBookList.Remove(book);
                    Console.WriteLine($"{ReaderName} has returned the book: {book.BookName}");
                }
            }
            else
            {
                Console.WriteLine($"You haven't rented the book {book.BookName}.");
            }


        }
        public void ReaderInfo()
        {
            //This method is complete.
            //show reader's name and the list of books rented by the reader.
            //If no books are rented by the reader yet, display "No books rented yet!".

            Console.WriteLine("Reader {0} rented the following books:", ReaderName);
            if (readersBookList.Count == 0)
            {
                Console.WriteLine("No books rented yet!");
                return;
            }
            foreach (var book in readersBookList)
            {
                book.BookInfo();
            }
        }
    }
    class BookStore
    {
        //Required fileds are already provided to you.

        public List<Book> BookStoreBooksList;
        public List<Reader> BookStoreReadersList;
        public BookStore()
        {
            //Constructor method is complete.
            BookStoreBooksList = new List<Book>();  //initially bookstore has no books
            BookStoreReadersList = new List<Reader>(); //initially bookstore has no readers
        }
        public void AddAReader(string name)
        {
            //This method is complete
            //add a new reader to the bookstoreReadersList.
            Reader reader = new Reader(name);
            BookStoreReadersList.Add(reader);
        }
        public void RemoveAReader(string name)
        {
            //ToDo
            //Check if the reader is registered to the bookstore, if not generate error message
            //For a registered/existing reader, in order to remove a reader,
            //first, return all books (if any) rented by that reader and then remove the reader from BookStoreReadersList.
            // Check if the reader is registered in the bookstore
            Reader readerToRemove = BookStoreReadersList.FirstOrDefault(r => r.ReaderName == name);
            // error message
            if (readerToRemove == null)
            {
                Console.WriteLine($"Error: Reader {name} is not registered in the bookstore.");
                return;
            }

            // Check if the reader has rented any books
            if (readerToRemove.readersBookList.Count > 0)
            {
                // Return all books rented by the reader
                foreach (var book in readerToRemove.readersBookList.ToList()) 
                {
                    book.Return(); 
                    Console.WriteLine($"Reader {name} has returned the book '{book.BookName}' (Serial: {book.Serial}).");
                }
            }
            else
            {
                Console.WriteLine($"Reader {name} has no books rented.");
            }

            // Remove the reader from the BookStoreReadersList
            BookStoreReadersList.Remove(readerToRemove);
            Console.WriteLine($"Reader {name} has been successfully removed from the bookstore.");
        }
        public void AddABook(string name, int serial)
        {
            //ToDo
            // add a book object to the BookStoreBooksList with BookName and Serial.
            Book newBook = new Book(name, serial);
            BookStoreBooksList.Add(newBook);
           
        }
        public void RemoveABook(string name, int serial)
        {
            //ToDo
            //find the book with correct name and serial from BookStoreBooksList.
            //In order to remove a book from book store, only allow if the book's status==false
            //meaning the book is 'available' to the bookstore.
            //Otherwise, issue an error message because the book is already rented by some readers!
            Book bookToRemove = BookStoreBooksList.FirstOrDefault(b => b.BookName == name && b.Serial == serial);
            if (bookToRemove == null)
            {
                Console.WriteLine("The book was not found.");
                return;
            }
            // see if the book is avilable
            if (bookToRemove.Status == false) 
            {
                BookStoreBooksList.Remove(bookToRemove);
                Console.WriteLine($"Book {name} with serial {serial} has been removed from the bookstore.");
            }
            else
            {
                Console.WriteLine($"The book {name} with serial {serial} is currently rented and cannot be removed.");
            }
        }
       
        public void RentABook(string readerName, string bookName)
        {
            //ToDo
            //Find the reader from the BookStoreReadersList
            //If the reader is not registered to bookstore, display "you are not a registered reader of this bookstore"
            //Otherwise
            //A book can be rented, if it is available to the store and not already rented to somone else!
            //Display Sorry the book is not Available for renting; if already rented by another reader.
            Reader reader = BookStoreReadersList.FirstOrDefault(r => r.ReaderName == readerName);
            if (reader == null)
            {
                Console.WriteLine($"{readerName}, you are not a registered reader of this bookstore!");
                return;
            }

            Book book = BookStoreBooksList.FirstOrDefault(b => b.BookName == bookName && b.Available());
            if (book == null)
            {
                Console.WriteLine($"Sorry! {readerName}, The book '{bookName}' is not available for renting.");
                return;
            }

            // to make sure a reader can only rent 2 books only
            if (reader.readersBookList.Count >= 2)
            {
                Console.WriteLine($"Sorry! {readerName}, You cannot rent more than two books!");
                return;
            }

            reader.RentABook(book);

        }

        public void ReturnABook(string readerName, string bookName, int serial)
        {
            //ToDo
            //A book can be returned by a reader, if he/she actually rented the book.
            //Find the reader from BookStoreReadersList
            //Find the book with correct serial from from reader's personal book list
            //Return the book by calling 'ReturnABook' method of the Reader class.
            Reader reader = BookStoreReadersList.FirstOrDefault(r => r.ReaderName == readerName);
            if (reader == null)
            {
                Console.WriteLine("You are not a registered reader of this bookstore.");
                return;
            }

            // Find the book with the serial from the reader
            Book book = reader.readersBookList.FirstOrDefault(b => b.BookName == bookName && b.Serial == serial);
            if (book != null)
            {
                reader.ReturnABook(book);
            }
            else
            {
                Console.WriteLine($"Return Error! {readerName}, you have not rented {bookName}, Serial: {serial}");
            }
        }

        public void ShowBookInformation()
        {
            //ToDo
            //This method is complete for your understanding.
            //Show all books that are available to the bookstore (if any).
            //i.e. call BookInfo method for every book of the BookStoreBooksList
            // Check if the bookstore has any books
            if (BookStoreBooksList.Count == 0)
            {
                Console.WriteLine("The bookstore currently has no books.");
                return;
            }

            Console.WriteLine("The bookstore has the following books available:");

            // Loop through the list of books and display information about the book
            foreach (var book in BookStoreBooksList)
            {
                if (book.Available()) 
                {
                    book.BookInfo();
                }
            }
        }

        public void ShowReaderInformation()
        {
            //This method is complete
            //Show all readers that are added to the bookstore (if any).
            //i.e. call ReaderInfo method for every reader of the BookStoreReadersList
            if (BookStoreReadersList.Count == 0)
            {
                Console.WriteLine("The bookstore currently have no readers.");
                return;
            }
            Console.WriteLine("The bookstore has the following readers:");
            foreach (var reader in BookStoreReadersList)
            {
                reader.ReaderInfo();
            }
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*You should not change the code in the Main Method. */

            BookStore bs = new BookStore();
            bs.AddAReader("Mahbub Murshed");
            bs.AddAReader("David Alwright");
            bs.AddAReader("Susan Harper");
            bs.AddABook("Object Oriented Programming", 1);
            bs.AddABook("Object Oriented Programming", 2);
            bs.AddABook("Object Oriented Programming", 3);
            bs.AddABook("Programming Fundamentals", 1);
            bs.AddABook("Programming Fundamentals", 2);
            bs.AddABook("Let us C#", 1);
            bs.AddABook("Programming is Fun", 1);
            bs.AddABook("Life is Beautiful", 1);
            bs.AddABook("Let's Talk About the Logic", 1);
            bs.AddABook("How to ace a job interview", 1);

            bs.ShowBookInformation();
            bs.ShowReaderInformation();

            bs.RentABook("Salma Hayek", "Object Oriented Programming");

            bs.RentABook("Mahbub Murshed", "Object Oriented Programming");
            bs.RentABook("Mahbub Murshed", "How to ace a job interview");
            bs.RentABook("Mahbub Murshed", "Life is Beautiful");

            Console.WriteLine();

            bs.RentABook("David Alwright", "Object Oriented Programming");
            bs.RentABook("David Alwright", "Programming Fundamentals");
            Console.WriteLine();

            bs.RentABook("Susan Harper", "Let's Talk About the Logic");
            bs.RentABook("Susan Harper", "How to ace a job interview");
            Console.WriteLine();

            bs.ShowBookInformation();
            bs.ShowReaderInformation();


            bs.ReturnABook("Mahbub Murshed", "Object Oriented Programming", 1);
            bs.RentABook("Mahbub Murshed", "Life is Beautiful");
            Console.WriteLine();

            bs.ReturnABook("Mahbub Murshed", "Programming Fundamentals", 1);

            bs.RemoveABook("Let us C#", 1);
            bs.RemoveABook("Let's Talk About the Logic", 1);

            bs.ShowReaderInformation();
            bs.RemoveAReader("Mahbub Murshed");


            bs.ShowBookInformation();
            bs.ShowReaderInformation();
            Console.Read();

        }

    }
}




/*
Once Executed, Your program will have the following output:

The bookstore has the following books available:
Book Name: Object Oriented Programming, Serial: 1, Status: Available
Book Name: Object Oriented Programming, Serial: 2, Status: Available
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamentals, Serial: 1, Status: Available
Book Name: Programming Fundamentals, Serial: 2, Status: Available
Book Name: Let us C#, Serial: 1, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available
Book Name: Let's Talk About the Logic, Serial: 1, Status: Available
Book Name: How to ace a job interview, Serial: 1, Status: Available

The bookstore has the following readers:
Reader Mahbub Murshed rented the following books:
No books rented yet!
Reader David Alwright rented the following books:
No books rented yet!
Reader Susan Harper rented the following books:
No books rented yet!

Salma Hayek, you are not a registered reader of this bookstore!

Book: 'Object Oriented Programming' successfully rented by Mahbub Murshed.
Book: 'How to ace a job interview' successfully rented by Mahbub Murshed.
Sorry! Mahbub Murshed, You cannot rent more than two books!

Book: 'Object Oriented Programming' successfully rented by David Alwright.
Book: 'Programming Fundamentals' successfully rented by David Alwright.

Book: 'Let's Talk About the Logic' successfully rented by Susan Harper.
Sorry Susan Harper, The book 'How to ace a job interview' is not Available for renting.

The bookstore has the following books available:
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamentals, Serial: 2, Status: Available
Book Name: Let us C#, Serial: 1, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available

The bookstore has the following readers:
Reader Mahbub Murshed rented the following books:
Book Name: Object Oriented Programming, Serial: 1, Status: Rented
Book Name: How to ace a job interview, Serial: 1, Status: Rented
Reader David Alwright rented the following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamentals, Serial: 1, Status: Rented
Reader Susan Harper rented the following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented

Book: 'Object Oriented Programming', Serial: 1 successfully returned by Mahbub Murshed.
Book: 'Life is Beautiful' successfully rented by Mahbub Murshed.

Return Error! Mahbub Murshed, you have not rented Programming Fundamentals, Serial: 1

The book: Let us C#,Serial: 1, is successfully removed from the bookstore.
Sorry! 'Let's Talk About the Logic' is already rented. System cannot remove a rented book!

The bookstore has the following readers:
Reader Mahbub Murshed rented the following books:
Book Name: How to ace a job interview, Serial: 1, Status: Rented
Book Name: Life is Beautiful, Serial: 1, Status: Rented
Reader David Alwright rented the following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamentals, Serial: 1, Status: Rented
Reader Susan Harper rented the following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented

Returning books rented by Mahbub Murshed:
Book: 'How to ace a job interview', Serial: 1 successfully returned by Mahbub Murshed.
Book: 'Life is Beautiful', Serial: 1 successfully returned by Mahbub Murshed.
Reader Mahbub Murshed successfully removed from bookstore.

The bookstore has the following books available:
Book Name: Object Oriented Programming, Serial: 1, Status: Available
Book Name: Object Oriented Programming, Serial: 3, Status: Available
Book Name: Programming Fundamentals, Serial: 2, Status: Available
Book Name: Programming is Fun, Serial: 1, Status: Available
Book Name: Life is Beautiful, Serial: 1, Status: Available
Book Name: How to ace a job interview, Serial: 1, Status: Available

The bookstore has the following readers:
Reader David Alwright rented the following books:
Book Name: Object Oriented Programming, Serial: 2, Status: Rented
Book Name: Programming Fundamentals, Serial: 1, Status: Rented
Reader Susan Harper rented the following books:
Book Name: Let's Talk About the Logic, Serial: 1, Status: Rented

 */
