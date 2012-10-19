using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Disability
{
    public interface IDisabilityView
    {
        void setRepeater(List<DisabilityDTO> addressList);
        String getUsername();
        void setUsername(String username);
        String getDisabilityType();
        void setDisabilityType(String disabilityType);
        String getDescription();
        void setDescription(String description);
        
        String getDisabilityTypeError();
        void setDisabilityTypeError(String disabilityType);
        String getDescriptionError();
        void setDescriptionError(String description);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }
}
