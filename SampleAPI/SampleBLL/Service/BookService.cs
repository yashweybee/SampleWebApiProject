using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SampleBLL.Interfaces;
using SampleDAL.DbModels;
using SampleDAL.Repository;
using SampleDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBLL.Service
{
    public class BookService : IBooksService
    {
        private readonly IDBRepository<Book> _bookRepo;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public BookService(IDBRepository<Book> bookRepo, IConfiguration configuration)
        {
            _bookRepo = bookRepo;
            _configuration = configuration;
            _connection = new SqlConnection();
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepo.GetAllAsync();
        }

        //public async Task<IEnumerable<Book>> GetAllBooksByStoredProcedure(VMBooksSP vmBookSp)
        //{

        //    //var parameters = new DynamicParameters();
        //    //parameters.Add("@pageNumber", vmBookSp.PageNumber);
        //    //parameters.Add("@pageSize", vmBookSp.PageSize);
        //    //parameters.Add("@sortColumn", vmBookSp.SortColumn);
        //    //parameters.Add("@sortType", vmBookSp.SortType);
        //    //parameters.Add("@search", vmBookSp.Search);

        //    //await _connection.ExecuteAsync("usp_GetBooksList", parameters, commandType: CommandType.StoredProcedure);




        //    var books = await _bookRepo.GetAllAsync();
        //    return books;

        //}
    }
}
