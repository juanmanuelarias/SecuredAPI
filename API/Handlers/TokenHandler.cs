using API.Issuer;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace API.Handlers
{
    public class TokenHandler : DelegatingHandler
    {
        public TokenHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var headers = request.Headers;
                if (headers.Authorization != null)
                {
                    if (headers.Authorization.Scheme.Equals("Bearer"))
                    {
                        string accessToken = request.Headers.Authorization.Parameter;

                        //var token = ParseSignedToken(accessToken);
                        var token = ParseEncryptedAndSignedToken(accessToken);

                        var identity = new ClaimsIdentity(token.Claims, "Bearer");
                        var principal = new ClaimsPrincipal(identity);

                        Thread.CurrentPrincipal = principal;

                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                    }
                }

                var response = await base.SendAsync(request, cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Bearer", "error=\"invalid_token\""));
                }

                return response;
            }
            catch (Exception e)
            {

                var response = request.CreateResponse(HttpStatusCode.Unauthorized);

                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Bearer", "error=\"invalid_token\""));

                return response;
            }
        }

        private JWE ParseEncryptedAndSignedToken(string accessToken)
        {
            // Leo el token con la clave privada harcodeada, solo por eso referencia a KeyIssuer
            var issuer = new KeyIssuer();
            var key = issuer.GenerateAsymmetricKeyHarcoded();
            var token = JWE.Parse(accessToken, key.PrivateKey);

            return token;
        }
    }
}