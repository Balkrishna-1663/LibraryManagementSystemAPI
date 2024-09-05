using LibraryManagementSystemAPI.CRUDmodels;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInReader loginUser)
        {
            var user = context.Readers.SingleOrDefault(u => u.Name == loginUser.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("ThisIsKishan");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        [HttpGet]
        public async Task<IActionResult> SearchBook(int id)
        {
            var toBook = await context.Readers.FindAsync(id);
            return Ok(toBook);

        }
       // [Authorize]
        [HttpPost]
        public async Task<IActionResult> IssueBook(int id, int UserId)
        {
            var Issuedbook=await context.Books.FindAsync(id);
            var newuser = await context.Readers.FindAsync(UserId);
          newuser.books.Add(Issuedbook);
           
            return Ok("book Issued");

        }



    }
}
