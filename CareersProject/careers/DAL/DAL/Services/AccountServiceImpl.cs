using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace careers.SERVICES
{
    public class AccountServiceImpl : AccountService
    {
        public List<AddressDTO> getUserAddresses(string username)
        {
            List<AddressDTO> addressDtoList = new List<AddressDTO>();
            AddressDAO addressDao = new AddressDAO();
            List<AddressDTO> addressList = addressDao.findAll();

            foreach (AddressDTO address in addressList)
            {
                if (address.userName.Equals(username))
                {
                    addressDtoList.Add(address);
                }
            }
            return addressDtoList;
        }

        public bool isUniqueAddress(String username, String addressType)
        {
            bool isUnique = false;
            AddressDAO addressDao = new AddressDAO();
            AddressDTO addressDto = null;

            try
            {
                addressDto = addressDao.find(username, addressType);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }

            if (addressDto == null)
            {
                isUnique = true;
            }
            return isUnique;

        }

        public List<ContactInfoDTO> getUserContacts(string username)
        {
            List<ContactInfoDTO> contactDtoList = new List<ContactInfoDTO>();
            ContactInfoDAO contactDao = new ContactInfoDAO();
            List<ContactInfoDTO> contactList = contactDao.findAll();

            foreach (ContactInfoDTO contact in contactList)
            {
                if (contact.userName.Equals(username))
                {
                    contactDtoList.Add(contact);
                }
            }
            return contactDtoList;
        }

        public bool isUniqueContact(String username, String contactType)
        {
            bool isUnique = false;
            ContactInfoDAO contactDao = new ContactInfoDAO();
            ContactInfoDTO contactDto = null;

            try
            {
                return (!contactDao.isFound(username, contactType));
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }

            if (contactDto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }

        public List<LanguageDTO> getUserLanguages(String username)
        {
            List<LanguageDTO> dtoList = new List<LanguageDTO>();
            LanguageDAO dao = new LanguageDAO();
            List<LanguageDTO> list = dao.findAll();

            foreach (LanguageDTO address in list)
            {
                if (address.userName.Equals(username))
                {
                    dtoList.Add(address);
                }
            }
            return dtoList;
        }

        public bool isUniqueLanguage(String username, String language)
        {
            bool isUnique = false;
            LanguageDAO dao = new LanguageDAO();
            LanguageDTO dto = null;

            try
            {
                dto = dao.find(username, language);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;

        }

        public List<DisabilityDTO> getUserDisabilities(String username)
        {
            List<DisabilityDTO> dtoList = new List<DisabilityDTO>();
            DisabilityDAO dao = new DisabilityDAO();
            List<DisabilityDTO> list = dao.findAll();

            foreach (DisabilityDTO disability in list)
            {
                if (disability.userName.Equals(username))
                {
                    dtoList.Add(disability);
                }
            }
            return dtoList;
        }

        public bool isUniqueDisability(String username, String language)
        {
            bool isUnique = false;
            DisabilityDAO dao = new DisabilityDAO();
            DisabilityDTO dto = null;

            try
            {
                dto = dao.find(username, language);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }

        public List<HigherEducationDTO> getUserHigherEducations(String username)
        {
            List<HigherEducationDTO> dtoList = new List<HigherEducationDTO>();
            HigherEducationDAO dao = new HigherEducationDAO();
            List<HigherEducationDTO> list = dao.findAll();

            foreach (HigherEducationDTO disability in list)
            {
                if (disability.userName.Equals(username))
                {
                    dtoList.Add(disability);
                }
            }
            return dtoList;
        }

        public bool isUniqueHigherEducation(String username, String major)
        {
            bool isUnique = false;
            HigherEducationDAO dao = new HigherEducationDAO();
            HigherEducationDTO dto = null;

            try
            {
                dto = dao.find(username, major);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }

        public List<EmploymentDTO> getUserEmployment(String username)
        {
            List<EmploymentDTO> dtoList = new List<EmploymentDTO>();
            EmploymentDAO dao = new EmploymentDAO();
            List<EmploymentDTO> list = dao.findAll();

            foreach (EmploymentDTO emp in list)
            {
                if (emp.userName.Equals(username))
                {
                    dtoList.Add(emp);
                }
            }
            return dtoList;
        }

        public bool isUniqueEmployment(String username, DateTime startdate)
        {
            bool isUnique = false;
            EmploymentDAO dao = new EmploymentDAO();
            EmploymentDTO dto = null;

            try
            {
                dto = dao.find(username, startdate);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }

        public List<BasicEduDTO> getUserBasicEdu(String username)
        {
            List<BasicEduDTO> dtoList = new List<BasicEduDTO>();
            BasicEduDAO dao = new BasicEduDAO();
            List<BasicEduDTO> list = dao.findAll();

            foreach (BasicEduDTO emp in list)
            {
                if (emp.userName.Equals(username))
                {
                    dtoList.Add(emp);
                }
            }
            return dtoList;

        }

        public bool isUniqueVacancy(string vacancyNumber)
        {
            bool isUnique = false;
            VacancyDAO dao = new VacancyDAO();
            VacancyDTO dto = null;

            try
            {
                dto = dao.find(vacancyNumber);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }

        public bool isUniqueKeyWord(string vacancyNumber, string keyWord)
        {
            bool isUnique = false;
            KeyWordDAO dao = new KeyWordDAO();
            KeyWordDTO dto = null;

            try
            {
                dto = dao.find(keyWord, vacancyNumber);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }

        public List<KeyWordDTO> getUserKeyWords(string vacancyNumber)
        {
            List<KeyWordDTO> dtoList = new List<KeyWordDTO>();
            KeyWordDAO dao = new KeyWordDAO();
            List<KeyWordDTO> list = dao.findAll();

            foreach (KeyWordDTO emp in list)
            {
                if (emp.vacancyNumber.Equals(vacancyNumber))
                {
                    dtoList.Add(emp);
                }
            }
            return dtoList;

        }

        public bool isUniqueVacancyKillerQuestion(string keyWord, string vacancyNumber)
        {
            bool isUnique = false;
            KeyWordDAO dao = new KeyWordDAO();
            KeyWordDTO dto = null;

            try
            {
                dto = dao.find(keyWord, vacancyNumber);
            }
            catch (InvalidOperationException ioe)
            {
                isUnique = true;
            }


            if (dto == null)
            {
                isUnique = true;
            }
            return isUnique;
        }
        
        public List<VacancyKillerQuestionDTO> getUserQuestions(string vacancyNumber)
        {
            List<VacancyKillerQuestionDTO> dtoList = new List<VacancyKillerQuestionDTO>();
            VacancyKillerQuestionDAO dao = new VacancyKillerQuestionDAO();
            List<VacancyKillerQuestionDTO> list = dao.findAll();

            foreach (VacancyKillerQuestionDTO emp in list)
            {
                if (emp.vacancyNumber.Equals(vacancyNumber))
                {
                    dtoList.Add(emp);
                }
            }
            return dtoList;
        }


    }
}
