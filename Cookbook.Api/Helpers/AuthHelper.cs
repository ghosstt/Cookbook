﻿using Cookbook.Api.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Cookbook.Api.Helpers
{
    public static class AuthHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;

                return true;
            }
        }

        public static SigningCredentials GetSigningCredentials(string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }

        public static string GenerateTokenV1(JwtOptions jwtOptions, Claim[] claims)
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                NotBefore = jwtOptions.NotBefore,
                Expires = jwtOptions.Expiration,
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = jwtOptions.SigningCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GenerateTokenV2(JwtOptions jwtOptions, Claim[] claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                notBefore: jwtOptions.NotBefore,
                expires: jwtOptions.Expiration,
                claims: claims,
                signingCredentials: jwtOptions.SigningCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwt);
        }

        public static Claim[] GenerateClaims(User user)
        {
            return new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserId.ToString(), ClaimValueTypes.String),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName, ClaimValueTypes.String),
                new Claim("test.claim", "Test Claim Value", ClaimValueTypes.String)
            };
        }
    }
}
