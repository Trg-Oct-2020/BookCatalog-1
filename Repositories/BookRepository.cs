using BookCatalog.MicroService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.MicroService.Repositories
{
    public class BookRepository : IBookRepository
    {

        public IQueryable<Book> GetBook()
        {
            // read file into a string and deserialize JSON to a type
            var filePath = @".\Repo\Book.json";
            var readjson = File.ReadAllText(filePath);
            List<Book> bookDetails = JsonConvert.DeserializeObject<List<Book>>(readjson);
            return bookDetails.AsQueryable<Book>();
        }

        public IQueryable<Book> UpdateBook(Book book)
        {
           
            // read file into a string and deserialize JSON to a type
            var filePath = @".\Repo\Book.json";
            var readjson = File.ReadAllText(filePath);
            var bookDetails = JsonConvert.DeserializeObject<List<Book>>(readjson);
            var findBook = bookDetails.Where(x => x.id == book.id);
            bookDetails.Remove(findBook.FirstOrDefault());
            bookDetails.Add(book);
            var serialJson = JsonConvert.SerializeObject(bookDetails);
            File.WriteAllText(filePath, serialJson);
            return bookDetails.AsQueryable<Book>();

        }


        public IQueryable<Book> AddBook(Book book)
        {
            // read file into a string and deserialize JSON to a type
            var filePath = @".\Repo\Book.json";
            var readjson = File.ReadAllText(filePath);
            var bookDetails = JsonConvert.DeserializeObject<List<Book>>(readjson);
            bookDetails.Add(book);
            var serialJson = JsonConvert.SerializeObject(bookDetails);
            File.WriteAllText(filePath, serialJson);
           // SendMessagetoQueue("Book Added");
            return bookDetails.AsQueryable<Book>();
        }

        public string DeleteBook(string id)
        {
            var filePath = @".\Repo\Book.json";
            var readjson = File.ReadAllText(filePath);
            var bookDetails = JsonConvert.DeserializeObject<List<Book>>(readjson);
            var deletedBook = bookDetails.Where(x => x.id == id);
            bookDetails.Remove(deletedBook.FirstOrDefault());
            var serialJson = JsonConvert.SerializeObject(bookDetails);
            File.WriteAllText(filePath, serialJson);
            //SendMessagetoQueue("Book Deleted");
            return id;
        }


        public IQueryable<Book> GetBooks(string title, string author,string isbn)
        {
            var filePath = @".\Repo\Book.json";
            var readjson = File.ReadAllText(filePath);
            var query = JsonConvert.DeserializeObject<List<Book>>(readjson).AsQueryable();
            //var bookList= bookDetails.Where(x => x.title== title);
            
            if(!string.IsNullOrEmpty(title))
                query = query.Where(x => x.title == title).AsQueryable();
            if ( !string.IsNullOrEmpty(author))
                query = query.Where(x => x.author == author).AsQueryable();
            if (!string.IsNullOrEmpty(isbn))
                query = query.Where(x => x.isbn == isbn).AsQueryable();
            return query;
        }
    }
}
