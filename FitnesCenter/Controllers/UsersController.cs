using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FitnesCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FitnesCenter.VIewModels;
using FitnesCenter.Services;
using FitnesCenter.Interfaces;
using System.Security.Claims;

namespace FitnesCenter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUser userService;

        public UsersController(IUser customerService)
        {
            userService = customerService;
        }

        [AllowAnonymous]
        [HttpPost, Route("auth/registration")]
        public async Task<IActionResult> UserRegistrationAsync([FromBody]ReistrationViewModel registrationViewModelPl)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ErrorCount);

            return await CreateInfoObjectResult(userService.RegistrationAsync, registrationViewModelPl);
        }

        [AllowAnonymous]
        [HttpPost, Route("auth/login")]
        public async Task<IActionResult> UserLoginAsync([FromBody]LoginViewModel loginViewModelPl)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ErrorCount);

            return await CreateInfoObjectResult(userService.LoginAsync, loginViewModelPl);
        }

        [Authorize(Roles = "Client")]
        [Authorize(Roles = "Trainer")]
        [HttpPut, Route("ChangePassword")]
        public async Task<IActionResult> EditAddress([FromBody]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.ErrorCount);

            return await CreateInfoObjectResult(userService.ChangePasswordAsync, User.FindFirstValue(ClaimTypes.Email), model);
        }

        [Authorize]
        [HttpGet, Route("GetOk")]
        public async Task<IActionResult> GetOk()
        {
            return Ok(User.Identity.IsAuthenticated);
        }
    }
}