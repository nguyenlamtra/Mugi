using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugi.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
