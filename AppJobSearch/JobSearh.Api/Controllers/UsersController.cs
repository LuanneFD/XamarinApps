using JobSearch.Domain.Models;
using JobSearch.Api.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Api.Controllers
{
  [Route("api/Users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly JobSearchContext _data;
    public UsersController(JobSearchContext data)
    {
      _data = data;
    }

    /// <summary>
    /// http://seusite.com.br/api/Users?email=teste@gmail.com&password=123456
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetUser(string email, string password)
    {
      User userdb = _data.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
      if (userdb == null)
      {
        return NotFound(); //HTTP - 404 - Não encontrado
      }
      return new JsonResult(userdb);
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
      _data.Users.Add(user);
      _data.SaveChanges();

      return CreatedAtAction(nameof(GetUser), new { email = user.Email, password = user.Password }, user); //HTTP 201 - Created
    }
  }
}
