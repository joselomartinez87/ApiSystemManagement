using Microsoft.IdentityModel.Tokens;
using SystemManagement.Common.Security;
using SystemManagement.MethodParameters.Authentication.JwtManager;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SystemManagement.Business.Authentication
{
    public class JwtManager
    {

        #region Properties

        private static string TokenSecret
        {
            get { return ConfigurationManager.AppSettings["JwtSecret"]; }
        }

        private int TokenExpireMinutes
        {
            get { return int.Parse(ConfigurationManager.AppSettings["JwtExpireMinutes"]); }
        }

        #endregion Properties

        public GenerateTokenOut GenerateToken(GenerateTokenIn input)
        {
            var output = new GenerateTokenOut();
            AES256 securityAES256 = new AES256();
            var expireMinutes = TokenExpireMinutes;
            var symmetricKey = Convert.FromBase64String(TokenSecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                   {
                        new Claim("sessionId",input.sessionId),
                        new Claim("usrID", input.usrID.ToString())
                    }),

                Expires = now.AddMinutes(expireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            output.token = securityAES256.Encrypt(token);
            return output;
        }

        public ValidateTokenOut ValidateToken(ValidateTokenIn input)
        {
            var output = new ValidateTokenOut();
            AES256 aes256 = new AES256();
            string tokenDecrypt = aes256.Decrypt(input.token);
            // Se obtiene la información del token
            ClaimsPrincipal simplePrinciple = GetPrincipal(tokenDecrypt);
            if (simplePrinciple != null)
            {
                // Se obtienen las propiedades 
                var identity = simplePrinciple.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    // Si no esta autenticado se denega el acceso
                    if (identity.IsAuthenticated)
                    {
                        // Se obtienen las variables de las propiedades que se le asignaron al Token cuando se genero
                        var sessionId = identity.FindFirst("sessionId");
                        var usrID = identity.FindFirst("usrID");
                        var ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                        if (sessionId?.Value != null
                            && usrID?.Value != null
                            && ip != null)
                        {
                            var autentication = new SystemManagement.Business.Authentication.Authentication();
                            var validateSessionOut = autentication.ValidateSession(new MethodParameters.Authentication.ValidateSessionIn()
                            {
                                sessionId = sessionId.Value,
                                userId = Convert.ToDecimal(usrID.Value)
                            });
                            if (validateSessionOut.result == Entities.Common.Result.Success
                                && validateSessionOut.session.usrID == Convert.ToDecimal(usrID.Value)
                                && validateSessionOut.session.sesID == sessionId.Value
                                && validateSessionOut.session.ses_status == "V")
                            {
                                output.tokenInformation = new Entities.Authentication.TokenInformation();
                                output.tokenInformation.sessionId = sessionId.Value;
                                output.tokenInformation.usrID = usrID.Value;
                            }
                        }
                    }
                }
            }
            return output;
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null)
                {
                    return null;
                }
                else
                {
                    var dateTime = DateTime.UtcNow;
                    var dateTimeOffset = new DateTimeOffset(dateTime);
                    var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();
                    if (jwtToken.Payload != null)
                    {
                        if (unixDateTime > jwtToken.Payload.Exp) return null;
                    }
                }
                var symmetricKey = Convert.FromBase64String(TokenSecret);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
