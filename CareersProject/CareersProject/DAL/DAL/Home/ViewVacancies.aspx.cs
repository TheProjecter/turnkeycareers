using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.SERVICES.VacancyServices;
//using model;
namespace careers
{
    public partial class ViewVacancies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiveVacancies get = new LiveVacancies();

            List<VacancyDTO> listVacs = get.getAllLiveVancancies();
            vacRepeater.DataSource = listVacs;
            vacRepeater.DataBind();


        }

        protected void vacRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
             String element = e.CommandName.ToString();
             string userName = (string)Session["username"];

             ApplicationDAO app_ctx = new ApplicationDAO();
             ApplicationDTO obj = new ApplicationDTO();

             if(!app_ctx.isFound(userName,element) )
             {
                 obj.userName = userName;
                 obj.vacancyNumber = element;
                 obj.status = ApplicationStatus.APPLIED.ToString();
                 obj.appDate = DateTime.Now;
                 app_ctx.presist(obj);

                 InboxDTO inbox = new InboxDTO();
                 inbox.date = DateTime.Now;
                 inbox.message = "You have successfully applied for vacancy " + element;
                 inbox.status = ApplicationStatus.APPLIED.ToString();
                 inbox.unread = "unread";
                 inbox.userName = userName;
                 inbox.vacancyNumber = element;

                 InboxDAO dao = new InboxDAO();
                 dao.presist(inbox);

                 Response.Redirect("~/Inbox/InboxMessage.aspx");
             }

             

        }

        protected void Display(object sender, EventArgs e)
        {
            VacancyByDepartment dept = new VacancyByDepartment();
            
            if (dropDownList.SelectedIndex == 1)
            {              
                List<VacancyDTO> listVacs = dept.getVacanciesByDept(deparments.SelectedValue);
                vacRepeater.DataSource = null;
                vacRepeater.DataSource = listVacs;
                vacRepeater.DataBind();
            }
        }

        protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dropDownList.SelectedIndex == 1)
            {
                deparments.Visible = true;
            }
            else
            {
                deparments.Visible = false;
            }
            

        }
    
    }
}