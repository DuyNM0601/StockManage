using StockManageBussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManageService
{
    public interface IAccountService
    {
        public Account GetAccount(string email, string password);
        IEnumerable<Account> GetAccounts();
        public bool isUser(string email, string password);
    }
}
