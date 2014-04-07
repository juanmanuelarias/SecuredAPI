using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace API.Validators
{
    public class ClientValidator
    {
        /// <summary>
        /// user = 0123456789
        /// password = TXVtJ3MgdGhlIHdvcmQhISE=
        /// </summary>
        /// <param name="encodedCredentials">MDEyMzQ1Njc4OTpUWFZ0SjNNZ2RHaGxJSGR2Y21RaElTRT0=</param>
        /// <returns></returns>
        public bool Validate(AuthenticationHeaderValue authorization)
        {
            if (authorization == null || authorization.Scheme != "Basic" || authorization.Parameter == string.Empty)
            {
                return false;
            }

            var encodedCredentials = authorization.Parameter;

            var data = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.UTF8.GetString(data).Split(':');

            var user = credentials[0];
            var pass = credentials[1];

            return user == "0123456789" && pass == "TXVtJ3MgdGhlIHdvcmQhISE=";
        }
    }
}