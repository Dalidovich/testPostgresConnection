using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPostgresConnection.Domain.Enums;

namespace testPostgresConnection.Domain.Response.Base
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        StatusCode StatusCode { get; set; }
        public string Description { get; set; }
    }
}
