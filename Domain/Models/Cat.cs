﻿using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public string Purr()
        {
            return "This animal purrs";
        }
    }
}
