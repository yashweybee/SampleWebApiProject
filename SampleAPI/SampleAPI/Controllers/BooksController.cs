using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBLL.Interfaces;
using SampleDAL.Repository;
using SampleDAL.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseApiController<BooksController>
    {
        public IBooksService _booksService { get; }
        public IMapper _mapper { get; }

        public BooksController(ILogger<BooksController> logger, IBooksService booksService, IMapper mapper) : base(logger)
        {
            _booksService = booksService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all the data form Books table
        /// </summary>
        /// <returns>Returns json object of all books data</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VMBook>>> GetBooks()
        {
            var books = await _booksService.GetAllAsync();
            return Ok(books);
        }

        //[HttpGet(Name = "Pagination, Sorting & Searching")]
        //public async Task<ActionResult<IEnumerable<VMBook>>> GetBooksBySp()
        //{
        //    var books = await _booksService.From

        //    return Ok(books);
        //}

    }
}
