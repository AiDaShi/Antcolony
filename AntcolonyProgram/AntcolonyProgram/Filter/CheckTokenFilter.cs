using AntcolonyProgram.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AntcolonyProgram.JWT.TokenHelper;

namespace AntcolonyProgram.Filter
{
    public class CheckTokenFilter : Attribute, IActionFilter
    {
        private ITokenHelper tokenHelper;
        public CheckTokenFilter(ITokenHelper _tokenHelper) //通过依赖注入得到数据访问层实例
        {
            tokenHelper = _tokenHelper;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            #region JWT验证过滤

            //ReturnModel returnModel = new ReturnModel();
            //string token = context.HttpContext.Request.Query["token"];
            //获取地址中的token(默认取最长的一个)
            //string path = context.HttpContext.Request.Path;
            //string[] strArray = path.Split('/');
            //string token = strArray.OrderByDescending(a => a.Length).First();
            //获取token

            object tokenobj = context.HttpContext.Request.Cookies["VailCode"];

            if (tokenobj == null)
            {
                context.HttpContext.Response.Redirect("/LoginHandle/LoginPage");
                return;
            }

            string token = tokenobj.ToString();

            string userId = "";
            //验证jwt,同时取出来jwt里边的用户ID
            TokenType tokenType = tokenHelper.ValidatePlus(token, a => a["iss"] == "Antcolony" && a["aud"] == "HB", action => { userId = action["userId"]; });
            if (tokenType == TokenType.Fail)
            {
                context.HttpContext.Response.Redirect("/LoginHandle/LoginPage");
            }
            if (tokenType == TokenType.Expired)
            {
                context.HttpContext.Response.Redirect("/LoginHandle/LoginPage");
            }
            if (string.IsNullOrEmpty(userId))
            {
                context.HttpContext.Response.Redirect("/LoginHandle/LoginPage");
            }
            //给控制器传递参数(需要什么参数其实可以做成可以配置的，在过滤器里边加字段即可)
            context.ActionArguments.Add("userId", Convert.ToInt32(userId));
            #endregion

            #region 查看是否拥有访问权限

            #endregion
        }
    }
}
