using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Vacancy
{
    public interface IVacancyView
    {
          string getVacancyNumber();
          string getViewStatus();
          string getTitle();
          string getDescription();
          string getDepartment();
          string getSite();
          DateTime getStartDate();
          DateTime getEndDate();
          int getViewCount();
          string getStatus();
          string getManager();
          string getRecruiter();
          string getCostToCompany();
        
          void setVacancyNumber(string vacancyNumber);
          void setViewStatus(string viewStatus);
          void setTitle(string title);
          void setDescription(string description);
          void setDepartment(string department);
          void setSite(string site);
          void setStartDate(DateTime startDate);
          void setEndDate(DateTime endDate);
          void setViewCount(int viewCount);
          void setStatus(string status);
          void setManager(string manager);
          void setRecruiter(string recruiter);
          void setCostToCompany(double cost);

          string getVacancyNumberError();
          string getViewStatusError();
          string getTitleError();
          string getDescriptionError();
          string getDepartmentError();
          string getSiteError();
          DateTime getStartDateError();
          DateTime getEndDateError();
          int getViewCountError();
          string getStatusError();
          string getManagerError();
          string getRecruiterError();
          string getCostToCompanyError();

          void setVacancyNumberError(string vacancyNumber);
          void setViewStatusError(string viewStatusError);
          void setTitleError(string title);
          void setDescriptionError(string description);
          void setDepartmentError(string department);
          void setSiteError(string site);
          void setStartDateError(string startDate);
          void setEndDateError(string endDate);
          void setViewCountError(string viewCounter);
          void setStatusError(string status);
          void setManagerError(string manager);
          void setRecruiterError(string recruiter);
          void getCostToCompanyError(string cost);

          string getQuestion();
          string getAnswer();
          void setQuestion(string question);
          void setAnswer(string answer);
          string getQuestionError();
          string getAnswerError();
          void setQuestionError(string question);
          void setAnswerError(string answer);

          string getKeyWord();
          void setKeyWord(string keyword);
          string getKeyWordError();
          void setKeyWordError(string keywordError);

        void setUpdateView();
        void setNewView();
        void setUpdateKeyWordView();
        void setNewKeyWordView();
        void setUpdateQuestionView();
        void setNewQuestionView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
        void setQuestionRepeater(List<VacancyKillerQuestionDTO> list);
        void setKeyWordRepeater(List<KeyWordDTO> list);

        void setQuestionPanel(bool isVisable);
        void setKeyWordPanel(bool isVisable);


    }
}
