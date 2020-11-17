using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Models.DTO.User;


namespace NetCoreApi.Controllers
{
	[ApiController]
	public class UserController : ControllerBase
	{
        [HttpPost("/v1/users")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public DUserCreateReq CreateUser([FromBody] DUserCreateReq model)
        {
            throw new System.Exception("Erro");
            //return model;
        }
    }
}
