using LibraryManagementSystemAPI.CRUDmodels;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ReaderController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //  [HttpGet]
        //public IActionResult GetAllReader() { 
        //  return Ok(context.Readers.ToList());
        //}


        [HttpPost("register")]
        public async Task<IActionResult> Register(AddReaders reader)
        {
            reader.Password = BCrypt.Net.BCrypt.HashPassword(reader.Password);
            var newuser = new Reader
            {
                Name = reader.Name,
                Password = reader.Password,
                Email = reader.Email,
                Address = reader.Address,
                PhoneNumber = reader.PhoneNumber               

            };
            // Hashing password
            context.Readers.Add(newuser);
            await context.SaveChangesAsync();
            return Ok(new { message = "Reader registered successfully" });
        }

        



    }
}
