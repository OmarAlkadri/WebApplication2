using WebApplication2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        public Task<IEnumerable<Student>> GetAllStudent();
        public Task<Student> GetStudentById(Guid Id);
    }
}
