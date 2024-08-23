using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<MemberDTO> GetMemberAsync(string username)
        {

            //Con AutoMapper
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            ////// Without AutoMapper
            // return await _context.Users
            //     .Where(x => x.UserName == username)
            //     .Select(user => new MemberDTO //Proyectando el user en un DTO para no hacer select de todo los campos de la tabla en la BD
            //     {
            //         Id = user.Id,
            //         UserName = user.UserName,
            //         KnownAs = user.KnownAs,
            //     }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersAsync()
        {
            return await _context.Users
                //El ProjectTo se encarga de hacer la relacion de MemberDTO con PhotoDTO, y ya no se especifica con un Include
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider) //Hara select de los campos que tenga MemberDTo (Internamente mappea de AppUser a MemberDTO)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.Photos) //Incluir relacion de user->photos
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            //Esto es para decirle a Entity Framework que el usuario ha sido modificado
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}