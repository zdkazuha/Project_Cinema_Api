﻿namespace BusinessLogic.DTOs.Jwt
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationDays { get; set; }
        public string Issuer { get; set; }
    }
}
