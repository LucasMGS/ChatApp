using Chat.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Chat.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        public readonly IHttpContextAccessor _acessor;
        public CurrentUser(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }
        public Guid? Id => ObterId();
        private void x()
        {
            //_acessor.HttpContext.User.Identities.Any(x => x.HasClaim)
        }
        public bool? IsAuthenticated => _acessor.HttpContext?.User?.Identity?.IsAuthenticated;

        private Guid? ObterId()
        {
            var idClaim = _acessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            return Guid.TryParse(idClaim?.Value, out var guidId) ? guidId : null;
        }
    }
}
