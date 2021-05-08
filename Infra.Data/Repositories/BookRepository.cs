using BookCatalog.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookCatalog.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        readonly string filePath = @".\DataStore\Book.json";
        public IQueryable<Book> GetAll() => ReadData.AsQueryable();

        public IQueryable<Book> Update(Book book)
        {
            var bookDetails = ReadData;
            var findBook = bookDetails.Where(x => x.id == book.id);
            bookDetails.Remove(findBook.FirstOrDefault());
            bookDetails.Add(book);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
            return bookDetails.AsQueryable<Book>();
            
        }

        public IQueryable<Book> Add(Book book)
        {
            var bookDetails = ReadData;
            bookDetails.Add(book);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
            return bookDetails.AsQueryable<Book>();           
        }
        public string Delete(string id)
        {
            var bookDetails = ReadData;
            var deletedBook = bookDetails.Where(x => x.id == id);
            bookDetails.Remove(deletedBook.FirstOrDefault());
            File.WriteAllText(filePath, JsonConvert.SerializeObject(bookDetails));
            return id;
        }

        public IQueryable<Book> Get(string title, string author, string isbn)
        {
            var query = ReadData.AsQueryable();
            if (!string.IsNullOrEmpty(title))
                query = query.Where(x => x.title == title).AsQueryable();
            if (!string.IsNullOrEmpty(author))
                query = query.Where(x => x.author == author).AsQueryable();
            if (!string.IsNullOrEmpty(isbn))
                query = query.Where(x => x.isbn == isbn).AsQueryable();
            return query;
        }

        public List<Book> ReadData
        {
            get
            {
                var readjson = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Book>>(readjson);
            }
        }
    }
}
