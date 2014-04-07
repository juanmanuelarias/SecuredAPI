using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace API.Issuer
{
    public class KeyIssuer
    {
        public string GenerateSharedSymmetricKey()
        {
            // 256-bit key
            using (var provider = new RNGCryptoServiceProvider())
            {
                byte[] secretKeyBytes = new Byte[32];
                provider.GetBytes(secretKeyBytes);

                return Convert.ToBase64String(secretKeyBytes);
            }
        }

        public AsymmetricKey GenerateAsymmetricKeyHarcoded()
        {
            var key = new AsymmetricKey();
            key.PublicKey = "<RSAKeyValue><Modulus>30n0B9XGGRgRQooesUasgDBMh6UAkc1i0JMKLlc7+DvN6KyCsfxQRjU2HG5cRsJLOwmsYBioDP5dkNu6aS7757SVOayPkutEaYFlJ11IdS/KLNfCVlln0y/OH9egtwgSD6yAqHUM/Wt/VAk4apbdyWSAXIfOcw7U+/kE0eEtUHk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            key.PrivateKey = "<RSAKeyValue><Modulus>30n0B9XGGRgRQooesUasgDBMh6UAkc1i0JMKLlc7+DvN6KyCsfxQRjU2HG5cRsJLOwmsYBioDP5dkNu6aS7757SVOayPkutEaYFlJ11IdS/KLNfCVlln0y/OH9egtwgSD6yAqHUM/Wt/VAk4apbdyWSAXIfOcw7U+/kE0eEtUHk=</Modulus><Exponent>AQAB</Exponent><P>82Q4YV7ZSklIJpTHi+bARqUPssJrApRnUundTBFvk4bi106Ci47xTeX60YvG0oyoasRBB7hiot1FqVmSO5XKeQ==</P><Q>6tsjglEs5ioyx0NnYoA27l+wKrI1yABvy+Vs+SdZsSXQVbR+iJQh/HZhaZNExbscOkhabjCcaBxRrdLQO3I2AQ==</Q><DP>w2yL7Hqow4HVoczB8C3l4pMz6Jc8LsUTtTo7ypERYoXia3gJT58FV0O6QTgW+wWfUKKliFpfMF+0SEa4KImcGQ==</DP><DQ>28/tBTyq1GXsjtoEeoncX/FJdjzD34ShHmqGOxBcf1QQERdVUsmqoZu/AsxmktbUzawIj5eJ3FudCx8D7I+yAQ==</DQ><InverseQ>CcC4y9VrHMtMP2MYwJ5M22EXXDCySvrKn2S+X4s5qjeulDryMHXKDE4pZUroqFlgakHAQdHNNoCeSG3hDGR7gw==</InverseQ><D>k2q71kBo3UBqhMezo87JLIi2vgdN7PTwfEvXuOiXCzhQpYDfeKrgRLn006h4+65jBMNKLteYe5ukInMvCyqd3Aw5/IcWME9WiWyY8Zwi+42Isn4+t9NnsEt4M4DJZMxQK1VwnAT76jueXoSPc4wZd2D/B0TNfF7fhfzkbApkQAE=</D></RSAKeyValue>";

            return key;
        }
    }
}