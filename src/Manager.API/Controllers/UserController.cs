using System;
using System.Threading.Tasks;
using AutoMapper;
using Manager.API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.API.Controllers{


    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        
        private readonly IUserService _userService;
        
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        
        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var user = await _userService.Create(userDTO);
                return Ok(new ResultViewModel{Message = "Usuário criado",Data = user,Success = true});
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErrorMessage(message: exception.Message,exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDTO>(userViewModel);
                var user = await _userService.Update(userDto);
                return Ok(new ResultViewModel{Message = "Usuario editado com sucesso!",Data = user,Success = true});
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErrorMessage(exception.Message,exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
            
        }

        [HttpGet]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);
                if (user == null)
                {
                    return Ok(new ResultViewModel
                        {Message = "Nenhum usuario foi encontrado.", Data = user, Success = true});
                }

                return Ok(new ResultViewModel {Message = "Usuario encontrado!", Data = user, Success = true});
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErrorMessage(exception.Message,exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usersDtos = await _userService.GetAll();

                return Ok(new ResultViewModel
                    {
                        Message = "Todos os usuarios trazidos com sucesso.", 
                        Success = true, 
                        Data = usersDtos
                    });
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
            
        }

        [HttpGet]
        [Route("/api/v1/users/search-by-username/{username}")]
        public async Task<IActionResult> SearchByUsername(string username)
        {
            try
            {
                var user = await _userService.SearchByUsername(username);
                return Ok(new ResultViewModel{Message = "Usuario encontrado!",Success = true,Data = user});
            }
            catch (DomainException)
            {
                return Ok(new ResultViewModel {Message = "Não tem um usuário com esse nome.",Success = true,Data = null});
            }
            catch (Exception e)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        
        [HttpDelete]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);
                return Ok(new ResultViewModel {Message = "Usuario deletado com Sucesso!", Data = null, Success = true});
            }
            catch (DomainException exception)
            {
                return Ok(Responses.DomainErrorMessage(exception.Message, exception.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
        
   
    }
}