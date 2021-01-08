using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MediatrDemo.Applications.Events
{
    public class RegisterSucEvent : INotification
    {
        public string Email { get; private set; }

        public RegisterSucEvent(string email)
        {
            Email = email;
        }
    }
}
