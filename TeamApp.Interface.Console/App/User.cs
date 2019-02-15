using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TeamApp.Console.App
{
    public class User:IPrincipal
    {       
        public IIdentity Identity { get; private set; }

        public User(string userName)
        {            
            Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
