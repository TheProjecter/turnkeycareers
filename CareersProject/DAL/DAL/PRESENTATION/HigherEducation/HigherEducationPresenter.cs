using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;
using careers.PRESENTATION.Disability;

namespace careers.PRESENTATION.HigherEducation
{
    public class HigherEducationPresenter : IHigherEducationPresenter
    {
        IHigherEducationView view;

        public HigherEducationPresenter(IHigherEducationView view)
        {
            this.view = view;
        }

        public void setHigherEducationDto(HigherEducationDTO higherEducationDto)
        {
            view.setCountry(higherEducationDto.country);
            view.setEducationType(higherEducationDto.educationType);
            view.setIndustry(higherEducationDto.industry);
            view.setInstitution(higherEducationDto.institution);
            view.setLength(higherEducationDto.length);
            view.setMajor(higherEducationDto.major);
            view.setNqf(higherEducationDto.nqf);
            view.setProvince(higherEducationDto.province);
            view.setTown(higherEducationDto.town);
            //view.setUsername(higherEducationInformationDto.userName);
        }

        public HigherEducationDTO getHigherEducationDto()
        {
            HigherEducationDTO higherEducationDto = new HigherEducationDTO();
            higherEducationDto.userName = view.getUsername();
            higherEducationDto.country = view.getCountry();
            higherEducationDto.educationType = view.getEducationType();
            higherEducationDto.industry = view.getIndustry();
            higherEducationDto.institution = view.getInstitution();
            higherEducationDto.length = view.getLength();
            higherEducationDto.major = view.getMajor();
            higherEducationDto.nqf = view.getNqf();
            higherEducationDto.province = view.getProvince();
            higherEducationDto.town = view.getTown();
            return higherEducationDto;
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
                if (accountService.isUniqueHigherEducation(view.getUsername(), view.getMajor()))
                {
                    HigherEducationDAO higherEducationDao = new HigherEducationDAO();
                    higherEducationDao.presist(getHigherEducationDto());
                    view.pageReload();
                }
                else
                {
                    view.setMajorError("Error, this address type is already used. Enter another value");
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
                HigherEducationDAO higherEducationDao = new HigherEducationDAO();
                higherEducationDao.removeByUserId(view.getUsername(), view.getMajor());
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
                HigherEducationDAO higherEducationDao = new HigherEducationDAO();
                HigherEducationDTO higherEducationInfoDto = higherEducationDao.find(view.getUsername(), view.getMajor());
                setHigherEducationDto(higherEducationInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setCountry("");
            view.setEducationType("");
            view.setIndustry("");
            view.setInstitution("");
            view.setLength("");
            view.setMajor("");
            view.setNqf("");
            view.setProvince("");
            view.setTown("");
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
                HigherEducationDAO higherEducationInfoDao = new HigherEducationDAO();
                higherEducationInfoDao.merge(getHigherEducationDto());
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
            List<HigherEducationDTO> higherEducationList = accountService.getUserHigherEducations(view.getUsername());

            view.setRepeater(higherEducationList);
            view.setNewView();
        }

        public void doErrorClear()
        {
            view.setCountryError("");
            view.setEducationTypeError("");
            view.setIndustryError("");
            view.setInstitutionError("");
            view.setLengthError("");
            view.setMajorError("");
            view.setNqfError("");
            view.setProvinceError("");
            view.setTownError("");
        }

    }
}
