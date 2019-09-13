using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Services;

namespace Client.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogHttpClient _blogsHttpClient;

        public BlogsController(IBlogHttpClient blogsHttpClient)
        {
            _blogsHttpClient = blogsHttpClient;
        }

        [Authorize]
        public async Task<string> Index()
        {
            await WriteOutIdentityInformation();
            return "hola blogs";
        }

        public async Task WriteOutIdentityInformation()
        {
            // get the saved identity token
            var identityToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            // write it out
            Debug.WriteLine($"Identity token: {identityToken}");

            // write out the user claims
            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }
}
