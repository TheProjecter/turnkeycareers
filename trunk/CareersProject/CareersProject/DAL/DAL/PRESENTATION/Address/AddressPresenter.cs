using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using careers.SERVICES;
using careers.Utilities;

namespace careers.PRESENTATION.Address
{
    public class AddressPresenter: IAddressPresenter
    {
        IAddressView view;

        public AddressPresenter(IAddressView view)
        {
            this.view = view;
        }
        
        public void setAddressDto(AddressDTO addressDto)
        {
            view.setAddressType(addressDto.addressType);
            view.setCountry(addressDto.country);
            view.setProvince(addressDto.province);
            view.setStreet(addressDto.street);
            view.setSuburb(addressDto.suburb);
            view.setTown(addressDto.town);
            view.setUnitNumber(addressDto.unitNumber);
            view.setUsername(addressDto.userName);
        }

        public AddressDTO getAddressDto()
        {
            AddressDTO addressDto = new AddressDTO();
            addressDto.addressType = view.getAddressType();
            addressDto.country = view.getCountry();
            addressDto.province = view.getProvince();
            addressDto.street = view.getStreet();
            addressDto.suburb = view.getSuburb();
            addressDto.town = view.getTown();
            addressDto.unitNumber = view.getUnitNumber();
            addressDto.userName = view.getUsername();

            return addressDto;
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
                if(accountService.isUniqueAddress(view.getUsername(), view.getAddressType()))
                {
                    AddressDAO addressDao = new AddressDAO();
                    addressDao.presist(getAddressDto());
                    ApplicationControler appControler = new ApplicationControler();
                    view.pageReload();
                    view.showFeedback("Successfully added Address");
                }
                else
                {
                    view.setAddressTypeError("Error, this address type is already used. Enter another value");
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
                AddressDAO addressDao = new AddressDAO();
                addressDao.removeByUserId(view.getUsername(), view.getAddressType());
                view.pageReload();
                view.showFeedback("Successfully deleted");
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
                AddressDAO addressDao = new AddressDAO();
                AddressDTO addressDto = addressDao.find(view.getUsername(), view.getAddressType());
                setAddressDto(addressDto);
                view.showFeedback("Fields are reset.");
            }
            else
            {
                view.showFeedback("Error Field vlaues are not valid");
            }
        }

        public void doClear()
        {
            view.setAddressType("");
            view.setCountry("");
            view.setProvince("");
            view.setStreet("");
            view.setSuburb("");
            view.setTown("");
            view.setUnitNumber(-1);
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
                AddressDAO addressDao = new AddressDAO();
                addressDao.merge(getAddressDto());
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
            List<AddressDTO> addressList = accountService.getUserAddresses(view.getUsername());

            view.setRepeater(addressList);
            view.setNewView();
        }

        public void doErrorClear()
        {
            view.setAddressTypeError("");
            view.setCountryError("");
            view.setProvinceError("");
            view.setStreetError("");
            view.setSuburbError("");
            view.setTownError("");
            view.setUnitNumberError("");
        }


    }
}
