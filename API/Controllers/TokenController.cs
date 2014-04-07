using API.Issuer;
using API.Models;
using API.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace API.Controllers
{
    public class TokenController : ApiController
    {
        private TokenIssuer tokenIssuer;
        private KeyIssuer keyIssuer;
        private ClientValidator clientValidator;
        private UserValidator userValidator;

        public TokenController()
        {
            tokenIssuer = new TokenIssuer();
            keyIssuer = new KeyIssuer();
            clientValidator = new ClientValidator();
            userValidator = new UserValidator();
        }

        public HttpResponseMessage Post(FormDataCollection body)
        {
            var headers = Request.Headers;
            var authorization = Request.Headers.Authorization;
            var username = body.Get("username");
            var password = body.Get("password");

            if (clientValidator.Validate(authorization) && userValidator.Validate(username, password))
            {
                var key = keyIssuer.GenerateAsymmetricKeyHarcoded();
                var token = tokenIssuer.GenerateToken(key);

                var accessToken = new
                {
                    access_token = token.ToString()
                };

                return Request.CreateResponse(HttpStatusCode.OK, accessToken);
            }

            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}
