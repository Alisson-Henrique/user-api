using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly Mapper _mapper;

        private readonly IUserRepository _userRepository;
        
        public UserService(Mapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        
        public async Task<UserDTO> Create(UserDTO userDto)
        {
            var userExists = await _userRepository.GetByUsername(userDto.Username);

            if (userExists != null)
            {
                throw new DomainException("já existe usuario com esse nome.");
            }
            var user = _mapper.Map<User>(userDto);
            user.Validate();
            
            var userCreated = await _userRepository.Create(user);
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDto)
        {
            var userExists = await _userRepository.Get(userDto.Id);

            if (userExists == null)
                throw new DomainException("Esse usuario não está cadastrado.");

            var user = _mapper.Map<User>(userDto);
            user.Validate();
            
            var userUpdated = await _userRepository.Update(user);
            
            return _mapper.Map<UserDTO>(userUpdated);

        }

        public async Task<UserDTO> Get(long id)
        {
            var userExists = await _userRepository.Get(id);

            if (userExists == null)
                throw new DomainException("Não tem cadastro desse usuário.");

            return _mapper.Map<UserDTO>(userExists);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
            
        }

        public async Task<List<UserDTO>> SearchByUsername(string username)
        {
            var users = await _userRepository.SearchByUsername(username);

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var users = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByUsername(string username)
        {
            var userExists = await _userRepository.GetByUsername(username);

            if (userExists == null)
                throw new DomainException("Não tem usuário com esse nome.");

            return _mapper.Map<UserDTO>(userExists);
        }
    }
}