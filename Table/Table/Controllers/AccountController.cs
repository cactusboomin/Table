using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Table.Domain;
using Table.Domain.Entities;
using Table.Models;

namespace Table.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    await Authenticate(user);

                    return Redirect("/");
                }
            }
            
            return View(model);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await this.userManager.FindByEmailAsync(model.Email);

                if (userCheck == null)
                {
                    var user = new User
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        PasswordHash = new PasswordHasher<User>().HashPassword(null, model.Password),
                    };

                    var result = await userManager.CreateAsync(user, model.Password);
                    await userManager.AddClaimAsync(user, new Claim(ClaimsIdentity.DefaultNameClaimType, model.Email));

                    if (result.Succeeded)
                    {
                        await Authenticate(user);
                        return Redirect("/");
                    }
                }
                else
                {
                    ModelState.AddModelError("", $"User with email {model.Email} already exists.");
                }
            }

            return View(model);
        }

        public async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            await this.signInManager.SignInWithClaimsAsync(user, true, claims);
        }
    }
}
