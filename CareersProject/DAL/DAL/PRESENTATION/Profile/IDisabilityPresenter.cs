using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Profile
{
    public interface IDisabilityPresenter
    {
        void setDisabilityDto(DisabilityDTO disabilityDto);
        DisabilityDTO getDisabilityDto();
        bool isValid();
        void doSave();
        void doCancle();
        void doClear();
    }
}
