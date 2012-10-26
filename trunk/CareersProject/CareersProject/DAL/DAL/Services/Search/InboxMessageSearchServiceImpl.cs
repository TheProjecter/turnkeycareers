
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
    public class InboxMessageSearchServiceImpl : InboxMessageSearchService
    {
        public List<InboxDTO> getInboxMessagesByUsername(String username)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = inboxDao.findAll();

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.userName.Equals(username))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }

        public List<InboxDTO> getInboxMessagesByDate(DateTime date)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = inboxDao.findAll();

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.date.Equals(date))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }

        public List<InboxDTO> getReadInboxMessages()
        {
            //TODO 
            return null;
        }

        public List<InboxDTO> getUnreadInboxMessages()
        {
            //TODO 
            return null;
        }

        public List<InboxDTO> getInboxMessagesByMessage(String message)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = inboxDao.findAll();

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.message.Equals(message))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }

        public List<InboxDTO> getUserInboxMessagesByDate(String username, DateTime date)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = getInboxMessagesByUsername(username);

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.date.Equals(date))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }
        
        public List<InboxDTO> getUserReadInboxMessages(String username)
        {
            //TODO 
            return null;
        }

        public List<InboxDTO> getUserUnreadInboxMessages(String username)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = inboxDao.findAll();

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.unread.Equals("unread"))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }

        public List<InboxDTO> getUserInboxMessagesByMessage(String username, String message)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = getInboxMessagesByUsername(username);

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.message.Equals(message))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }

        public List<InboxDTO> getUserInboxMessagesByVacancy(string username, string vacancyNumber)
        {
            List<InboxDTO> inboxDtoList = new List<InboxDTO>();
            InboxDAO inboxDao = new InboxDAO();
            List<InboxDTO> inboxList = getInboxMessagesByUsername(username);

            foreach (InboxDTO inboxDto in inboxList)
            {
                if (inboxDto.vacancyNumber.Equals(vacancyNumber))
                {
                    inboxDtoList.Add(inboxDto);
                }
            }
            return inboxDtoList;
        }

    }
}

