using System.Threading.Tasks;

namespace Manager.Infra.Interfaces{


    public class IUserRepository : IBaseRepository<User>{

        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);

        Task<List<User>> SearchByUsername(string username);
    }
}