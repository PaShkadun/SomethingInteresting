using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace NewIdentity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Api2", "NewIdentity"),
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("Shop", "NewIdentity"),
                new ApiScope("Company", "NewIdentity")
            };
        }

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris =           { "http://localhost:8080/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:8080/" },
                    AllowedCorsOrigins =     { "http://localhost:8080" },

                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "Company",
                        "Shop"
                    }
                },

                // machine to machine client
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets = { new Secret("secret".Sha256()) },

                    RequireClientSecret = false,

                    ClientId = "client",
                    ClientName = "Web",
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 600,
                    IdentityTokenLifetime = 600,
                    IncludeJwtId = true,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { "http://localhost:8080/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:8080" },

                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:8080"
                    },

                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "Api1"
                    }
                },
                
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Api1"
                    }
                }
            };
    }
}
