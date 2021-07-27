using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyription
{
    public class SigningCredentialsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityKey">kullnılacak doğrulama anahtarı</param>
        /// <returns></returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
