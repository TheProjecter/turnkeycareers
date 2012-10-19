using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.BasicEdu
{
    interface IBasicEduSubjectPresenter
    {
        void setBasicEduSubjectDto(BasicEduSubjectDTO addressDto);
        BasicEduSubjectDTO getDisabilityDto();
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
