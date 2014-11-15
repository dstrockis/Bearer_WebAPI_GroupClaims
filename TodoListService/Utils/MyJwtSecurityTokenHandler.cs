using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web.Helpers;

namespace TodoListService.Utils
{
    class MyJwtSecurityTokenHandler : JwtSecurityTokenHandler
    {
        public override ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            SecurityToken st = null; 
            ClaimsPrincipal cp = base.ValidateToken(securityToken, validationParameters, out st);
            if (st != null)
            {
                validatedToken = st;
                ClaimsIdentity ci = cp.Identity as ClaimsIdentity;

                if (ci.FindFirst("_claim_names") != null && (Json.Decode(claimsId.FindFirst("_claim_names").Value)).groups != null)
                {
                    // Lookup the groups from the graph, add group claims to ci.
                }

                foreach (Claim groupclaim in ci.FindAll("groups"))
                {
                   // Translate the group claims into role claims
                }
                return new ClaimsPrincipal(ci);
            }
            else 
            {
                throw new SecurityTokenValidationException("something weird happened");
            }
        }
    }
}
