using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AntcolonyProgram.JWT.TokenHelper;

namespace AntcolonyProgram.JWT
{
    public static class CheckToken
    {
        public static ReturnModelJwt Check(string token, ITokenHelper tokenHelper, out string userId)
        {
            userId = "";

            ReturnModelJwt returnModel = new ReturnModelJwt();
            if (string.IsNullOrEmpty(token))
            {
                returnModel.Code = 401;
                returnModel.Msg = "token不能为空";
                return returnModel;
            }
            //从依赖注入容器获取token帮助类
            //ITokenHelper tokenHelper = EngineContext.Current.Resolve<ITokenHelper>();
            string ruserId = "";
            //验证jwt,同时取出来jwt里边的用户ID
            TokenType tokenType = tokenHelper.ValidatePlus(token, a => a["iss"] == "Antcolony" && a["aud"] == "HB", action => { ruserId = action["userId"]; });
            if (tokenType == TokenType.Fail)
            {
                returnModel.Code = 402;
                returnModel.Msg = "token验证失败";
                return returnModel;
            }
            if (tokenType == TokenType.Expired)
            {
                returnModel.Code = 405;
                returnModel.Msg = "token已经过期";
                return returnModel;
            }
            userId = ruserId;
            returnModel.Code = 200;
            returnModel.Msg = "成功";
            return returnModel;


            //使用方法
            //ITokenHelper tokenHelper = HttpContext.RequestServices.GetService(typeof(ITokenHelper)) as ITokenHelper;
            //string userid = "";
            //var resultMo = CheckToken.Check(token, tokenHelper, out userid);
            //if (resultMo.Code != 200)//只有200成功
            //{
            //    return resultMo;
            //}
        }
    }
}
