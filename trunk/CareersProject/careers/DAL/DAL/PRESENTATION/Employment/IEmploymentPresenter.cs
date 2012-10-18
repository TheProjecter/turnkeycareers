using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Employment
{
    interface IEmploymentPresenter
    {
        void setEmploymentDto(EmploymentDTO employmentDto);
        EmploymentDTO getEmploymentDto();
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
