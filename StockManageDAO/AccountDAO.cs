using StockManageBussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StockManageDAO
{
    public class AccountDAO
    {
        private readonly Stocks2024DBContext _context;
        private static AccountDAO? instance;
        public AccountDAO()
        {
            _context = new Stocks2024DBContext();
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
        public Account GetAccount(string email, string password)
        {

            return _context.Accounts.FirstOrDefault(a => a.Email == email && a.Password == password && a.Status == "active") ?? new Account();
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
