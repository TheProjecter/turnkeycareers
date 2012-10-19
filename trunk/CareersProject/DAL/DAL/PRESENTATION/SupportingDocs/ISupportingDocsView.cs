using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.SupportingDocs
{
    public interface ISupportingDocsView
    {
        String getTitle();
        String getUsername();
        String getDescription();
        String getContent();
        void setTitle(String title);
        void setUsername(String username);
        void setDescription(String description);
        void setContent(String content);
        void showFeedback(String feedback);
        void hideFeedback();
    }
}
