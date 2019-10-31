using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDapperBLL;
using CoreDapperCommon.CommonMethod;
using CoreDapperModel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreDapperApi.Controllers.CommonController
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ManagerdBLL managerdBLL = new ManagerdBLL();

        /// <summary>
        /// Author：Geek Dog  Content：后台管理员登录 AddTime：2019-5-22 15:32:55  
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
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
    }
}