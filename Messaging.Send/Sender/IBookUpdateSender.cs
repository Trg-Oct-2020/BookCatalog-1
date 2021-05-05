using BookCatalog.MicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CustomerApi.Data.Entities;

namespace BookCatalog.MicroService.Messaging.Send.Sender
{
    public interface IBookUpdateSender
    {
        void SendBook(Book book);
    }
}
