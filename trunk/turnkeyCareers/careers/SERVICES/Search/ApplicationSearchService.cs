
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES.Search
{
    public interface ApplicationSearchService
    {
        List<ApplicationDTO> getApplicationByUsername(String username);
        List<ApplicationDTO> getApplicationByVacancyNumber(String vacancyNumber);
        List<ApplicationDTO> getApplicationByStatus(String status);
        List<ApplicationDTO> getApplicationByStatus(String vacancyNumber, String status);

    }
}
