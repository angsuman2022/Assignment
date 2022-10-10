using AuthorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Services
{
    public interface IUserService
    {
        
        User AuthenticateUser(User login, bool IsRegister);
        string GenerateToken(User login);
        IEnumerable<User> GetAll();

        IEnumerable<BookDet> GetBooks(int id);
        IEnumerable<BookDet> Getallbooks();
        IEnumerable<BookDet> GetBookPayment(int id);
        IEnumerable<Order> GetBookOrder(int id);
        bool BookAdd(BookDet obj);
        bool BookEdit(BookDet obj);
        bool DeleteBook(int id);
        string upload(IFormFile file);


        bool PaymentBook(TblPayment payment);










    }
}
