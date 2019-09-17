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
using System.Net;

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
        public async Task<IActionResult> Index()
        {
            await WriteOutIdentityInformation();
            
            var httpClient = await _blogsHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/blogs").ConfigureAwait(false);

            if(response.IsSuccessStatusCode)
            {
                return Json(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            else if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }

            throw new Exception($"A problem happen when calling the API: {response.ReasonPhrase}");
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
