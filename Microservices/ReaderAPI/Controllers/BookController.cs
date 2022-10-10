using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ReaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookAuthorContext db = new BookAuthorContext();
        [HttpGet]
        [Route("Get-Books")]
        public IEnumerable<BookDet> Get(int id)
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

        [HttpGet]
        [Route("Get-Books-All")]
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

        [HttpGet]
        [Route("Get-Books-Pay")]
        public IEnumerable<BookDet> GetBookPayment(int id)
        {

            // yield return db.BookDets.FirstOrDefault(x => x.CreateBy == id);
            //.Where(x => x.CreateBy == id).FirstOrDefault().toli;
            /*var booklist = (from em in db.BookDets.Where(x => x.CreateBy == id)
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
                            }).ToList(); */
            var booklist = (from pd in db.BookDets
                            join od in db.TblPayments.Where(x => x.PaymentBy == id && x.CancelOrder==false) on pd.Id equals od.BookId                          
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


        [HttpPost]
        [Route("Book-Add")]
        public IActionResult Post([FromBody] BookDet obj)
        {
            obj.CreateDate = System.DateTime.Now;
            db.BookDets.Add(obj);
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }


        [HttpPut]
        [Route("Book-Edit")]
        public IActionResult Put([FromBody] BookDet obj)
        {


            var response = new { Status = "Success" };
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
            }
            else
            {
                response = new { Status = "Not Found" };
                return Ok(response);
            }

            // response = new { Status = "Not Found" };
            return Ok(response);
        }



        [HttpDelete]
        [Route("Book-Delete")]
        public IActionResult Delete(int id)
        {
            var data = db.BookDets.Where(x => x.Id == id).FirstOrDefault();
            db.BookDets.Remove(data);
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult upload()
        {
            var file = Request.Form.Files[0];
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
                return Ok(new { ImgPath = dbPath, Status = "Success" });
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
