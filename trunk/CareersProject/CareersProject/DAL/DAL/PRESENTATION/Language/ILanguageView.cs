using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.PRESENTATION.Language
{
    public interface ILanguageView
    {
        void setRepeater(List<LanguageDTO> addressList);
        String getUsername();
        String getLanguage();
        String getRead();
        String getWrite();
        String getSpeak();
        void setUsername(String username);
        void setLanguage(String language);
        void setRead(String read);
        void setWrite(String write);
        void setSpeak(String speak);

        String getLanguageError();
        String getReadError();
        String getWriteError();
        String getSpeakError();
        void setLanguageError(String language);
        void setReadError(String read);
        void setWriteError(String write);
        void setSpeakError(String speak);

        void setUpdateView();
        void setNewView();
        void showFeedback(String feedback);
        void hideFeedback();
        void pageReload();
    }
}
