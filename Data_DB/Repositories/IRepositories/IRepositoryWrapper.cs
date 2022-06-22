using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
         public IStudentRepository Student { get; }
        public void Save();
    }
}
