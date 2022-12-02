using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCore6.Back.Infrastructure.Tools
{
    public class JwtTokenSettings
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string IssuerSigningKey = "aDh*t1.6B_23!9cX";
        public const int Expire = 30;
    }
}
