using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using MVC.ApiService;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly BookApiService _bookApiService;
        public BookController(IBookService bookService, BookApiService bookApiService)
        {
            _bookService = bookService;
            _bookApiService = bookApiService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookApiService.GetAllAsync();
            return View(books);
            //var books = await _bookService.GetAllAsync();
            //return View(books);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var detail = await _bookApiService.GetByIdAsync(id);
            return View(detail);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookApiService.AddAsync(book);
                return RedirectToAction("Index", "Book");
            }
            ModelState.AddModelError("", "boşlukları doldurun veya eksikleri giderin.");

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bookApiService.Remove(id);
            return RedirectToAction("Index", "Book");
        }
        public async Task<IActionResult> Update(int id)
        {
            var bookDetail = await _bookApiService.GetByIdAsync(id);
            return View(bookDetail);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Book book)
        {
            await _bookApiService.UpdateAsync(book);
            return RedirectToAction("Index", "Book");
        }
    }
}
