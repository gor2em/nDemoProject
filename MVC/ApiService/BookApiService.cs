using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ApiService
{
    public class BookApiService
    {
        private readonly HttpClient _httpClient;
        public BookApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            IEnumerable<Book> books;
            var response = await _httpClient.GetAsync("books");
            if (response.IsSuccessStatusCode)
            {
                books = JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                books = null;
            }
            return books;
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"books/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
            }
            else return null;
        }
        public async Task<Book> AddAsync(Book book)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("books", stringContent);
            if (response.IsSuccessStatusCode)
            {
                book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
                return book;
            }
            else
            {
                return null;
            }
        }
        public async Task<Book> UpdateAsync(Book book)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("books", stringContent);
            if (response.IsSuccessStatusCode)
            {
                book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
                return book;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"books/{id}");
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;

        }
    }
}
