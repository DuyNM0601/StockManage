using StockManageBussinessObject.Models;
using StockManageDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManageRepo
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(string email, string password)
        {
            return AccountDAO.Instance?.GetAccount(email, password) ?? new Account();
        }

        public IEnumerable<Account> GetAccounts()
        {
            return AccountDAO.Instance.GetAccounts();
        }
    }
}
