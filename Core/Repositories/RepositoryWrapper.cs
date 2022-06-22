using WebApplication2.Core.Interfaces;
using WebApplication2.Data_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Context_DB _repoContext;
        private ICastomerRepository _Castomer;
        private IStudentRepository _Student;
        public RepositoryWrapper(Context_DB repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public ICastomerRepository Castomer
        {
            get
            {
                if (_Castomer == null)
                {
                    _Castomer = new CastomerRepository(_repoContext);
                }
                return _Castomer;
            }
        }
        public IStudentRepository Student
        {
            get
            {
                if (_Student == null)
                {
                    _Student = new StudentRepository(_repoContext);
                }
                return _Student;
            }
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
