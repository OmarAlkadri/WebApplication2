using WebApplication2.Core.Interfaces;

namespace WebApplication2.Core
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}