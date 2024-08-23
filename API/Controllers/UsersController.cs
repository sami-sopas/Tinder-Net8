using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
// /api/users
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();

        //Convertir el IEnumerable<AppUser> a IEnumerable<MemberDTO>
        // var usersToReturn = _mapper.Map<IEnumerable<MemberDTO>>(users);

        return Ok(users);    

    }

    [HttpGet("{username}")] // /api/users/lisa
    public async Task<ActionResult<MemberDTO>> GetUser(string username)
    {
        var user = await _userRepository.GetMemberAsync(username);

        if(user == null) return NotFound();

        // var userToReturn = _mapper.Map<MemberDTO>(user);

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