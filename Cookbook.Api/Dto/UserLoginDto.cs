using System.Security;

namespace Cookbook.Api.Dto
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
