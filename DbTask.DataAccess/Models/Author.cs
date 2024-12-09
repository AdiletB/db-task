﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTask.DataAccess.Models
{
    public class Author : Entity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
