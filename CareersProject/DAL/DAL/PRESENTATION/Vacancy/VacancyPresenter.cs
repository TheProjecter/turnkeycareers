using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;

namespace careers.PRESENTATION.Vacancy
{
    public class VacancyPresenter : IVacancyPresenter
    {
        IVacancyView view;

        public VacancyPresenter(IVacancyView view)
        {
            this.view = view;
        }

        public void setVacancyDto(VacancyDTO vacancyDto)
        {
            view.setVacancyNumber(vacancyDto.vacancyNumber);
            view.setViewStatus(vacancyDto.viewStatus);
            view.setTitle(vacancyDto.title);
            view.setDescription(vacancyDto.description);
            view.setDepartment(vacancyDto.department);
            view.setSite(vacancyDto.site);
            view.setStartDate(vacancyDto.startDate);
            view.setEndDate(vacancyDto.endDate);
            view.setViewCount(vacancyDto.viewCount);
            view.setStatus(vacancyDto.status);
            view.setManager(vacancyDto.manager);
            view.setRecruiter(vacancyDto.recruiter);
            //view.setCostToCompany(vacancyDto.costToCompany);
        }

        public VacancyDTO getVacancyDto()
        {
            VacancyDTO vacancyDto = new VacancyDTO();
            vacancyDto.vacancyNumber = view.getVacancyNumber();
            view.setViewStatus(vacancyDto.viewStatus);
            vacancyDto.title = view.getTitle();
            vacancyDto.description = view.getDescription();
            vacancyDto.department = view.getDepartment();
            vacancyDto.site = view.getSite();
            vacancyDto.startDate = view.getStartDate();
            vacancyDto.endDate = view.getEndDate();
            vacancyDto.viewCount = view.getViewCount();
            vacancyDto.status = view.getStatus();
            vacancyDto.manager = view.getManager();
            view.setRecruiter(vacancyDto.recruiter);
            return vacancyDto;
        }

        public bool isValid()//
        {
            return true;
        }

        public bool isMinimumValid()
        {
            return true;
        }

        public void doSave()
        {
            AccountService accountService = new AccountServiceImpl();
            if (isValid())
            {
                if (accountService.isUniqueVacancy(view.getVacancyNumber()))
                {
                    VacancyDAO vacancyDao = new VacancyDAO();
                    vacancyDao.presist(getVacancyDto());
                    view.pageReload();
                }
                else
                {
                    view.setVacancyNumber("Error, this Date type is already used. Enter another value");
                }
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doDelete()
        {
            if (isMinimumValid())
            {
                VacancyDAO vacancyDao = new VacancyDAO();
                vacancyDao.removeByUserId(view.getVacancyNumber());
                view.pageReload();
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }

        }

        public void doReset()
        {
            if (isMinimumValid())
            {
                VacancyDAO vacancyDao = new VacancyDAO();
                VacancyDTO vacancyInfoDto = vacancyDao.find(view.getVacancyNumber());
                setVacancyDto(vacancyInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setVacancyNumber("");
            view.setViewStatus("");
            view.setTitle("");
            view.setDescription("");
            view.setDepartment("");
            view.setSite("");
            view.setStartDate(Constants.Constants.DEFAULT_DATE_TIME);
            view.setEndDate(Constants.Constants.DEFAULT_DATE_TIME);
            view.setViewCount(Constants.Constants.DEFAULT_INT);
            view.setStatus("");
            view.setManager("");
            view.setRecruiter("");
            //view.setCostToCompany(vacancyDto.costToCompany);
        }

        public void newView()
        {
            view.setNewView();
        }

        public void updateView()
        {
            view.setUpdateView();
        }

        public void doUpdate()
        {
            if (isValid())
            {
                VacancyDAO vacancyInfoDao = new VacancyDAO();
                vacancyInfoDao.merge(getVacancyDto());
                view.showFeedback("Successfully updated");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void loadPage(String recruter)
        {
            String vacancyNumber = "1";

            view.setVacancyNumber(vacancyNumber);
            view.setRecruiter(recruter);
            AccountService accountService = new AccountServiceImpl();
            
            VacancyDAO vacancyDao = new VacancyDAO();
            VacancyDTO vacancyDto = vacancyDao.find(vacancyNumber);
            setVacancyDto(vacancyDto);

            List<VacancyKillerQuestionDTO> vacancyList = accountService.getUserQuestions(view.getVacancyNumber());
            List<KeyWordDTO> keyWordList = accountService.getUserKeyWords(view.getVacancyNumber());
            
            view.setQuestionRepeater(vacancyList);
            view.setKeyWordRepeater(keyWordList);
            view.setUpdateView();
        }

        public void doErrorClear()
        {
            view.setVacancyNumberError("");
            view.setViewStatusError("");
            view.setTitleError("");
            view.setDescriptionError("");
            view.setDepartmentError("");
            view.setSiteError("");
            view.setStartDateError("");
            view.setEndDateError("");
            view.setViewCountError("");
            view.setStatusError("");
            view.setManagerError("");
            view.setRecruiterError("");
        }


        public void doAddQuestion()
        {
            AccountService accountService = new AccountServiceImpl();
            if (isValid())
            {
                if (accountService.isUniqueVacancyKillerQuestion(view.getVacancyNumber(), view.getQuestion()))
                {
                    VacancyKillerQuestionDAO questionDao = new VacancyKillerQuestionDAO();
                    questionDao.presist(getKillerQuestionDto());
                    view.pageReload();
                }
                else
                {
                    view.setVacancyNumber("Error, this Date type is already used. Enter another value");
                }
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doRemoveQuestion()
        {
            if (isMinimumValid())
            {
                VacancyKillerQuestionDAO vacancyDao = new VacancyKillerQuestionDAO();
                vacancyDao.removeByUserId(view.getQuestion(), view.getVacancyNumber());
                view.pageReload();
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doResetQuestion()
        {
            if (isMinimumValid())
            {
                VacancyKillerQuestionDAO vacancyDao = new VacancyKillerQuestionDAO();
                VacancyKillerQuestionDTO vacancyInfoDto = vacancyDao.find(view.getQuestion(), view.getVacancyNumber());
                setKillerQuestionDto(vacancyInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClearQuestion()
        {
            view.setQuestion("");
            view.setAnswer("");
        }

        public void doAddKeyWord()
        {
            AccountService accountService = new AccountServiceImpl();
            if (isValid())
            {
                if (accountService.isUniqueKeyWord(view.getKeyWord(), view.getQuestion()))
                {
                    KeyWordDAO keyWordDao = new KeyWordDAO();
                    keyWordDao.presist(getKeyWordDto());
                    view.pageReload();
                }
                else
                {
                    view.setKeyWordError("Error, this Date type is already used. Enter another value");
                }
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doRemoveKeyWord()
        {
            if (isMinimumValid())
            {
                KeyWordDAO vacancyDao = new KeyWordDAO();
                vacancyDao.removeByUserId(view.getKeyWord(), view.getVacancyNumber());
                view.pageReload();
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doResetKeyWord()
        {
            if (isMinimumValid())
            {
                KeyWordDAO keyWordDao = new KeyWordDAO();
                KeyWordDTO keyWordDto = keyWordDao.find(view.getKeyWord(), view.getVacancyNumber());
                setKeyWordDto(keyWordDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClearKeyWord()
        {
            view.setKeyWord("");
        }


        public void setKillerQuestionDto(VacancyKillerQuestionDTO userDto)
        {
            view.setAnswer(userDto.answer);
            view.setQuestion(userDto.question);
        }

        public VacancyKillerQuestionDTO getKillerQuestionDto()
        {
            VacancyKillerQuestionDTO questionDto = new VacancyKillerQuestionDTO();
            questionDto.answer = view.getAnswer();
            questionDto.question = view.getQuestion();
            questionDto.vacancyNumber = view.getVacancyNumber();
            return questionDto;
        }

        public void setKeyWordDto(KeyWordDTO keyWordDto)
        {
            view.setKeyWord(keyWordDto.word);
        }

        public KeyWordDTO getKeyWordDto()
        {
            KeyWordDTO keyWordDto = new KeyWordDTO();
            keyWordDto.vacancyNumber = view.getVacancyNumber();
            keyWordDto.word = view.getKeyWord();
            return keyWordDto;
        }


        public bool isValidQuestion()
        {
            return true;
        }

        public bool isMinimumValidQuestion()
        {
            return true;
        }

        public bool isValidKeyWord()
        {
            return true;
        }

        public bool isMinimumValidKeyWord()
        {
            return true;
        }


        public void doUpdateQuestion()
        {
            if (isValid())
            {
                VacancyKillerQuestionDAO employmentInfoDao = new VacancyKillerQuestionDAO();
                employmentInfoDao.merge(getKillerQuestionDto());
                view.showFeedback("Successfully updated");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        //public void doUpdateKeyWord()
        //{
        //    if (isValid())
        //    {
        //        KeyWordDAO dao = new KeyWordDAO();
        //        dao.merge(getKeyWordDto());
        //        view.showFeedback("Successfully updated");
        //    }
        //    else
        //    {
        //        view.showFeedback("Error Field vlaues are not valid");
        //    }
        //}


        public void newQuestionView()
        {
            view.setNewQuestionView();
        }

        public void updateQuestionView()
        {
            view.setUpdateQuestionView();
        }

        public void newKeyWordView()
        {
            view.setNewKeyWordView();
        }

        public void updateKeyWordView()
        {
            view.setUpdateKeyWordView();
        }
    }
}
