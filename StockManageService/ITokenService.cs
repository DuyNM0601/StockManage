﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManageService
{
    public interface ITokenService
    {
        public string GenerateToken(string email);
    }
}
