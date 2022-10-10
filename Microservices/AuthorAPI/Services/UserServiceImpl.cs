using AuthorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAPI.Services
{
    public class UserServiceImpl:IUserService
    {
        BookAuthorContext db;


        private IConfiguration _config;

        public UserServiceImpl(IConfiguration config, BookAuthorContext _db)
        {

            _config = config;
            db = _db;
        }

        public User AuthenticateUser(User login, bool IsRegister)
        {
            if (IsRegister)
            {
                db.Users.Add(login);
                db.SaveChanges();
                return login;
            }
            if (db.Users.Any(x => x.Email == login.Email && x.Password == login.Password))
            {
                return db.Users.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string GenerateToken(User login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var cradentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: cradentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {

            return db.Users;

        }

        public IEnumerable<BookDet> GetBooks(int id)
        {

            // yield return db.BookDets.FirstOrDefault(x => x.CreateBy == id);
            //.Where(x => x.CreateBy == id).FirstOrDefault().toli;
            var booklist = (from em in db.BookDets.Where(x => x.CreateBy == id)
                            select new
                            {
                                Id = em.Id,
                                BookTitle = em.BookTitle,
                                BookCategory = em.BookCategory,
                                BookImg = em.BookImg,
                                BookPrice = em.BookPrice,
                                BookPublish = em.BookPublish,
                                Active = em.Active,
                                BookContent = em.BookContent,
                                PublishDate = em.PublishDate
                            }).ToList();

            BookDet book;
            List<BookDet> blist = new List<BookDet>();
            foreach (var item in booklist)
            {
                book = new BookDet();
                book.Id = item.Id;
                book.BookTitle = item.BookTitle;
                book.BookCategory = item.BookCategory;
                book.BookImg = item.BookImg;
                book.BookPrice = item.BookPrice;
                book.BookPublish = item.BookPublish;
                book.Active = item.Active;
                book.BookContent = item.BookContent;
                book.PublishDate = item.PublishDate;

                blist.Add(book);

            }

            return blist;

        }

        public IEnumerable<BookDet> Getallbooks()
        {

            var booklist = db.BookDets.Where(x => x.Active == true).ToList();

            BookDet book;
            List<BookDet> blist = new List<BookDet>();
            foreach (var item in booklist)
            {
                book = new BookDet();
                book.Id = item.Id;
                book.BookTitle = item.BookTitle;
                book.BookCategory = item.BookCategory;
                book.BookImg = item.BookImg;
                book.BookPrice = item.BookPrice;
                book.BookPublish = item.BookPublish;
                book.Active = item.Active;
                book.BookContent = item.BookContent;
                book.PublishDate = item.PublishDate;

                blist.Add(book);

            }

            return blist;



        }

        public IEnumerable<BookDet> GetBookPayment(int id)
        {


            var booklist = (from pd in db.BookDets
                            join od in db.TblPayments.Where(x => x.PaymentBy == id && x.CancelOrder == false) on pd.Id equals od.BookId
                            select new
                            {
                                Id = pd.Id,
                                BookTitle = pd.BookTitle,
                                BookCategory = pd.BookCategory,
                                BookImg = pd.BookImg,
                                BookPrice = pd.BookPrice,
                                BookPublish = pd.BookPublish,
                                Active = pd.Active,
                                BookContent = pd.BookContent,
                                PublishDate = pd.PublishDate
                            }).ToList();

            BookDet book;
            List<BookDet> blist = new List<BookDet>();
            foreach (var item in booklist)
            {
                book = new BookDet();
                book.Id = item.Id;
                book.BookTitle = item.BookTitle;
                book.BookCategory = item.BookCategory;
                book.BookImg = item.BookImg;
                book.BookPrice = item.BookPrice;
                book.BookPublish = item.BookPublish;
                book.Active = item.Active;
                book.BookContent = item.BookContent;
                book.PublishDate = item.PublishDate;

                blist.Add(book);

            }

            return blist;

        }

        public IEnumerable<Order> GetBookOrder(int id)
        {


            var booklist = (from pd in db.BookDets
                            join od in db.TblPayments.Where(x => x.PaymentBy == id) on pd.Id equals od.BookId
                            select new
                            {
                                BookId = pd.Id,
                                BookTitle = pd.BookTitle,
                                BookCategory = pd.BookCategory,
                                BookPrice = pd.BookPrice,
                                PaymentId = od.PaymentId,
                                InvoiceNo = od.InvoiceNo,
                                PaymentDate = od.PaymentDate,
                                Paymentname = od.PaymentName,
                                CancelOrder = od.CancelOrder,

                            }).ToList();

            Order bookord;
            List<Order> olist = new List<Order>();
            foreach (var item in booklist)
            {
                bookord = new Order();

                bookord.PaymentId = item.PaymentId;
                bookord.BookId = item.BookId;
                bookord.BookTitle = item.BookTitle;
                bookord.BookPrice = item.BookPrice;
                bookord.InvoiceNo = item.InvoiceNo;
                bookord.PaymentDate = Convert.ToDateTime(item.PaymentDate.ToString()).ToString("dd/MM/yyyy");
                bookord.PaymentName = item.Paymentname;
                bookord.CancelOrder = item.CancelOrder;


                olist.Add(bookord);

            }

            return olist;

        }

        public bool BookAdd(BookDet obj)
        {
            try
            {
                obj.CreateDate = System.DateTime.Now;
                db.BookDets.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool BookEdit( BookDet obj)
        {
            bool rtn = false;
            try
            {

                var existingBook = db.BookDets.Where(x => x.Id == obj.Id)
                                                            .FirstOrDefault<BookDet>();

                if (existingBook != null)
                {
                    obj.ModyDate = System.DateTime.Now;
                    existingBook.BookTitle = obj.BookTitle;
                    existingBook.BookCategory = obj.BookCategory;

                    if (obj.BookImg != "")
                    {
                        existingBook.BookImg = obj.BookImg;
                    }

                    existingBook.BookPrice = obj.BookPrice;
                    existingBook.BookPublish = obj.BookPublish;
                    existingBook.Active = obj.Active;
                    existingBook.BookContent = obj.BookContent;
                    existingBook.PublishDate = obj.PublishDate;
                    existingBook.ModyDate = obj.ModyDate;

                    db.SaveChanges();

                    rtn= true;
                }

                
            }
            catch
            {
                rtn= false;
            }

            return rtn;
            
        }

        public bool DeleteBook(int id)
        {
            var data = db.BookDets.Where(x => x.Id == id).FirstOrDefault();
            db.BookDets.Remove(data);
            db.SaveChanges();           
            return true;
        }

        public bool PaymentBook(TblPayment payment)
        {
            payment.InvoiceNo = InvoiceNo();
            payment.PaymentDate = System.DateTime.Now;
            var IsPaid = (from pay in db.TblPayments.Where(p => p.BookId == payment.BookId && p.PaymentBy == payment.PaymentBy && p.CancelOrder == false)
                          select new
                          {
                              value = true
                          }
                          ).FirstOrDefault();
            if(IsPaid!=null)
            {
                return false;
            }
            db.TblPayments.Add(payment);
            db.SaveChanges();
            return true;
        }
        private string InvoiceNo()
        {



            var invoice = (from em in db.TblInvoices.Where(c => c.Active != false)
                           select new
                           {
                               Invoice = "Inv_" + em.Year + "_" + em.Month + "_" + em.SlNo.ToString()

                           }).FirstOrDefault();

            return invoice.Invoice;

        }

        public string upload(IFormFile file)
        {
            //var file = Request.Form.Files[0];
            var foldername = "Images";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(foldername, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return dbPath;
            }
            else
            {
                return "";
            }

        }


    }
}
