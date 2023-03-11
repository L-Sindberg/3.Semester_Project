using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VesterbroMMS.Services
{
    public class AuthService : Service
    {
        public AuthService(IConfiguration config) : base(config) { }

        public Task<List<dynamic>> QueryPassword(string email)
        {
            string sql = "SELECT Members.id, Passwords.password FROM Passwords JOIN Members ON Members.email = @email WHERE Passwords.member_id = Members.id";

            Task<List<dynamic>> password = _dataAccess.LoadData<dynamic, dynamic>(sql, new { email = email }, _config.GetConnectionString("default"));

            return password;
        }

        public async Task<bool> AuthenticateLogin(string email)
        {
            string sql = "SELECT Members.email FROM Members WHERE @email = Members.email";

            List<string> result = await _dataAccess.LoadData<string, dynamic>(sql, new { email = email }, _config.GetConnectionString("default"));

            if (result.Count == 0)
            {
                return false;
            } else
            {
                return result[0].Equals(email);
            }
        }
    }
}
