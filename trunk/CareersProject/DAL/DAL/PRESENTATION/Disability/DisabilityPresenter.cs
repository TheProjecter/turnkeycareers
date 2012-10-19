using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;

namespace careers.PRESENTATION.Disability
{
    public class DisabilityPresenter : IDisabilityPresenter
    {
        IDisabilityView view;

        public DisabilityPresenter(IDisabilityView view)
        {
            this.view = view;
        }

        public void setDisabilityDto(DisabilityDTO disabilityDto)
        {
            view.setDescription(disabilityDto.description);
            view.setDisabilityType(disabilityDto.disabilityType);
            //view.setUsername(disabilityInformationDto.userName);
        }

        public DisabilityDTO getDisabilityDto()
        {
            DisabilityDTO disabilityDto = new DisabilityDTO();
            disabilityDto.userName = view.getUsername();
            disabilityDto.description = view.getDescription();
            disabilityDto.disabilityType = view.getDisabilityType();
            return disabilityDto;
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
                if (accountService.isUniqueDisability(view.getUsername(), view.getDisabilityType()))
                {
                    DisabilityDAO disabilityDao = new DisabilityDAO();
                    disabilityDao.presist(getDisabilityDto());
                    view.pageReload();
                }
                else
                {
                    view.setDisabilityTypeError("Error, this address type is already used. Enter another value");
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
                DisabilityDAO disabilityDao = new DisabilityDAO();
                disabilityDao.removeByUserId(view.getUsername(), view.getDisabilityType());
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
                DisabilityDAO disabilityDao = new DisabilityDAO();
                DisabilityDTO disabilityInfoDto = disabilityDao.find(view.getUsername(), view.getDisabilityType());
                setDisabilityDto(disabilityInfoDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setDisabilityType("");
            view.setDescription("");
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
                DisabilityDAO disabilityInfoDao = new DisabilityDAO();
                disabilityInfoDao.merge(getDisabilityDto());
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
            List<DisabilityDTO> disabilityList = accountService.getUserDisabilities(view.getUsername());

            view.setRepeater(disabilityList);
            view.setNewView();
        }

        public void doErrorClear()
        {
            view.setDisabilityTypeError("");
            view.setDescriptionError("");
        }

    }
}
