using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntcolonyProgram.DTOModel;
using AntcolonyProgram.Models;
using AntcolonyProgram.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AntcolonyProgram.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserApiController(IUserService _userService,IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser() 
        {
            var UserList = await userService.GetAlllist();
            var companyDtos =  mapper.Map< IEnumerable<User> ,IEnumerable <UserDTO>>(UserList);
            //这里我们是通过Field字段进行查找
            //参考链接：http://www.tnblog.net/hb/article/details/2788
            //var result = companyDtos.ToDynamicIEnumerable(postParameters.Fields);
            return Ok(companyDtos);
        }
    }
}