
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES.Search
{
    public interface InboxMessageSearchService
    {
        List<InboxDTO> getInboxMessagesByUsername(String username);

        List<InboxDTO> getInboxMessagesByDate(DateTime date);

        List<InboxDTO> getReadInboxMessages();

        List<InboxDTO> getUnreadInboxMessages();

        List<InboxDTO> getInboxMessagesByMessage(String message);

        List<InboxDTO> getUserInboxMessagesByDate(String username, DateTime date);

        List<InboxDTO> getUserReadInboxMessages(String username);

        List<InboxDTO> getUserUnreadInboxMessages(String username);

        List<InboxDTO> getUserInboxMessagesByMessage(String username, String message);
    }
}
