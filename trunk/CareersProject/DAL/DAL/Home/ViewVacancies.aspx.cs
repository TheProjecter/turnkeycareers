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