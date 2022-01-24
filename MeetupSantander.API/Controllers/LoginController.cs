using AutoMapper;
using MeetupSantander.API.Contract.DTO;
using MeetupSantander.API.Domain;
using MeetupSantander.API.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeetupSantander.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService { get; set; }
        private IConfiguration _config;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration config, IMapper mapper, IUserService userService)
        {
            _config = config;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserDTO userDTOLoginRequest)
        {
            // Performs login for a user
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(_mapper.Map<User>(userDTOLoginRequest));

            if (user != null)
            {
                var tokenString = GenerateToken(user);

                LoginDTO loginDTO = new LoginDTO();
                loginDTO.Id = user.Id;
                loginDTO.Name = user.Name;
                loginDTO.Role = user.Role;
                loginDTO.Username = user.Username;
                loginDTO.Token = tokenString;

                response = Ok(loginDTO);
            }

            return response;
        }

        private string GenerateToken(User userInfo)
        {
            // Generate the JWT for the API requests
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Role),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User userLogin)
        {
            // Look for user credentials in the database
            return _userService.userLogin(userLogin.Username, userLogin.Password);
        }

    }
}