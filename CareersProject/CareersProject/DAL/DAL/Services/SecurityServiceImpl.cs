using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES
{
    public class SecurityServiceImpl: SecurityService
    {
        public void resetPassword(String username)
        {
            //TODO
        }

        public void activateAccount(String username)
        {
            AccountDAO accountDao = new AccountDAO();
            AccountDTO accountDto = accountDao.find(username);

            accountDto.status = AccountStatus.ACTIVE.ToString();
            accountDao.merge(accountDto);
        }

        public void lockAccount(String username)
        {
            AccountDAO accountDao = new AccountDAO();
            AccountDTO accountDto = accountDao.find(username);

            accountDto.status = AccountStatus.LOCKED.ToString();
            accountDao.merge(accountDto);
        }

        public void setUserRole(String username, AccountType accountType)
        {
            AccountDAO accountDao = new AccountDAO();
            AccountDTO accountDto = accountDao.find(username);

            accountDto.accountType = accountType.ToString();
            accountDao.merge(accountDto);
        }

        public void requestAccountUnlock(String username)
        {
            AccountDAO accountDao = new AccountDAO();
            AccountDTO accountDto = accountDao.find(username);

            accountDto.status = AccountStatus.UNLOCKED.ToString();
            accountDao.merge(accountDto);
        }

        public void setAccountActive(String username)
        {
            AccountDAO accountDao = new AccountDAO();
            AccountDTO accountDto = accountDao.find(username);

            accountDto.status = AccountStatus.ACTIVE.ToString();
            accountDao.merge(accountDto);
        }

    }

}
