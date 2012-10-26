using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Language
{
    interface ILanguagePresenter
    {
        void setLanguageDto(LanguageDTO addressDto);
        LanguageDTO getLanguageDto();
        bool isValid();
        bool isMinimumValid();
        void doSave();
        void doUpdate();
        void doDelete();
        void doReset();
        void doClear();
        void doErrorClear();
        void newView();
        void updateView();
        void loadPage(String username);
    }
}
