using WebApplication2.Core.Interfaces;

namespace WebApplication2.Core.Entities
{
    public class Student : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Vize { get; set; }
        public string Final { get; set; }
    }
}