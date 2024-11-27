using BET.Identity.Models.Login;
using BET.Identity.Models.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BET.Identity.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> RegisterUser(RegisterUser registerUser, string role)
        {
            try
            {
                var userByEmail = await _userManager.FindByEmailAsync(registerUser.Email);
                if (userByEmail != null)
                {
                    return "User with this email already exists.";
                }
                var userByUsername = await _userManager.FindByNameAsync(registerUser.UserName);
                if (userByUsername != null)
                {
                    return "Username already exists.";
                }

                if (!await _roleManager.RoleExistsAsync(role))
                {
                    return "Role does not exist.";
                }

                IdentityUser user = new IdentityUser
                {
                    Email = registerUser.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerUser.UserName
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return "Failed to create user.";
                }

                await _userManager.AddToRoleAsync(user, role);
                return "User created successfully.";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                    var userRoles = await _userManager.GetRolesAsync(user);

                    foreach (var role in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var jwtToken = GetToken(authClaims);
                    return new JwtSecurityTokenHandler().WriteToken(jwtToken);
                }
                return null;
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddYears(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
