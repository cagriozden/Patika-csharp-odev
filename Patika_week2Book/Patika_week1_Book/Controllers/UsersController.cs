using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patika_week1_Book.Entities;



namespace Patika_week1_Book.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly FakeUserLoginServices _Service;

        public UsersController(FakeUserLoginServices _Service)
        {
            _Service = _Service;
        }
        

        [HttpPost("UserLogin")]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = _Service.Authenticate(model.NickName, model.Password);

                if (isAuthenticated)
                {
                    return Ok("Success");
                }
            }
            return Unauthorized("Fail");
        }
    }
}
