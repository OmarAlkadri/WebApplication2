﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}