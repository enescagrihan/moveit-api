using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveIt.Data;
using MoveIt.Models;
using MoveIt.Models.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoveIt.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return Ok(users);
        }

        // GET api/values/email
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<User>> GetUserByEmail(string email, string password)
        {
             var user = await this._appDbContext.Users.FirstOrDefaultAsync(item => item.EMail == email && item.Password == password);
            if (user == null)
                return Unauthorized();
            // var user = await _appDbContext.Users.FirstOrDefaultAsync(e => e.EMail == email);
            // if (user != null)
            // {
                 return Ok(user);
            // }
            return NotFound();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser([FromBody] User newUser)
        {
            if (newUser != null)
            {
                _appDbContext.Users.Add(newUser);
                await _appDbContext.SaveChangesAsync();

                var users = await _appDbContext.Users.ToListAsync();
                return Ok(users);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

