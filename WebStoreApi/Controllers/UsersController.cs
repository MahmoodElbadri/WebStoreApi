using Microsoft.AspNetCore.Mvc;
using WebStoreApi.Models;

namespace WebStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<UserDto> usersList = new()
        {
            new()
            {
                FirstName = "Mahmoud",
                LastName = "Salah",
                Email = "tmb5F@example.com",
                Address = "Cairo",
                Phone = "01012345678",
            },
            new()
            {
                FirstName = "Ahmed",
                LastName = "Osama",
                Email = "tmb6F@example.com",
                Address = "Alexandria",
                Phone = "01022345678",
            },
            new()
            {
                FirstName = "Ali",
                LastName = "Mansour",
                Email = "tmb7F@example.com",
                Address = "Giza",
                Phone = "01032345678",
            },
            new()
            {
                FirstName = "Khalid",
                LastName = "Ahmed",
                Email = "tmb8F@example.com",
                Address = "Cairo",
                Phone = "01042345678",
            },
            new()
            {
                FirstName = "Hassan",
                LastName = "Ibrahim",
                Email = "tmb9F@example.com",
                Address = "Alexandria",
                Phone = "01052345678",
            },
            new()
            {
                FirstName = "Omar",
                LastName = "Mahmoud",
                Address = "Giza",
                Email = "tmb10F@example.com",
                Phone = "01062345678",
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            if (usersList.Count != 0)
            {
                return Ok(usersList);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            if (id > 0 && id < usersList.Count)
            {
                return Ok(usersList[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            usersList.Add(user);
            ModelState.AddModelError(nameof(user.Email), "Email already exists");
            return BadRequest(ModelState);
            return Created();
        }

        [HttpGet("{username:alpha}")]
        public IActionResult GetUser(string username)
        {
            var user = usersList.FirstOrDefault(tmp => tmp.FirstName.Contains(username, StringComparison.OrdinalIgnoreCase)
            || tmp.LastName.Contains(username, StringComparison.OrdinalIgnoreCase));
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(UserDto username, int id)
        {
            if (id > 0 && id < usersList.Count)
            {
                usersList[id] = username;
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id > 0 && id < usersList.Count)
            {
                usersList.RemoveAt(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
