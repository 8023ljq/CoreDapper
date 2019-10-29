using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDapperCommon.CommonConfig;
using Microsoft.AspNetCore.Http;
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
            return Ok(new
            {
                ResultCode = 200,
                ResultType = "success",
                ResultMsgs = GetConfigFileData.RedisDataLink,
            });
        }
    }
}