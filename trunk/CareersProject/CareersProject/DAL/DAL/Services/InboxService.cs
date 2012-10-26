
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using careers.SERVICES.Search;


namespace careers.SERVICES
{
    public interface InboxService
    {
        List<InboxDTO> getApplicantMessages(String username, String vacancyNumber);

        int getNumberOfInboxMessages(String username);
        void setMessagesRead(String username, String vacancyNumber);
        bool hasUnreadMessage(String username);

        String getInboxMessage(String username, String vacancyNumber, String status);

    }

}
