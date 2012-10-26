using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.PRESENTATION.BasicEdu;
using careers.SERVICES;

namespace careers.PRESENTATION.BasicEdu
{
    public class BasicEduPresenter : IBasicEduPresenter
    {
        IBasicEduView view;

        public BasicEduPresenter(IBasicEduView view)
        {
            this.view = view;
        }

        public void setBasicEduDto(BasicEduDTO basicEduDto)
        {
            view.setSchool(basicEduDto.school);
            view.setTown(basicEduDto.town);
            view.setProvince(basicEduDto.province);
            view.setCountry(basicEduDto.country);
            view.setLevelCompleted(basicEduDto.levelCompleted);
            //view.setUsername(basicEduInformationDto.userName);
        }

        public BasicEduDTO getBasicEduDto()
        {
            BasicEduDTO basicEduDto = new BasicEduDTO();
            basicEduDto.userName = view.getUsername();
            basicEduDto.school = view.getSchool();
            basicEduDto.town = view.getTown();
            basicEduDto.province = view.getProvince();
            basicEduDto.country = view.getCountry();
            basicEduDto.levelCompleted = view.getLevelCompleted();
            return basicEduDto;
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
                BasicEduDAO basicEduDao = new BasicEduDAO();
                basicEduDao.presist(getBasicEduDto());
                view.pageReload();
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
                BasicEduDAO basicEduDao = new BasicEduDAO();
                basicEduDao.removeByUserId(view.getUsername());
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
                BasicEduDAO basicEduDao = new BasicEduDAO();
                BasicEduDTO basicEduInfoDto = basicEduDao.find(view.getUsername());
                setBasicEduDto(basicEduInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setSchool("");
            view.setTown("");
            view.setProvince("");
            view.setCountry("");
            view.setLevelCompleted(Constants.Constants.DEFAULT_INT);
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
                BasicEduDAO basicEduInfoDao = new BasicEduDAO();
                basicEduInfoDao.merge(getBasicEduDto());
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
            List<BasicEduDTO> basicEduList = accountService.getUserBasicEdu(view.getUsername());

            if (basicEduList.Count == 1)
            {
                setBasicEduDto(basicEduList[0]);
                view.setUpdateView();
                view.setNewLinkVisable(false);
            }
            else
            {
                view.setNewView();
                view.setNewLinkVisable(true);
            }

            view.setRepeater(basicEduList);
        }

        public void doErrorClear()
        {
            view.setSchoolError("");
            view.setTownError("");
            view.setProvinceError("");
            view.setCountryError("");
            view.setLevelCompletedError("");
        }

    }

}