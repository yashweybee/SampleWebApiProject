using SampleBLL.Interfaces;
using SampleDAL.DbModels;
using SampleDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBLL.Service
{
    public class BookService : IBooksService
    {
        private readonly IDBRepository<Book> _bookRepo;
        public BookService(IDBRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepo.GetAllAsync();
        }

    }
}
