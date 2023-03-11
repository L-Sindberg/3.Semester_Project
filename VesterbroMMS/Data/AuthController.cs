using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VesterbroMMS.Data
{
    [Microsoft.AspNetCore.Mvc.Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("google-login")]
        public async Task<ActionResult> Google()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/memberinfo"
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
    }
}
