
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES.Search;

namespace careers.SERVICES
{
    public class InboxServiceImpl : InboxService 
    {
        InboxMessageSearchService inboxMessageSearchService;

        public InboxServiceImpl()
        {
            inboxMessageSearchService = new InboxMessageSearchServiceImpl();
        }

        //TODO: Domain needs to be update for this method to work.
        public List<InboxDTO> getApplicantMessages(String username, String vacancyNumber)
        {
            return null;
        }

        public int getNumberOfInboxMessages(String username)
        {
            return inboxMessageSearchService.getInboxMessagesByUsername(username).Count;
        }

        public void setMessagesRead(String username, string vacancyNumber)
        {
            InboxDAO inboxDao = new InboxDAO();
            InboxDTO inboxDto = inboxDao.find(username, vacancyNumber);
            inboxDto.unread = "read";
            inboxDao.merge(inboxDto);
        }
        
        public bool hasUnreadMessage(String username)
        {
            return (inboxMessageSearchService.getUserUnreadInboxMessages(username).Count > 0);
        }

        public string getInboxMessage(string username, string vacancyNumber, string status)
        {
            InboxMessageSearchServiceImpl inboxService = new InboxMessageSearchServiceImpl();
            List<InboxDTO> inboxList = inboxService.getUserInboxMessagesByVacancy(username, vacancyNumber);

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.status.Equals(status))
                {
                    return inboxDto.message;
                }
            }
            return null;
        }


    }
}
