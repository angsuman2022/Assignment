
using ReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderAPI.Services
{
    public interface IReaderService
    {
        bool BookCancel(Order obj);
    }
}
