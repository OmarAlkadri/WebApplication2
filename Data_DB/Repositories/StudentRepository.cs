using WebApplication2.Core.Entities;
using WebApplication2.Core.Interfaces;
using WebApplication2.Data_DB;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data.Repositories
{

    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        protected Context_DB Context { get; set; }
        public StudentRepository(Context_DB Context) : base(Context)
        {
            this.Context = Context;
        }


        public async Task<bool> CheckEmail(string Email)
        {
           /* var emailList = await Context.Student.Where(f => f.Email == Email).ToListAsync();
            if (emailList.Count >= 1)
            {
                return false;
            }*/
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            var a = await(from data in Context.Student
                         select data).ToListAsync();
            return a;
        }

        public async Task<Student> GetStudentById(Guid Id)
        {
            var a = await(from data in Context.Student
                          where data.Id == Id
                          select data).FirstOrDefaultAsync();
            return a;
        }
    }
}
