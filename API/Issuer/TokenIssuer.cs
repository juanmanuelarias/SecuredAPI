using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Issuer
{
    public class TokenIssuer
    {
        private Dictionary<string, string> audienceKeys = new Dictionary<string, string>();

        public JWE GenerateToken(AsymmetricKey key)
        {
            var token = new JWE()
            {
                Issuer = "http://wsgateway.personal.com.ar",
                Audience = "http://autogestion.personal.com.ar",
                AsymmetricKey = key.PublicKey
            };

            token.AddClaim("linea", "1134445555");

            return token;
        }
    }
}