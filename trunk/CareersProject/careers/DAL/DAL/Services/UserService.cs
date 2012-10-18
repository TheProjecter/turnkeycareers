
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES
{
    public interface UserService
    {
        List<ApplicationDTO> getShortListedCandidates(String vacancyNumber);
        void changeUserApplicationStatus(String username, String vacancyNumber, ApplicationStatus appStatus);
    }
}
