using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Inbox.User
{
    public interface IUserView
    {
        String getUsername();
        void setUsername(String username);
        String getVacancyNumber();
        void setVacancyNumber(String vacancyNumber);
        String getMessage();
        void setMessage(String message);

    }
}
