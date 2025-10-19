using Microsoft.AspNetCore.Http;
using OnionProjectSystem.Application.Interfaces.AutoMapper;
using OnionProjectSystem.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Bases
{
    public class BaseHandler
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly string userId;
        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor ) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
