using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Inbox
{
    interface IUserPresenter
    {
        void setDisabilityDto(DisabilityDTO addressDto);
        DisabilityDTO getDisabilityDto();
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
