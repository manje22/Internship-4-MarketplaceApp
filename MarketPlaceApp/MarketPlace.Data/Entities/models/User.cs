﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.models
{
    public class User
    {
        public User(string name, string email)
        {
            Name = name; Email = email;
        }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
