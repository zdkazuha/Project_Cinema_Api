﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.Jwt
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public int LifetimeInMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
