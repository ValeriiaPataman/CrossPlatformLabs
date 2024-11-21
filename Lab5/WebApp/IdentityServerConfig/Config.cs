using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class Config
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "mvc",
                ClientSecrets = { new Secret("secret".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5000/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc"},

                AllowedScopes = { "openid", "profile", "api1" },
                RequirePkce = true,
                AllowPlainTextPkce = false
            }
        };
}

public static class StringExtensions
{
    public static string ToSha256(this string input)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashString;
        }
    }
}
