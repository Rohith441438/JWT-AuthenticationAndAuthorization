using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admin")]
        [Authorize(Roles ="Admin")]
        public IActionResult AdminEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Givenname}, you are an {currentUser.Role}");
        }

        [HttpGet("Seller")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellerEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Givenname}, you are a {currentUser.Role}");
        }

        [HttpGet("AdminAndSeller")]
        [Authorize(Roles = "Admin, Seller")]
        public IActionResult AdminAndSellerEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Givenname}, you are a {currentUser.Role}");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Givenname = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
