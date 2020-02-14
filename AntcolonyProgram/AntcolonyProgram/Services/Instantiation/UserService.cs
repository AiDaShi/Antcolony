using AntcolonyProgram.Models;
using AntcolonyProgram.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntcolonyProgram.Services.Instantiation
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(AntcolonyContext dbContentFactory)
            :base(dbContentFactory)
        {

        }
    }
}
