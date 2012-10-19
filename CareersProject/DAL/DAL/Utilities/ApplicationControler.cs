using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.Utilities
{
    public class ApplicationControler : System.Web.UI.Page
    {
        public ApplicationControler()
        {
        }

        public void reloadPage(String pagePath)
        {
            Response.Redirect(pagePath);
        }





    }
}