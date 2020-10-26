using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var books = await _bookService.GetByIdAsync(id);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Book book)
        {
            var addBook = await _bookService.AddAsync(book);
            return Created(string.Empty, addBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetByIdAsync(id).Result;
            _bookService.Remove(book);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            var bookUpdate = _bookService.Update(book);
            return NoContent();
        }
    }
}
