using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories{
    public class UserRepository : BaseRepository<User>, IUserRepository{
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users.Where(x =>x.Email.ToLower() == email.ToLower())
                                    .AsNoTracking()
                                    .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<User> GetByUsername(string username)
        {
            var user = await _context.Users.Where(x =>x.Username.ToLower() == username.ToLower())
                                    .AsNoTracking()
                                    .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByUsername(string name)
        {
            var allUsers = await _context.Users.Where(x =>x.Name.ToLower().Contains(name.ToLower()))
                                                .AsNoTracking()
                                                .ToListAsync();

            return allUsers;
        }

        public async Task<List<User>> SearchByEmail(string username){

            var allUsers = await _context.Users.Where(x => x.Name.ToLower().Contains(nameof.ToLower()))
                                            .AsNoTracking()
                                            .ToListAsync();

            return allUsers;
        }
    }
}