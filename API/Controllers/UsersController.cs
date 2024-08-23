using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
// /api/users
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    private readonly IUserRepository _userRepository = userRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();

        return Ok(users);    

    }

    [HttpGet("{username}")] // /api/users/lisa
    public async Task<ActionResult<AppUser>> GetUsers(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);

        if(user == null) return NotFound();

        return user;    

    }
}


/*Esto...

   private readonly DataContext _context = context;

    public UsersController(DataContext context)
    {
        this._context = context;
    }

Es lo mismo que esto... (Primary Constructor)
public class UsersController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

*/