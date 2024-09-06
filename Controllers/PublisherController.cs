using LibraryManagementSystemAPI.CRUDmodels;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PublisherController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Books.ToList());
        }

        [HttpGet]
        [Route("/repo")]
        public IActionResult Report(int id)
        {
            try
            {
                // Find the book by its ID
                var book = context.Books.Find(id);

                // Check if the book exists
                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                // Check if the book has an associated reader
                if (book.Reader == null)
                {
                    return NotFound("No reader associated with this book.");
                }

                // Return the reader associated with the book
                return Ok(book.Reader);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostBook(AddBook book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Price = book.Price,
                Category = book.Category,
                Edition = book.Edition
            };

            context.Books.Add(newBook);
            context.SaveChanges();
            return Ok(newBook);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(int id, AddBook book)
        {
            var update = await context.Books.FindAsync(id);
            update.Title = book.Title;
            update.Price = book.Price;
            update.Category = book.Category;
            update.Edition = book.Edition;
            await context.SaveChangesAsync();
            return Ok(update);

        }

        [HttpDelete]
        public async Task<IActionResult> DelBook(int id)
        {
            var del = await context.Books.FindAsync(id);
            try
            {
                context.Books.Remove(del);
                context.SaveChanges();
                return Ok("Deleted succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "huhh Really ?");
            }
        }

    }
}
