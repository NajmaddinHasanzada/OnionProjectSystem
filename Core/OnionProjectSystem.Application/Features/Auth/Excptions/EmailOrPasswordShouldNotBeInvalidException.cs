using OnionProjectSystem.Application.Bases;

namespace OnionProjectSystem.Application.Features.Auth.Excptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException():base("Username or Password is not valid!")
        {
        }
    }

}
