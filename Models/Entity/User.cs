using Saad.Models.Enum;

namespace Saad.Models.Entity
{
    public class User
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public Role Userrole { get; set; } = Role.None;
    }
}
