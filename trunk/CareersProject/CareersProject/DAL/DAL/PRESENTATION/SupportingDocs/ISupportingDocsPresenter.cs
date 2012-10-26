using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.SupportingDocs
{
    interface ISupportingDocsPresenter
    {
        void setSupportDocDTODto(SupportDocDTO addressDto);
        SupportDocDTO getSupportDocDTODto();
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
