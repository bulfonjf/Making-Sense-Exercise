using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IDP
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Juan",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Juan"),
                        new Claim("family_name", "Bulfon"),
                        new Claim("role", "Author"),
                    }
                },
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                     new List<string>() { "role" }),
            };
        }
        public static IEnumerable<Client> GetClients(string uiEndpoint)
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "BlogsUI",
                    ClientId = "blogclient",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 120,       
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RedirectUris = new List<string>()
                    {
                        $"{uiEndpoint}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        $"{uiEndpoint}/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "blogapi",
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
             };

        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("blogapi", "Blog API",
                new List<string>() {"role" } )
                {
                     ApiSecrets = { new Secret("apisecret".Sha256()) }
                }

            };
        }
    
    }
}