using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);
        Task<List<User>> SearchByUsername(string username);
        Task<List<User>> SearchByEmail(string username);
    }
}