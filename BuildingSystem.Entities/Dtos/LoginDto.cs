﻿using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
      
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public User user { get; set; }
    }
}