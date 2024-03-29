﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TM.DependencyInjection.OptionModels;
using TM.WebApp.Models;
using System.Security.Claims;

namespace TMWebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AccountOption _adminAccount;

        public AuthenticationController(IOptions<AccountOption> _adminAccountOptions)
        {
            _adminAccount = _adminAccountOptions.Value;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // here will be our logic to compare user from database or any other user provider
            if(!(model.Email == _adminAccount.Email && model.Password == _adminAccount.Password))
            {
                return RedirectToAction(nameof(Login));
            }
            try
            {
                // creating list of claims
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email)
            };
                // claims identitiy 
                var claimIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                // creating claims principal object to pass to the singn in method
                var claimsPricipal = new ClaimsPrincipal(claimIdentity);
                // signing in
                await HttpContext.SignInAsync(claimsPricipal);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception exp) {
                return View(model); 
            }
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
