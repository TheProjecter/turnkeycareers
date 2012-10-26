using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using careers.PRESENTATION.Vacancy;
using careers.Constants;
using DAL.Services.VacancyServices;

namespace DAL.Account.Recruter
{
    public partial class AddVacancy : System.Web.UI.Page, IVacancyView
    {
        IVacancyPresenter presenter;
        IGenerateVacancyNumber newVacancyNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            newVacancyNumber = new GenerateVacancyNumber();
            presenter = new VacancyPresenter(this);
            String recruter = (String)Session["username"];
            String vacancyNumber = (String)Session["vacancyNumber"];



            if (!IsPostBack)
            {
            VacancyDAO dao = new VacancyDAO();
            List<VacancyDTO> vacancyList = dao.findAll();
            List<String> vacancyStringList = new List<string>();

            foreach (VacancyDTO vacancy in vacancyList)
            {
                vacancyStringList.Add(vacancy.vacancyNumber);
            }
            ddlVacancies.DataSource = vacancyStringList;
            ddlVacancies.DataBind();
            }
        }

        public void setRepeater(List<VacancyKillerQuestionDTO> list)
        {
            rptQuestion.DataSource = list;
            rptQuestion.DataBind();
        }

        public void showFeedback(string feedback)
        {
            lbFeedback.Text = feedback;
            lbFeedback.Visible = true;
        }

        public void hideFeedback()
        {
            lbFeedback.Text = "";
            lbFeedback.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            presenter.doSave();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            presenter.doUpdate();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            presenter.doReset();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            presenter.doDelete();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            presenter.newView();
        }

        protected void rptQuestion_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            VacancyKillerQuestionDTO dto;
            VacancyKillerQuestionDAO dao = new VacancyKillerQuestionDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("question"))
            {
                dto = dao.find(getVacancyNumber(), e.CommandArgument.ToString());
                presenter.setKillerQuestionDto(dto);
                presenter.updateQuestionView();
            }
        }

        protected void rptKeyWord_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            KeyWordDTO dto;
            KeyWordDAO dao = new KeyWordDAO();
            String element = e.CommandName.ToString();

            if (element.Equals("word"))
            {
                dto = dao.find(getVacancyNumber(), e.CommandArgument.ToString());
                presenter.setKeyWordDto(dto);
                presenter.updateKeyWordView();
            }

        }


        public string getVacancyNumber()
        {
            return txtVacancyNumber.Text;
        }

        public string getViewStatus()
        {
            return txtViewStatus.Text;
        }

        public string getTitle()
        {
            return txtTitle.Text;
        }

        public string getDescription()
        {
            return txtDescription.Text;
        }

        public string getDepartment()
        {
            return txtDepartment.Text;
        }

        public string getSite()
        {
            return txtSite.Text;
        }

        public DateTime getStartDate()
        {
            DateTime date = DateTime.Parse(txtStartDate.Text);
            return date;
        }

        public DateTime getEndDate()
        {
            return DateTime.Parse(txtEndDate.Text);
        }

        public int getViewCount()
        {
            return Int32.Parse(txtViewCount.Text);
        }

        public string getStatus()
        {
            return txtStatus.Text;
        }

        public string getManager()
        {
            return txtManager.Text;
        }

        public string getRecruiter()
        {
            return txtRecruiter.Text;
        }

        public string getCostToCompany()
        {
            return txtCostToCompany.Text;
        }

        public void setVacancyNumber(string vacancyNumber)
        {
            txtVacancyNumber.Text = vacancyNumber;
        }

        public void setViewStatus(string viewStatus)
        {
            txtViewStatus.Text = viewStatus;
        }

        public void setTitle(string title)
        {
            txtTitle.Text = title;
        }

        public void setDescription(string description)
        {
            txtDescription.Text = description;
        }

        public void setDepartment(string department)
        {
            txtDepartment.Text = department;
        }

        public void setSite(string site)
        {
            txtSite.Text = site;
        }

        public void setStartDate(DateTime startDate)
        {
            if (startDate == Constants.DEFAULT_DATE_TIME)
            {
                txtStartDate.Text = "";
            }
            else
            {
                txtStartDate.Text = startDate.ToString();
            }
        }

        public void setEndDate(DateTime endDate)
        {
            if (endDate == Constants.DEFAULT_DATE_TIME)
            {
                txtEndDate.Text = "";
            }
            else
            {
                txtEndDate.Text = endDate.ToString();
            }
        }

        public void setViewCount(int viewCount)
        {
            if (viewCount == Constants.DEFAULT_INT)
            {
                txtViewCount.Text = "";
            }
            else
            {
                txtViewCount.Text = viewCount.ToString();
            }
        }

        public void setStatus(string status)
        {
            txtStatus.Text = status;
        }

        public void setManager(string manager)
        {
            txtManager.Text = manager;
        }

        public void setRecruiter(string recruiter)
        {
            txtRecruiter.Text = recruiter;
        }

        public void setCostToCompany(double cost)
        {
            if (cost == Constants.DEFAULT_DOUBLE)
            {
                txtCostToCompany.Text = "";
            }
            else
            {
                txtCostToCompany.Text = cost.ToString();
            }
        }

        public string getVacancyNumberError()
        {
            return lbVacancyNumberError.Text;
        }

        public string getViewStatusError()
        {
            return lbViewStatusError.Text;
        }

        public string getTitleError()
        {
            return lbTitleError.Text;
        }

        public string getDescriptionError()
        {
            return lbDescriptionError.Text;
        }

        public string getDepartmentError()
        {
            return lbDepartmentError.Text;
        }

        public string getSiteError()
        {
            return lbSiteError.Text;
        }

        public DateTime getStartDateError()
        {
            return DateTime.Parse(lbStartDateError.Text);
        }

        public DateTime getEndDateError()
        {
            return DateTime.Parse(lbEndDateError.Text);
        }

        public int getViewCountError()
        {
            return Int32.Parse(lbViewCountError.Text);
        }

        public string getStatusError()
        {
            return lbStatusError.Text;
        }

        public string getManagerError()
        {
            return lbManagerError.Text;
        }

        public string getRecruiterError()
        {
            return lbRecruiterError.Text;
        }

        public string getCostToCompanyError()
        {
            return lbCostToCompanyError.Text;
        }

        public void setVacancyNumberError(string vacancyNumber)
        {
            lbVacancyNumberError.Text = vacancyNumber;
        }

        public void setViewStatusError(string viewStatusError)
        {
            lbViewStatusError.Text = viewStatusError;
        }

        public void setTitleError(string title)
        {
            lbTitleError.Text = title;
        }

        public void setDescriptionError(string description)
        {
            lbDescriptionError.Text = description;
        }

        public void setDepartmentError(string department)
        {
            lbDepartmentError.Text = department;
        }

        public void setSiteError(string site)
        {
            lbSiteError.Text = site;
        }

        public void setStartDateError(string startDate)
        {
            lbStartDateError.Text = startDate;
        }

        public void setEndDateError(string endDate)
        {
            lbEndDateError.Text = endDate;
        }

        public void setViewCountError(string viewCounter)
        {
            lbViewCountError.Text = viewCounter;
        }

        public void setStatusError(string status)
        {
            lbStartDateError.Text = status;
        }

        public void setManagerError(string manager)
        {
            lbManagerError.Text = manager;
        }

        public void setRecruiterError(string recruiter)
        {
            lbRecruiterError.Text = recruiter;
        }

        public void getCostToCompanyError(string cost)
        {
            lbCostToCompanyError.Text = cost.ToString();
        }

        public string getQuestion()
        {
            return txtQuestion.Text;
        }

        public string getAnswer()
        {
            return txtAnswer.Text;
        }

        public void setQuestion(string question)
        {
            txtQuestion.Text = question;
        }

        public void setAnswer(string answer)
        {
            txtAnswer.Text = answer;
        }

        public string getQuestionError()
        {
            return lbQuestionError.Text;
        }

        public string getAnswerError()
        {
            return lbAnswerError.Text;
        }

        public void setQuestionError(string question)
        {
            lbQuestionError.Text = question;
        }

        public void setAnswerError(string answer)
        {
            lbAnswerError.Text = answer;
        }

        public string getKeyWord()
        {
            return txtKeyWord.Text;
        }

        public void setKeyWord(string keyword)
        {
            txtKeyWord.Text = keyword;
        }

        public string getKeyWordError()
        {
            return lbKeyWordError.Text;
        }

        public void setKeyWordError(string keywordError)
        {
            lbKeyWordError.Text = keywordError;
        }

        public void setUpdateView()
        {
            //txtVacancyNumber.ReadOnly = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lbFeedback.Text = "";
        }

        public void setNewView()
        {
            presenter.doClear();
            presenter.doErrorClear();
            //txtVacancyNumber.ReadOnly = true;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lbFeedback.Text = "";
        }

        public void setUpdateKeyWordView()
        {
            //txtVacancyNumber.ReadOnly = true;
            btnSaveQuestion.Visible = false;
            btnUpdateQuestion.Visible = false;
            btnResetQuestion.Visible = false;
            btnDeleteQuestion.Visible = true;
            lbFeedback.Text = "";
            keyWordPanel.Visible = true;
        }

        public void setNewKeyWordView()
        {
            presenter.doClearKeyWord();
            presenter.doErrorClear();
            btnSaveKeyWord.Visible = true;
            btnUpdateKeyWord.Visible = false;
            btnResetKeyWord.Visible = false;
            btnDeleteQuestion.Visible = false;
            lbFeedback.Text = "";
            keyWordPanel.Visible = true;
        }

        public void setUpdateQuestionView()
        {
            //txtVacancyNumber.ReadOnly = true;
            btnSaveQuestion.Visible = false;
            btnUpdateQuestion.Visible = false;
            btnResetQuestion.Visible = false;
            btnDeleteQuestion.Visible = true;
            lbFeedback.Text = "";
            questionPanel.Visible = true;
        }

        public void setNewQuestionView()
        {
            presenter.doClearQuestion();
            presenter.doErrorClear();
            btnSaveQuestion.Visible = true;
            btnUpdateQuestion.Visible = false;
            btnResetQuestion.Visible = false;
            btnDeleteQuestion.Visible = false;
            lbFeedback.Text = "";
            questionPanel.Visible = true;
        }

        public void pageReload()
        {
            Response.Redirect("~/Account/Recruter/AddVacancy.aspx");
        }

        public void setQuestionRepeater(List<VacancyKillerQuestionDTO> list)
        {
            rptQuestion.DataSource = list;
            rptQuestion.DataBind();
        }

        public void setKeyWordRepeater(List<KeyWordDTO> list)
        {
            rptKeyWord.DataSource = list;
            rptKeyWord.DataBind();
        }

        protected void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            presenter.doUpdateQuestion();
        }

        protected void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            presenter.doAddQuestion();
        }

        protected void btnResetQuestion_Click(object sender, EventArgs e)
        {
            presenter.doResetQuestion();
        }

        protected void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            presenter.doRemoveQuestion();
        }

        protected void btnUpdateKeyWord_Click(object sender, EventArgs e)
        {
            //presenter.doUpdateKeyWord();
        }

        protected void btnSaveKeyWord_Click(object sender, EventArgs e)
        {
            presenter.doAddKeyWord();
        }

        protected void btnResetKeyWord_Click(object sender, EventArgs e)
        {
            presenter.doResetKeyWord();
        }

        protected void btnDeleteKeyWord_Click(object sender, EventArgs e)
        {
            presenter.doRemoveKeyWord();
        }

        protected void lbtnNewQuestion_Click(object sender, EventArgs e)
        {
            presenter.newQuestionView();
        }

        protected void lbtnNewKeyWord_Click(object sender, EventArgs e)
        {
            presenter.newKeyWordView();
        }

        public void setQuestionPanel(bool isVisable)
        {
            questionPanel.Visible = isVisable;
        }

        public void setKeyWordPanel(bool isVisable)
        {
            keyWordPanel.Visible = isVisable;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            presenter.loadPage("new");
        }

        protected void ddlVacancies_SelectedIndexChanged(object sender, EventArgs e)
        {
            setVacancyNumber(ddlVacancies.SelectedValue);
            setRecruiter(getRecruiter());
            presenter.loadPage("update");
            //setVacancyNumber(vacancyNumber);
            presenter.doErrorClear();

        }
    }
}