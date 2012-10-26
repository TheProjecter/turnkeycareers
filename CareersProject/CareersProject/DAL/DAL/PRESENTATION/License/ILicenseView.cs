using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.User
{
    public interface ILicenseView
    {
        String getUsername();
        void setUsername(String username);
        String getType();
        void setType(String type);
    }
}
