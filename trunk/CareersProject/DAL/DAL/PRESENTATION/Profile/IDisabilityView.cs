using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.ContactInformation
{
    public interface IDisabilityView
    {
        String getUsername();
        void setUsername(String username);
        String getDisabilityType();
        void setDisabilityType(String disabilityType);
        String getDescription();
        void setDescription(String description);
    }

}
