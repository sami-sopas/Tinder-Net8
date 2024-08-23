using System;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
// /api/users
public class UsersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();

        return Ok(users);    

    }

    [Authorize]
    [HttpGet("{id:int}")] // /api/users/3
    public async Task<ActionResult<AppUser>> GetUsers(int id)
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