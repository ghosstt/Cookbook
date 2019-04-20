using MediatR;

namespace Cookbook.Api.Features.Auth
{
    public class Login : IRequest<string>
    {
        public string UserName { get; }
        public string Password { get; }

        public Login(string userName, string passWord)
        {
            UserName = userName;
            Password = passWord;
        }
    }
}
