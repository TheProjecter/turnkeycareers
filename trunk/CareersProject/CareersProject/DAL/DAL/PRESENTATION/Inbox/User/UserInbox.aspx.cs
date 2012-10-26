using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace careers.PRESENTATION.Inbox.User
{
    public partial class UserInbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<VacancyDTO> vacancyList = new List<VacancyDTO>();
            VacancyDTO vacancy1 = new VacancyDTO();
            vacancy1.department = "IT";
            vacancy1.title = "Developer needed";
            vacancy1.endDate = DateTime.Parse("06/06/2013");
            vacancy1.startDate = DateTime.Parse("05/05/2013");
            vacancy1.status = "CLOSED";

            VacancyDTO vacancy2 = new VacancyDTO();
            vacancy2.department = "IT2";
            vacancy2.title = "Developer needed2";
            vacancy2.endDate = DateTime.Parse("06/06/2013");
            vacancy2.startDate = DateTime.Parse("05/05/2013");
            vacancy1.status = "OPEN";


            vacancyList.Add(vacancy1);
            vacancyList.Add(vacancy2);


            rptUserInbox.DataSource = vacancyList;
            rptUserInbox.DataBind();





        }
    }
}