using OnionProjectSystem.Application.Bases;

namespace OnionProjectSystem.Application.Features.Auth.Excptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("No such email address found!") { }
    }
}
