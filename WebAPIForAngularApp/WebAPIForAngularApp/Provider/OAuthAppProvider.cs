using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using WebAPIForAngularApp.Controllers;
using WebAPIForAngularApp.Models;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace WebAPIForAngularApp.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                HomeController hc = new HomeController();
                UmUserMaster user = new UmUserMaster();
                user  = hc.GetUserByCredentials(username, password);

                if(user !=null)
                {
                    
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim("UserId",user.ID.ToString())
                    };

                    ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOption.AuthenticationType);
                    context.Validated(new AuthenticationTicket(OAuthIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }

            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

    }
}