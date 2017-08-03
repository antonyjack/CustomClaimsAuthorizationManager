# How to create Custom ClaimsPreauthorizationManager?
## What is the use of ClaimsAuthorizationManager class?
>The ClaimsAuthorizationManager class provides the base implementation for a claims authorization manager.
## How to create custom ClaimsAuthorizationManager?
>To create Custom ClaimsAuthorizationManager with the help of ClaimsAuthorizationManager class.
The ClaimsAuthorizationManager class is available in System.Security.Claims namespace.
## Example : 

```C#
using System.Security.Claims;

namespace Custom.ClaimsAuthorization.Security
{
    public class CustomClaimsAuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var Resource = context.Resource.FirstOrDefault().Value;
            var Operation = context.Action.FirstOrDefault().Value;
            var Principal = context.Principal;
            switch (Resource)
            {
                //Do logic here
            }
        }
    }
}
```

## How to register CustomClaimsAuthorizationManager in Web.config file?
> First we need to create a section name inside configSections, registered type should be System.IdentityModel.Configuration.SystemIdentityModelSection.
## Example :

```xml
<configSections>       
    <section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>  
</configSections>
```

> Now, you can create section and register your CustomClaimsAuthorizationManager.
## Example :

```xml
<system.identityModel>
    <identityConfiguration>
      <claimsAuthorizationManager type="Custom.ClaimsAuthorization.Security.CustomAuthorizationManager, Custom.ClaimsAuthorization.Security"/>
    </identityConfiguration>
  </system.identityModel>
```

## How to use ClaimsAuthorizationManager?
> When you use the ClaimsPrincipalPermission class or the ClaimsPrincipalPermissionAttribute class to perform claims-based access checks in your code, the claims authorization manager that is configured for your application is called by the system to perform the check. Claims-based access checks can be performed in both web-based applications and desktop applications.

## Example : 

```C#
using System.IdentityModel.Services;
using System.Security.Permissions;

namespace Custom.ClaimsAuthorization.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "View", Resource = "Home")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
```

> The ClaimsPrincipalPermission class attribute call the CustomerClaimsAuthorizationManager CheckAccess() method. In CustomClaimsAuthorizationManager you can get the Operation, Resource name and Current Principal with the help of AuthorizationContext object.
## Example : 

```C#
using System.Security.Claims;

namespace Custom.ClaimsAuthorization.Security
{
    public class CustomAuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var Resource = context.Resource.FirstOrDefault().Value; // Resource name
            var Operation = context.Action.FirstOrDefault().Value; // Operation name
            var Principal = context.Principal; // Current Logged in user claims principal
            switch (Resource)
            {
                case "Home":
                    if (Operation.Equals("View"))
                        // Here you can check the user access permission related logic.
                    else
                        return false;
                default:
                    return false;
            }
        }
    }
}
```
