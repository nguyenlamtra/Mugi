using System.Collections.Generic;

namespace Mugi.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string UserName { set; get; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }

        //public virtual ICollection<RoleAccount> RoleAccounts { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}