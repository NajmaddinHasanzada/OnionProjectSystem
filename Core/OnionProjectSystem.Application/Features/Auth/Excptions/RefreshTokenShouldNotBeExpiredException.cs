using OnionProjectSystem.Application.Bases;

namespace OnionProjectSystem.Application.Features.Auth.Excptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Your login period has expired. Please log in again!") { }
    }
}
