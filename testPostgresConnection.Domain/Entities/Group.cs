using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPostgresConnection.Domain.Entities
{
    public class Group
    {
        public long groupId { get; set; }
        public string title { get; set; } = null;
        public List<Account> accounts{ get; set; }
    }
}
