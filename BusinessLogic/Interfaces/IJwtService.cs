﻿using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IJwtService
    {
        // ------- Access Token
        IEnumerable<Claim> GetClaims(User user);
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
