﻿namespace Application.Common
{
    public class JwtConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpiryInMinutes { get; set; }

        public JwtConfig()
        {
        }
    }
}
