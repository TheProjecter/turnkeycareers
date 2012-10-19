using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Inbox.User
{
    public interface IUserView
    {
        

        void showFeedback(String feedback);
        void hideFeedback();
    }
}
