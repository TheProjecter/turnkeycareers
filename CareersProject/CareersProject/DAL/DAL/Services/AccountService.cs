using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES
{
    public interface AccountService
    {
        List<AddressDTO> getUserAddresses(String username);
        bool isUniqueAddress(String username, String addressType);
        List<ContactInfoDTO> getUserContacts(String username);
        bool isUniqueContact(String username, String contactType);
        List<LanguageDTO> getUserLanguages(String username);
        bool isUniqueLanguage(String username, String language);
        List<DisabilityDTO> getUserDisabilities(String username);
        bool isUniqueDisability(String username, String language);
        List<HigherEducationDTO> getUserHigherEducations(String username);
        bool isUniqueHigherEducation(String username, String major);
        List<EmploymentDTO> getUserEmployment(String username);
        bool isUniqueEmployment(String username, DateTime startDate);
        List<BasicEduDTO> getUserBasicEdu(String username);
        bool isUniqueVacancy(string vacancyNumber);
        bool isUniqueKeyWord(string vacancyNumber, string keyWord);
        List<KeyWordDTO> getUserKeyWords(string vacancyNumber);
        bool isUniqueVacancyKillerQuestion(string p, string p_2);
        List<VacancyKillerQuestionDTO> getUserQuestions(string p);
    }
}
