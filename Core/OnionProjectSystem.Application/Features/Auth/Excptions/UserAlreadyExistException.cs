using OnionProjectSystem.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Auth.Excptions
{
    public class UserAlreadyExistException:BaseException
    {
        public UserAlreadyExistException():base("User already exist.")
        {
        }
    }
}
