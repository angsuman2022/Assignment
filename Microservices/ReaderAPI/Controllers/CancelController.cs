using ReaderAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReaderAPI.Services;

namespace ReaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelController : ControllerBase
    {
        IReaderService userService;
        public CancelController(IReaderService _userService)
        {
            userService = _userService;
        }
        [HttpPost]
        [Route("Book-Cancel")]
        public IActionResult BookCancel([FromBody] Order obj)
        {
            var response = new { Status = "Cancel only possible within 24 hours" };
            bool Chk = userService.BookCancel(obj);
            if (!Chk)
            {
                return Ok(response);
            }
            
            response = new { Status = "Order cancel Successfull" };
            return Ok(response);
        }
    }
}
