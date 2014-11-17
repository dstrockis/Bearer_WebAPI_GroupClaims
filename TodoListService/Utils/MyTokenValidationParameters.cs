using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace TodoListService.Utils
{
    class MyTokenValidationParameters : TokenValidationParameters
    {
        public override ClaimsIdentity CreateClaimsIdentity(SecurityToken securityToken, string issuer)
        {
            JwtSecurityToken jwt = securityToken as JwtSecurityToken;
            ClaimsIdentity ci = base.CreateClaimsIdentity(securityToken, issuer);
            foreach (Claim claim in jwt.Claims)
            {
                // check for overage claim

                // map group claims to roles
            
            }
            return; 
        }
    }
}
