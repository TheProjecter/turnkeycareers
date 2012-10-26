using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;
using careers.PRESENTATION.Disability;

namespace careers.PRESENTATION.Language
{
    public class LanguagePresenter: ILanguagePresenter
    {
        ILanguageView view;

        public LanguagePresenter(ILanguageView view)
        {
            this.view = view;
        }

        public void setLanguageDto(LanguageDTO languageDto)
        {
            view.setLanguage(languageDto.languageName);
            view.setRead(languageDto.reads);
            view.setWrite(languageDto.write);
            view.setSpeak(languageDto.speak);
            //view.setUsername(languageInformationDto.userName);
        }

        public LanguageDTO getLanguageDto()
        {
            LanguageDTO languageDto = new LanguageDTO();
            languageDto.userName = view.getUsername();
            languageDto.languageName = view.getLanguage();
            languageDto.reads = view.getRead();
            languageDto.write = view.getWrite();
            languageDto.speak = view.getSpeak();
            return languageDto;
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
                if (accountService.isUniqueLanguage(view.getUsername(), view.getLanguage()))
                {
                    LanguageDAO languageDao = new LanguageDAO();
                    languageDao.presist(getLanguageDto());
                    view.pageReload();
                }
                else
                {
                    view.setLanguageError("Error, this address type is already used. Enter another value");
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
                LanguageDAO languageDao = new LanguageDAO();
                languageDao.removeByUserId(view.getUsername(), view.getLanguage());
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
                LanguageDAO languageDao = new LanguageDAO();
                LanguageDTO languageInfoDto = languageDao.find(view.getUsername(), view.getLanguage());
                setLanguageDto(languageInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setLanguage("");
            view.setRead("");
            view.setWrite("");
            view.setSpeak("");
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
                LanguageDAO languageInfoDao = new LanguageDAO();
                languageInfoDao.merge(getLanguageDto());
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
            List<LanguageDTO> languageList = accountService.getUserLanguages(view.getUsername());

            view.setRepeater(languageList);
            view.setNewView();
        }

        public void doErrorClear()
        {
            view.setLanguageError("");
            view.setReadError("");
            view.setWriteError("");
            view.setSpeakError("");
        }

    }
}
