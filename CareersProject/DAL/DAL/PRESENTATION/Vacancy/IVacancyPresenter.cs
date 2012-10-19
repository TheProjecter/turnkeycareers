using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Vacancy
{
    interface IVacancyPresenter
    {
        void setVacancyDto(VacancyDTO userDto);
        VacancyDTO getVacancyDto();
        void setKillerQuestionDto(VacancyKillerQuestionDTO userDto);
        VacancyKillerQuestionDTO getKillerQuestionDto();
        void setKeyWordDto(KeyWordDTO keyWordDto);
        KeyWordDTO getKeyWordDto();
        bool isValid();
        bool isMinimumValid();
        bool isValidQuestion();
        bool isMinimumValidQuestion();
        bool isValidKeyWord();
        bool isMinimumValidKeyWord();
        void doSave();
        void doDelete();
        void doUpdate();
        void doReset();
        void doClear();
        void loadPage(String recruter);
        void doErrorClear();

        void doAddQuestion();
        void doUpdateQuestion();
        void doRemoveQuestion();
        void doResetQuestion();
        void doClearQuestion();
        void newQuestionView();
        void updateQuestionView();

        void doAddKeyWord();
        //void doUpdateKeyWord();
        void doRemoveKeyWord();
        void doResetKeyWord();
        void doClearKeyWord();
        void newKeyWordView();
        void updateKeyWordView();

        void newView();
        void updateView();
    }
}
