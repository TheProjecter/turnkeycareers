using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;

namespace careers.PRESENTATION.Employment
{
    public class EmploymentPresenter : IEmploymentPresenter
    {
        IEmploymentView view;

        public EmploymentPresenter(IEmploymentView view)
        {
            this.view = view;
        }

        public void setEmploymentDto(EmploymentDTO employmentDto)
        {
            view.setTitle(employmentDto.title);
            view.setCompany(employmentDto.company);
            view.setIndustry(employmentDto.industry);
            view.setTown(employmentDto.town);
            view.setProvince(employmentDto.province);
            view.setCountry(employmentDto.country);
            view.setEducationType(employmentDto.empType);
            view.setCurrentEmployer(employmentDto.currentEmployer);
            view.setGross(employmentDto.gross.ToString());
            view.setStartDate(employmentDto.startDate.ToString());
            view.setEndDate(employmentDto.endDate.ToString());
            view.setResponsibilities(employmentDto.responsibilities);
            //view.setUsername(employmentInformationDto.userName);
        }

        public EmploymentDTO getEmploymentDto()
        {
            EmploymentDTO employmentDto = new EmploymentDTO();
            employmentDto.userName = view.getUsername();
            employmentDto.country = view.getCountry();
            employmentDto.company = view.getCompany();
            employmentDto.currentEmployer = view.getCurrentEmployer();
            employmentDto.empType = view.getEducationType();
            employmentDto.endDate = view.getEndDate();
            employmentDto.gross = view.getGross();
            employmentDto.industry = view.getIndustry();
            employmentDto.province = view.getProvince();
            employmentDto.responsibilities = view.getResponsibilities();
            employmentDto.startDate = view.getStartDate();
            employmentDto.title = view.getTitle();
            employmentDto.town = view.getTown();
            return employmentDto;
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
                if (accountService.isUniqueEmployment(view.getUsername(), view.getStartDate()))
                {
                    EmploymentDAO employmentDao = new EmploymentDAO();
                    employmentDao.presist(getEmploymentDto());
                    view.pageReload();
                }
                else
                {
                    view.setStartDateError("Error, this Date type is already used. Enter another value");
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
                EmploymentDAO employmentDao = new EmploymentDAO();
                employmentDao.removeByUserId(view.getUsername(), view.getStartDate());
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
                EmploymentDAO employmentDao = new EmploymentDAO();
                EmploymentDTO employmentInfoDto = employmentDao.find(view.getUsername(), view.getStartDate());
                setEmploymentDto(employmentInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setTitle("");
            view.setCompany("");
            view.setIndustry("");
            view.setTown("");
            view.setProvince("");
            view.setCountry("");
            view.setEducationType("");
            view.setCurrentEmployer("");
            view.setGross("");
            view.setStartDate("");
            view.setEndDate("");
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
                EmploymentDAO employmentInfoDao = new EmploymentDAO();
                employmentInfoDao.merge(getEmploymentDto());
                view.showFeedback("Successfully updated");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void loadPage(String username)
        {
            view.setUsername(username);
            AccountService accountService = new AccountServiceImpl();
            List<EmploymentDTO> employmentList = accountService.getUserEmployment(view.getUsername());

            view.setRepeater(employmentList);
            view.setNewView();
        }

        public void doErrorClear()
        {
            view.setTitleError("");
            view.setCompanyError("");
            view.setIndustryError("");
            view.setTownError("");
            view.setProvinceError("");
            view.setCountryError("");
            view.setEducationTypeError("");
            view.setCurrentEmployerError("");
            view.setGrossError("");
            view.setStartDateError("");
            view.setEndDateError("");
        }

    }
}
