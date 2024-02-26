﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBLL.Interfaces;
using SampleDAL.DbModels;
using SampleDAL.Repository;
using SampleDAL.ViewModels;
using Serilog;

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
        /// <returns>Returns json object of all books data (Response Model)</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VMBook>>> GetBooks()
        {
            var books = await _booksService.GetAllAsync();

            if (books == null)
            {
                return NotFound(new Response<IEnumerable<VMBook>>(MESSAGE.DATA_NOT_FOUND, false));
            }

            //throw new Exception("Custom exception : Test");

            Log.Information("\n \n Books data : {@books}", books);
            return Ok(new Response<IEnumerable<Book>>(books, true, MESSAGE.LOADED));
        }
    }
}
