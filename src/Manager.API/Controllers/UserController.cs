using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Manager.API.ViewModels;


namespace Manager.API.Controllers{


    [ApiController]
    public class UserController : ControllerBase{

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel){

            try
            {
                return Ok();
            }
            catch (Exception)
            {
                
                return StatusCode(500, "Erro");
            }

        }

    }
}