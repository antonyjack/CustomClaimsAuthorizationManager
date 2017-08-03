using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Custom.ClaimsAuthorization.Security
{
    public class CustomPrincipal
    {
        string Name = string.Empty;

        public CustomPrincipal(string name)
        {
            Name = name;
        }

        private List<Claim> GenerateClaims()
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, Name)
            };
        }

        public ClaimsPrincipal GeneratePrincipal()
        {
            return new ClaimsPrincipal(new ClaimsIdentity(GenerateClaims(), "Forms"));
        }
    }
}
