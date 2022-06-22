using WebApplication2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Entities
{
    public class Student : IBaseEntity
    {
        public Guid Id { get; set; }
        public User User { get; set; }
    }
}