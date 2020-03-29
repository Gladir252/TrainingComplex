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
    }
}