using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPostgresConnection.Domain.Entities
{
    public class Account
    {
        public long accountId{ get; set; }
        public string login { get; set; } = null!;
        public string password { get; set; } = null!;
        public string about { get; set; } = null!;
        public long groupId { get; set; }
        public Group group { get; set; } = null;
    }
}
