using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.User
{
    interface IUserPresenter
    {
        void setLanguageDto(UserDTO userDto);
        UserDTO getUserDto();
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
