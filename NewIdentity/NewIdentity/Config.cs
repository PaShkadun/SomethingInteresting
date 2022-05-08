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
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
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
                        StandardScopes.Profile
                    }
                },
            };
    }
}
