using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIForAngularApp.Provider;

namespace WebAPIForAngularApp
{
    public partial class Startup
    {
        public  static OAuthAuthorizationServerOptions OAuthOption { get; private set; }

        static Startup()
        {
            OAuthOption = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                Provider = new OAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOption);
        }
    }
}