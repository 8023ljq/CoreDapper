using CoreDapperCommon.CommonEnum;
using CoreDapperCommon.CommonMethod;
using CoreDapperModel.CommonModel;
using CoreDapperModel.DBModel;
using CoreDapperModel.ViewModel;
using System;

namespace CoreDapperBLL
{
    /// <summary>
    /// 管理员业务处理层
    /// </summary>
    public class ManagerdBLL : BaseBLL
    {
        /// <summary>
        /// 管理员登录操作
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="GetLoginIp"></param>
        /// <returns></returns>
        public ResultMsg ManagerLogin(LoginModelRequest Model, string GetLoginIp = "127.0.0.1")
        {
            Sys_Manager managerModel = baseDAL.GetModelAll<Sys_Manager>("Name=@Name", new { Name = Model.UserName });

            //检查用户是否存在
            if (managerModel == null)
            {
                return ReturnHelpMethod.ReturnWarning((int)HttpCodeEnum.Http_1002);
            }

            //检查密码
            string PassWord = DESEncryptMethod.Encrypt(Model.PassWord, managerModel.RandomCode);
            if (PassWord != managerModel.Password)
            {
                return ReturnHelpMethod.ReturnWarning((int)HttpCodeEnum.Http_1002);
            }

            //查询用户角色
            Sys_ManagerRole managerroleModel = baseDAL.GetModelById<Sys_ManagerRole>(managerModel.RelationId);

            //返回管理员信息
            ManagerReturnModel adminModel = new ManagerReturnModel()
            {
                UserId = managerModel.Id,
                AdminName = String.IsNullOrEmpty(managerModel.Nickname) ? managerModel.Name : managerModel.Nickname,
                Avatar = managerModel.Avatar,
                RoleName = managerroleModel.RoleName,
                RegisteTime = managerroleModel.AddTime.Value,
            };

            //登录成功报存管理员信息
            string Token = DESEncryptMethod.Encrypt(managerModel.Id.ToString(), ExpandMethod.GetTimeStamp());

            //处理单点登录问题
            //if (!String.IsNullOrEmpty(managerModel.TokenId))
            //{
            //    redis.KeyDelete(managerModel.TokenId);
            //}

            managerModel.TokenId = Token;
            managerModel.LoginTimes = managerModel.LoginTimes + 1;
            managerModel.LastLoginIP = GetLoginIp;
            managerModel.LastLoginTime = DateTime.Now;

            RedisManagerModel redisManagerModel = new RedisManagerModel()
            {
                Id = managerModel.Id,
                RelationId = managerModel.RelationId,
                Name = managerModel.Name,
                Avatar = managerModel.Avatar,
                Nickname = managerModel.Nickname,
                Phone = managerModel.Phone,
                Email = managerModel.Email,
                LoginTimes = managerModel.LoginTimes,
                LastLoginIP = managerModel.LastLoginIP,
                LastLoginTime = managerModel.LastLoginTime,
                IsDefault = managerModel.IsDefault,
                Remarks = managerModel.Remarks,
            };

            redis.StringSet(Token, redisManagerModel, TimeSpan.FromMinutes(30));

            baseDAL.UpdateModel<Sys_Manager>(managerModel);

            return ReturnHelpMethod.ReturnSuccess((int)HttpCodeEnum.Http_1001, new { Data = adminModel, Token = Token });
        }
    }
}
