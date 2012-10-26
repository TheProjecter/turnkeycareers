using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restfull
{
    public class RestAccount:AccountDTO
    {
        public string restUser { set; get; }
        public string restPassword { set; get; }    
    }
}