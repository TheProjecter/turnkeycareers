using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.BasicEdu
{
    public interface IBasicEduSubjectView
    {
        String getUsername();
        void setUsername(String username);
        String getSubjectName();
        void setSubjectName(String subjectName);
        String getSubjectDescription();
        void setSubjectDescription(String description);
        void showFeedback(String feedback);
        void hideFeedback();
    }
}
