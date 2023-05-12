using csapi.Data;
using csapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csapi.Controllers
{
    [ApiController]
    [Route("")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext db;
        public UsersController(AppDbContext db)
        {
            this.db = db;

        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserInput userInput)
        {
            var (Name, UserName, Email, Bio, BirthDate, Gender, Avatar, Header, Password) = userInput;

            await db.Users.AddAsync(new UserModel
            {
                Name = Name,
                UserName = UserName,
                Email = Email,
                Bio = Bio,
                BirthDate = BirthDate,
                Gender = Gender,
                Avatar = Avatar,
                Header = Header,
                Password = Password
            });

            await db.SaveChangesAsync();

            return Ok(new { Name, UserName, Email, Bio, BirthDate, Gender, Avatar, Header, Password });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user_count = await db.Users.CountAsync();
            var skip = Random.Shared.Next(user_count - 50);
            var users = await db.Users.Skip(skip).Take(50).ToListAsync();
            return Ok(users);
        }
    }
}