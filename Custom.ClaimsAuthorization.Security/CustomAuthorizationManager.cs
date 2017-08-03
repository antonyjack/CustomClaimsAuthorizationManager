using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Custom.ClaimsAuthorization.Security
{
    public class CustomAuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var Resource = context.Resource.FirstOrDefault().Value;
            var Operation = context.Action.FirstOrDefault().Value;
            var Principal = context.Principal;
            switch (Resource)
            {
                case "Home":
                    if (Operation.Equals("View"))
                        return Principal.Claims.Where(x => x.Type == ClaimTypes.Name && x.Value.Equals("admin")).Any();
                    else
                        return false;
                default:
                    return false;
            }
        }
    }
}
