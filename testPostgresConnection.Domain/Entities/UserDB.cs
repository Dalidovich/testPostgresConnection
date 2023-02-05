using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPostgresConnection.Domain.Entities
{
    public class UserDB
    {
        [Key]
        public long userId{ get; set; }
        public string login { get; set; } = null!;
    }
}
