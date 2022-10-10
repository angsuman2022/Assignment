using AuthorAPI.Models;
using AuthorAPI.Services;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuthorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BookController : ControllerBase
    {

        IUserService userService;
        public BookController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        [Route("Get-Books")]
        public IEnumerable<BookDet> GetBooks(int id)
        {

            return userService.GetBooks(id);


        }

        [HttpGet]
        [Route("Get-Books-All")]
        public IEnumerable<BookDet> Getallbooks()
        {        

            return userService.Getallbooks();


        }


        [HttpGet]
        [Route("Get-Books-Pay")]
        public IEnumerable<BookDet> GetBookPayment(int id)
        {

            return userService.GetBookPayment(id);

        }

        [HttpGet]
        [Route("Get-Books-Order")]
        public IEnumerable<Order> GetBookOrder(int id)
        {

            return userService.GetBookOrder(id);

        }

        [HttpPost]
        [Route("Book-Add")]
        public IActionResult Post([FromBody] BookDet obj)
        {
            bool chk = userService.BookAdd(obj);
            if (chk)
            {
                var response = new { Status = "Success" };
                return Ok(response);
            }
            else
            {
                var response = new { Status = "Unsuccess" };
                return Ok(response);
            }
        }


        [HttpPut]
        [Route("Book-Edit")]
        public IActionResult Put([FromBody] BookDet obj)
        {


            var response = new { Status = "Success" };
            bool chk = userService.BookEdit(obj);
            if(chk)
            {
                response = new { Status = "Success" };
                return Ok(response);
            }           
            else
            {
                response = new { Status = "Unsuccessful" };
                return Ok(response);
            }

            
        }



        [HttpDelete]
        [Route("Book-Delete")]
        public IActionResult Delete(int id)
        {
            bool chk = userService.DeleteBook(id);
            var response = new { Status = "Success" };
            return Ok(response);
        }

        /* [HttpPost, DisableRequestSizeLimit]
         [Route("Upload")]
         public async Task<IActionResult> upload()
         {

             //string path = userService.upload(Request.Form.Files[0]);
             //if(path!="")
             //{ 
             //    return Ok(new { ImgPath = path, Status = "Success" });
             //}
             //else
             //{
             //    return BadRequest();
             //}

             var file = Request.Form.Files[0];
             //var pathToSave = Directory.GetCurrentDirectory();

             if (file.Length > 0)
             {
                 try
                 {
                     var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                     var _filename = Path.GetFileNameWithoutExtension(fileName);
                     fileName = _filename + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                     var foldername = "Images";
                     var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                     var fullPath = Path.Combine(pathToSave, fileName);
                     var dbPath = fileName;
                     using (var stream = new FileStream(fullPath, FileMode.Create))
                     {
                         file.CopyTo(stream);
                     }

                     string connectionstring = "DefaultEndpointsProtocol=https;AccountName=bookappimages;AccountKey=cQmdDhZcR9Opw0Oiisw0dTS9dheMSg0NsXq889QXEyUyTpls49rCnDtvsgjDWPMaMdl+DK08JQCt+AStRTBbcw==;EndpointSuffix=core.windows.net";
                     string containerName = "images";
                     BlobContainerClient container = new BlobContainerClient(connectionstring, containerName);
                     var blob = container.GetBlobClient(fileName);
                     var blobstream = System.IO.File.OpenRead(fileName);
                     await blob.UploadAsync(blobstream);
                     var URI = blob.Uri.AbsoluteUri;
                     // TblImage obj = new TblImage();
                     // obj.ImageUrl = dbPath;
                     // db.TblImages.Add(obj);
                     // db.SaveChanges();
                     return Ok(new { ImgPath = dbPath , Status = "Success" });
                 }
                 catch (Exception ex)
                 {
                     return BadRequest();
                 }

             }
             else
             {
                 return BadRequest();
             }

         } */


        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public async Task<IActionResult> upload()
        {

            var file = Request.Form.Files[0];
            var foldername = "Images/";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            //var pathToSave = Directory.GetCurrentDirectory();
            if (file.Length > 0)
            {
                try
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var _filename = Path.GetFileNameWithoutExtension(fileName);
                    fileName = _filename + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jfif";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    string connectionstring = "DefaultEndpointsProtocol=https;AccountName=bookappimages;AccountKey=cQmdDhZcR9Opw0Oiisw0dTS9dheMSg0NsXq889QXEyUyTpls49rCnDtvsgjDWPMaMdl+DK08JQCt+AStRTBbcw==;EndpointSuffix=core.windows.net";
                    string containerName = "images";
                    BlobContainerClient container = new BlobContainerClient(connectionstring, containerName);
                    var blob = container.GetBlobClient(fileName);
                    var blobstream = System.IO.File.OpenRead("Images/" + fileName);
                    await blob.UploadAsync(blobstream);
                    var URI = blob.Uri.AbsoluteUri;

                    return Ok(new { ImgPath = dbPath, Status = "Success" });
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }

        }
    }
}
