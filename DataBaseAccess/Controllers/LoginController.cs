using DataBaseAccess.Models;
using DataBaseAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        ILoginService _UserCollection;

        public LoginController(ILoginService UserCollection)
        {
            _UserCollection = UserCollection ?? throw new ArgumentNullException(nameof(LoginService));
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<User> Users = _UserCollection.GetAll();
            return Ok(Users);
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User? User = _UserCollection.Get(id);

            if (User == null)
            {
                return NotFound("There is no User with that id.");
            }
            return Ok(User);
        }


        [HttpGet("category/{categoryId}")]
        public IActionResult GetUserByCategoryId(string categoryId)
        {
            //List<User> Users = _UserCollection.GetUsersByCategoryId(categoryId);

            //if (Users.Count == 0)
            //{
            //    return NotFound("There is no User with that category id.");
            //}
            return Ok();
        }


        [HttpPost]
        public IActionResult Create([FromBody] User User)
        {
            if (User == null)
            {
                return BadRequest("The User can't be null!");
            }

            _UserCollection.Add(User);
            return Ok("The User was added!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_UserCollection.Delete(id))
            {
                return Ok("The User was deleted successfully!");
            }
            return NotFound("The User was not found!");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User User)
        {
            if (User == null)
            {
                return BadRequest("User can't be null.");
            }

            if (_UserCollection.Edit(id, User))
            {
                return Ok("The User was edited successfully!");
            }
            return NotFound("The User was not found!");
        }
    }
}