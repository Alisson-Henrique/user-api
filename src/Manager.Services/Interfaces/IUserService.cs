using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDto);

        Task<UserDTO> Update(UserDTO userDto);

        Task<UserDTO> Get(long id);

        Task<List<UserDTO>> GetAll();

        Task Remove(long id);

        Task<List<UserDTO>> SearchByUsername(string username);

        Task<List<UserDTO>> SearchByEmail(string email);

        Task<UserDTO> GetByUsername(string username);
    }
}