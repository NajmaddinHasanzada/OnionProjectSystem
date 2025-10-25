using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Auth.RefreshToken
{
    public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
