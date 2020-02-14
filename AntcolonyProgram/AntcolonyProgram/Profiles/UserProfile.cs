using AntcolonyProgram.DTOModel;
using AntcolonyProgram.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntcolonyProgram.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>()
                .ForMember(A=>A.LocationPhone,B=>B.MapFrom(src => src.Phone));
        }
    }
}
