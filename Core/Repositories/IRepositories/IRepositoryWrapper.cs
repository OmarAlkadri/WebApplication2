using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        public ICastomerRepository Castomer { get; }
        public IUserRepository User { get; }
        public void Save();
    }
}
