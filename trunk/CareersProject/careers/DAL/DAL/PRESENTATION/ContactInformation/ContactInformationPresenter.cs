using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;

namespace careers.PRESENTATION.ContactInformation
{
    public class ContactInformationPresenter: IContactInformationPresenter
    {
        IContactInformationView view;

        public ContactInformationPresenter(IContactInformationView view)
        {
            this.view = view;
        }

        public void setContactDto(ContactInfoDTO contactInformationDto)
        {
            view.setContactType(contactInformationDto.contactType);
            view.setData(contactInformationDto.data);
            //view.setUsername(contactInformationDto.userName);
        }

        public ContactInfoDTO getContactInformationDto()
        {
            ContactInfoDTO contactInfoDto = new ContactInfoDTO();
            contactInfoDto.userName = view.getUsername();
            contactInfoDto.contactType = view.getContactType();
            contactInfoDto.data = view.getData();
            return contactInfoDto;
        }

        public bool isValid()//
        {
            return true;
        }

        public bool isMinimumValid()
        {
            return true;
        }

        public void doSave()
        {
            AccountService accountService = new AccountServiceImpl();
            if (isValid())
            {
                if (accountService.isUniqueContact(view.getUsername(), view.getContactType()))
                {
                    ContactInfoDAO contactDao = new ContactInfoDAO();
                    contactDao.presist(getContactInformationDto());
                    view.pageReload();
                }
                else
                {
                    view.setContactTypeError("Error, this address type is already used. Enter another value");
                }
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doDelete()
        {
            if (isMinimumValid())
            {
                ContactInfoDAO contactDao = new ContactInfoDAO();
                contactDao.removeByUserId(view.getUsername(), view.getContactType());
                view.pageReload();
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }

        }

        public void doReset()
        {
            if (isMinimumValid())
            {
                ContactInfoDAO contactDao = new ContactInfoDAO();
                ContactInfoDTO contactInfoDto = contactDao.find(view.getUsername(), view.getContactType());
                setContactDto(contactInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setContactType("");
            view.setData("");
        }

        public void newView()
        {
            view.setNewView();
        }

        public void updateView()
        {
            view.setUpdateView();
        }

        public void doUpdate()
        {
            if (isValid())
            {
                ContactInfoDAO contactInfoDao = new ContactInfoDAO();
                contactInfoDao.merge(getContactInformationDto());
                view.showFeedback("Successfully updated");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void loadPage(String username)
        {
            view.setUsername(username);
            AccountService accountService = new AccountServiceImpl();
            List<ContactInfoDTO> contactList = accountService.getUserContacts(view.getUsername());

            view.setRepeater(contactList);
            view.setNewView();
        }

        public void doErrorClear()
        {
            view.setContactTypeError("");
            view.setDataError("");
        }

    }
}
