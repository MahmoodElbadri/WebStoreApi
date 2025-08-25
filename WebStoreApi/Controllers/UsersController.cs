using Microsoft.AspNetCore.Mvc;

namespace WebStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<string> usersList = new List<string>
        {
            "Bob", "Alice", "Eve", "John", "Mary"
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
        public IActionResult AddUser(string user)
        {
            usersList.Add(user);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string username, int id)
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
            }
            return NoContent();
        }
    }
}
