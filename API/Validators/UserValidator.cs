using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Validators
{
    public class UserValidator
    {
        public bool Validate(string username, string password)
        {
            return username == "juan" && password == "juan";
        }
    }
}