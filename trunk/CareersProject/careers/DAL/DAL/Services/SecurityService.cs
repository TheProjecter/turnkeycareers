using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES
{
    public interface SecurityService
    {
        void resetPassword(String username);
        void activateAccount(String username);
        void lockAccount(String username);
        void setUserRole(String username, AccountType accountType);
        void requestAccountUnlock(String username);
        void setAccountActive(String username);
    }

}
