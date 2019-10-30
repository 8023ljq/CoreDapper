using System.IO;
using CoreDapperCommon.CommonEnum;
using CoreDapperCommon.CommonMethod;
using Microsoft.AspNetCore.Mvc;

namespace CoreDapperApi.Controllers.Basis
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("sayhello")]
        public IActionResult SayHello()
        {
            var url = Directory.GetCurrentDirectory();

            return Ok(ReturnHelpMethod.ReturnSuccess((int)HttpCodeEnum.Http_1006));
        }
    }
}