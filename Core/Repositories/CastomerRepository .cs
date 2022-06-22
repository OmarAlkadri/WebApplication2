using WebApplication2.Core.Entities;
using WebApplication2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data_DB;

namespace WebApplication2.Data.Repositories
{
    public class CastomerRepository : RepositoryBase<Student>, ICastomerRepository
    {
        public CastomerRepository(Context_DB Context) : base(Context)
        {

        }
 
    }
}
