using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDapperBLL;
using CoreDapperCommon.CommonMethod;
using CoreDapperModel.CommonModel;
using CoreDapperModel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDapperWebApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private ManagerdBLL managerdBLL = new ManagerdBLL();

        [HttpPost]
        [Route("loginact")]
        public IActionResult LoginAct(LoginModelRequest Model)
        {
            //数据验证
            var IsValidStr = ValidatetionMethod.IsValid(Model);
            if (!IsValidStr.IsVaild)
            {
                return Ok(ReturnHelpMethod.ReturnError(IsValidStr.ErrorMembers));
            }

            return Ok(managerdBLL.ManagerLogin(Model));
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok("1123");
        }
    }
}
