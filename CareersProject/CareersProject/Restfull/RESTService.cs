using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.Configuration;

namespace Restfull
{
    [AspNetCompatibilityRequirements
    (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RESTService : IRESTService
    {
        List<Person> persons = new List<Person>();
        DAO_Account_Interface account_ctx = new AccountDAO();

        public Person CreatePerson(Person createPerson)
        {
            persons.Add(createPerson);
            return createPerson;
        }

        public List<Person> GetAllPerson()
        {
            return persons.ToList();
        }

        public Person GetAPerson(string id)
        {
            return persons.FirstOrDefault(e => e.ID.Equals(id));
        }

        //------------------------------------------------------
        //Account

        public string CreateAccount(RestAccount CreateAccount)
        {
            string secretString = ConfigurationManager.AppSettings["secretString"];
            CreateAccount.restUser = AESencryption.DecryptStringAES(CreateAccount.restUser, secretString);
            CreateAccount.restPassword = AESencryption.DecryptStringAES(CreateAccount.restPassword, secretString);
            if(Membership.ValidateUser(CreateAccount.restUser,CreateAccount.restPassword) )
            {
                AccountDTO newObj = (AccountDTO)CreateAccount;
                newObj.userName = AESencryption.DecryptStringAES(newObj.userName, secretString);
                newObj.password = AESencryption.DecryptStringAES(newObj.password, secretString);
                newObj.status = AESencryption.DecryptStringAES(newObj.status, secretString);
                newObj.accountType = AESencryption.DecryptStringAES(newObj.accountType, secretString);
 
                account_ctx.presist(newObj);
                return "OK";
            }
            else
                return "Authentication Failed";
               
            
        }

        public List<AccountDTO> GetAllAccounts(RestAccount getAccount)
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            string secretString = ConfigurationManager.AppSettings["secretString"];
            getAccount.restUser = AESencryption.DecryptStringAES(getAccount.restUser, secretString);
            getAccount.restPassword = AESencryption.DecryptStringAES(getAccount.restPassword, secretString);
            if (Membership.ValidateUser(getAccount.restUser, getAccount.restPassword))
            {
                accounts =  account_ctx.findAll();
                return accounts.ToList();
            }
            else
                return accounts.ToList();
        }

        public AccountDTO GetAccount(RestAccount getAccount)
        {
            string secretString = ConfigurationManager.AppSettings["secretString"];
            getAccount.restUser = AESencryption.DecryptStringAES(getAccount.restUser, secretString);
            getAccount.restPassword = AESencryption.DecryptStringAES(getAccount.restPassword, secretString);
            if (Membership.ValidateUser(getAccount.restUser, getAccount.restPassword))
            {
                AccountDTO newObj = (AccountDTO)getAccount;
                newObj.userName = AESencryption.DecryptStringAES(newObj.userName, secretString);

                return account_ctx.find(newObj.userName);
            }
            else
                return null;
        }

        public string UpdateAccount(RestAccount updateAccount)
        {
            string secretString = ConfigurationManager.AppSettings["secretString"];
            updateAccount.restUser = AESencryption.DecryptStringAES(updateAccount.restUser, secretString);
            updateAccount.restPassword = AESencryption.DecryptStringAES(updateAccount.restPassword, secretString);
            if (Membership.ValidateUser(updateAccount.restUser, updateAccount.restPassword))
            {
                AccountDTO newObj = (AccountDTO)updateAccount;
                newObj.userName = AESencryption.DecryptStringAES(newObj.userName, secretString);
                newObj.password = AESencryption.DecryptStringAES(newObj.password, secretString);
                newObj.status = AESencryption.DecryptStringAES(newObj.status, secretString);
                newObj.accountType = AESencryption.DecryptStringAES(newObj.accountType, secretString);

                account_ctx.merge(newObj);
                return "OK";
            }
            else
                return "Authentication Failed";
        }



        public string DeleteAccount(RestAccount deleteAccount)
        {
            string secretString = ConfigurationManager.AppSettings["secretString"];
            deleteAccount.restUser = AESencryption.DecryptStringAES(deleteAccount.restUser, secretString);
            deleteAccount.restPassword = AESencryption.DecryptStringAES(deleteAccount.restPassword, secretString);
            if (Membership.ValidateUser(deleteAccount.restUser, deleteAccount.restPassword))
            {
                AccountDTO newObj = (AccountDTO)deleteAccount;
                newObj.userName = AESencryption.DecryptStringAES(newObj.userName, secretString);
                newObj.password = AESencryption.DecryptStringAES(newObj.password, secretString);
                newObj.status = AESencryption.DecryptStringAES(newObj.status, secretString);
                newObj.accountType = AESencryption.DecryptStringAES(newObj.accountType, secretString);

                account_ctx.remove(newObj);
                return "OK";
            }
            else
                return "Authentication Failed";
        }
    }
}