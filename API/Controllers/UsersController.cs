using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// /api/users
[Authorize]
public class UsersController(DataContext context) : BaseApiController
{
    [HttpGet] // /api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync(); // Accediendo a tabla users y convirtiendo a lista

        return Ok(users);    

    }

    [HttpGet("{id:int}")] // /api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

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