﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
