using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntcolonyProgram.JWT;
using AntcolonyProgram.Models;
using AntcolonyProgram.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AntcolonyProgram.Controllers
{
    public class LoginHandleController : Controller
    {
        private readonly ITokenHelper tokenHelper;
        private readonly IUserService userService;
        //private IUserDAL userDAL;
        public LoginHandleController(ITokenHelper _tokenHelper,IUserService _userService)
        {
            tokenHelper = _tokenHelper;
            userService = _userService;

            //userDAL = _userDAL;
        }
        /// <summary>
        /// /LoginHandle/LoginPage
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginPage() 
        {
            return View();
        }
        public ActionResult RegisterPage() 
        {
            return View();
        }

        /// <summary>
        /// /LoginHandle/LoginNow
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ReturnModel>> LoginNow(string username, string pwd)
        {
            ReturnModel returnModel = new ReturnModel();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd))
            {
                returnModel.Code = 201;
                returnModel.Msg = "用户名密码不能为空";
                return returnModel;
            }

            User userInfo = new User() { RealyName = username, Pwd = pwd };
            //实现登录
            User user = await userService.Login(userInfo);
            if (user != null)
            {
                //给jwt提供携带的数据
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                keyValuePairs.Add("userName", user.Name);
                keyValuePairs.Add("userId", user.Id.ToString());
                Dictionary<string, string> OrtherParam = new Dictionary<string, string>();
                OrtherParam.Add("img", user.Image);
                OrtherParam.Add("UserId", user.Id.ToString());
                TnToken tnToken = tokenHelper.CreateToken(keyValuePairs, OrtherParam);
                returnModel.Code = 200;
                returnModel.Msg = "登录成功!";
                returnModel.Value = tnToken;
                Response.Cookies.Append("VailCode", returnModel.Value.TokenStr);
                return returnModel;
            }
            else
            {
                returnModel.Code = 404;
                returnModel.Msg = "登录失败!";
                return returnModel;
            }
        }

        /// <summary>
        /// /LoginHandle/RegisterNow
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ReturnModel>> RegisterNow(string username, string pwd,string phone)
        {
            ReturnModel returnModel = new ReturnModel();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(pwd))
            {
                returnModel.Code = 201;
                returnModel.Msg = "用户名密码不能为空";
                return returnModel;
            }
            var NowTime = DateTime.Now;
            User userInfo = new User() {
                RealyName = username,
                Name="Ant_"+ phone.Substring(phone.Length-1-4,4),
                Pwd = pwd,
                CreateTime = NowTime,
                UpdateTime = NowTime,
                Sex = false,
                Phone = phone,
                State = true,
                Image = "/HPlus/img/user.png"
            };
            User user1 = await userService.Add(userInfo);
            //实现登录
            User user = await userService.Login(userInfo);
            if (user != null)
            {
                //给jwt提供携带的数据
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                keyValuePairs.Add("userName", user.Name);
                keyValuePairs.Add("userId", user.Id.ToString());
                Dictionary<string, string> OrtherParam = new Dictionary<string, string>();
                OrtherParam.Add("img", user.Image);
                OrtherParam.Add("UserId", user.Id.ToString());
                TnToken tnToken = tokenHelper.CreateToken(keyValuePairs, OrtherParam);
                returnModel.Code = 200;
                returnModel.Msg = "登录成功!";
                returnModel.Value = tnToken;
                Response.Cookies.Append("VailCode", returnModel.Value.TokenStr);
                return returnModel;
            }
            else
            {
                returnModel.Code = 404;
                returnModel.Msg = "登录失败!";
                return returnModel;
            }
        }
    }
}