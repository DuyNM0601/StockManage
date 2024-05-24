using StockManageBussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManageRepo
{
    public interface IAccountRepository
    {
        public Account GetAccount(string email, string password);
        public IEnumerable<Account> GetAccounts();
    }
}
