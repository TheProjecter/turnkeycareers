using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES
{
    public interface ContactService
    {
        List<ContactInfoDTO> getContactList(String username);


    }
}
