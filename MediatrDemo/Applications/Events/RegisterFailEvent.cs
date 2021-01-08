using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MediatrDemo.Applications.Events
{
    public class RegisterFailEvent:INotification
    {
        public string UserName { get; private set; }

        public RegisterFailEvent(string userName)
        {
            UserName = userName;
        }
    }
}
