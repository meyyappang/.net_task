using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_web_api.Context;
using Todo_web_api.Models;

namespace Todo_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CRUDContext _CRUDContext;
        public LoginController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var Userdetails = _CRUDContext.Sign_Ups.AsQueryable();
            return Ok(Userdetails);
        }
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] Sign_up userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _CRUDContext.Sign_Ups.Add(userObj);
                _CRUDContext.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Signup successfully"

                });
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Sign_up userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _CRUDContext.Sign_Ups.Where(a =>
                a.UserName == userObj.UserName && a.Password == userObj.Password).FirstOrDefault();
                if(user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully",
                        UserData = userObj.FullName
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }

    }
}
