using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.User
{
    interface ILicensePresenter
    {
        void setLanguageDto(LanguageDTO addressDto);
        LanguageDTO getLanguageDto();
        bool isValid();
        bool isMinimumValid();
        void doSave();
        void doDelete();
        void doReset();
        void doClear();
        void newView();
        void updateView();
    }
}
