using Cookbook.Api.Entities;
using MediatR;

namespace Cookbook.Api.Features.Auth
{
    public class Register : IRequest<User>
    {
        public string UserName { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Register(string userName, string passWord, string firstName, string lastName)
        {
            UserName = userName;
            Password = passWord;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
