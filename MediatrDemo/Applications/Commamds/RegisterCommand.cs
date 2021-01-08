using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MediatrDemo.Applications.Commamds
{
    public class RegisterCommand:IRequest<bool>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public RegisterCommand(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
