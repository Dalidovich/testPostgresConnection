using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPostgresConnection.Domain.Enums
{
    public enum StatusCode
    {
        //Code
        CodeNotFound = 0,
        CodeCreate = 1,
        CodeRead = 2,
        CodeUpdate = 3,
        CodeDelete = 4,

        //Account
        AccountNotFound = 10,
        AccountCreate = 11,
        AccountRead = 12,
        AccountUpdate = 13,
        AccountDelete = 14,
        AccountAuthentication = 15,

        //General
        OK = 200,
        InternalServerError = 500
    }
}
