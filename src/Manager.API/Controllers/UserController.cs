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

    }
}