﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Auths
{
    public sealed class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
