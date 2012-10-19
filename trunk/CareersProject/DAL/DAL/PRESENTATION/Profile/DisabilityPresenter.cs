using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using careers.PRESENTATION.ContactInformation;
namespace careers.PRESENTATION.Profile
{
    public class DisabilityPresenter : IDisabilityPresenter
    {
        private IDisabilityView view;

        public DisabilityPresenter(IDisabilityView view)
        {
            this.view = view;
            view.setUsername("hughank@gmail.com");
        }
        
        public void setDisabilityDto(DisabilityDTO disabilityDto)
        {
            view.setDescription(disabilityDto.description);
            view.setDisabilityType(disabilityDto.disabilityType);
            view.setUsername(disabilityDto.userName);
        }

        public DisabilityDTO getDisabilityDto()
        {
            DisabilityDTO disabilityDto = new DisabilityDTO();
            disabilityDto.description = view.getDescription();
            disabilityDto.disabilityType = view.getDisabilityType();
            disabilityDto.userName = view.getUsername();
            return disabilityDto;
        }

        public bool isValid()
        {
            return true;
        }
        
        public void doSave()
        {
            if (isValid())
            {
                DisabilityDTO disabilityDto = getDisabilityDto();
                DisabilityDAO disabilityDao = new DisabilityDAO();
                disabilityDao.presist(disabilityDto);
            }
            else
            {

            }
        }

        public void doCancle()
        {
            doClear();
        }

        public void doClear()
        {
            view.setDescription("");
            view.setDisabilityType("");
            //view.setUsername("");
        }
    }
}