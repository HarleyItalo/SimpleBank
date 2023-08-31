using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.Constants
{
    public class Messages
    {
        public const string TRANSACTION_SUCCESS = "Successfully completed transaction";
        public const string TRANSACTION_NOT_AUTORIZATED = "Your transaction was not authorized because you do not have enough balance.";
        public const string TRANSACTION_NOT_AUTORIZATED_INVALID_VALUE = "Your transaction was not authorized because you choose a invalid value";

        public const string DATABASE_ERROR = "An error ocorred with database enter in contact with SimpleBank ";
    }
}