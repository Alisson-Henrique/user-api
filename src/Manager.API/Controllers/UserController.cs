using System;
using System.Threading.Tasks;
using AutoMapper;
using Manager.API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
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
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel){

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
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
            
        }

        [HttpGet]
        [Route("/api/v1/get/{id}")]
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
            catch (Exception e)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
            
            
        }
        [HttpDelete]
        [Route("/api/user/remove/{id}")]
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
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
        }
    }
}