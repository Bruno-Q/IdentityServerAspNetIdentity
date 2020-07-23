// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //// m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                //// interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},

                new Client()
                {
                   //客户端Id
                    ClientId="apiClientImpl",
                    ClientName="ApiClient for Implicit",
                    //客户端授权类型，Implicit:隐藏模式
                    AllowedGrantTypes=GrantTypes.Implicit,
                    //允许登录后重定向的地址列表，可以有多个
                   RedirectUris = {"http://localhost:30002/auth.html"},
                    //允许访问的资源
                    AllowedScopes={
                       "secretapi",
                       IdentityServerConstants.StandardScopes.OpenId,
                       "PhoneModel"
                   },
                    //允许将token通过浏览器传递
                    AllowAccessTokensViaBrowser=true,
                    //允许ID_TOKEN附带Claims
                    AlwaysIncludeUserClaimsInIdToken=true
                },
                new Client()
               {
                    AlwaysIncludeUserClaimsInIdToken=true,
                   //客户端Id
                    ClientId="apiClientHybrid",
                    ClientName="ApiClient for HyBrid",
                    //客户端密码
                    ClientSecrets={new Secret("apiSecret".Sha256()) },
                    //客户端授权类型，Hybrid:混合模式
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    //允许登录后重定向的地址列表，可以有多个
                   RedirectUris = {"https://localhost:30002/auth.html"},
                    //允许访问的资源
                    //允许访问的资源
                    AllowedScopes={
                       "secretapi",
                       IdentityServerConstants.StandardScopes.OpenId,
                       "PhoneModel"
                   },
                     AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser=true
               }


            };
    }
}