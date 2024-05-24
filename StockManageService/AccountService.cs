    using StockManageBussinessObject.Models;
    using StockManageRepo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace StockManageService
    {
        public class AccountService : IAccountService
        {
            private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccount(string email, string password)
            {
                return _accountRepository.GetAccount(email, password);
            }

            public IEnumerable<Account> GetAccounts()
            {
                var accounts = _accountRepository.GetAccounts();
                return accounts;
            }

            public bool isUser(string email, string password)
            {
                Account account = _accountRepository.GetAccount(email, password);
                if (account == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
