using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.ServiceModel.Activation;
using System.ServiceModel;

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
            //createPerson.ID = (++personCount).ToString();
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

        public AccountDTO CreateAccount(AccountDTO CreateAccount)
        {
           
                account_ctx.presist(CreateAccount);
                return CreateAccount;
               
            
        }

        public List<AccountDTO> GetAllAccounts()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            accounts = account_ctx.findAll();
            return accounts.ToList();
        }

        public AccountDTO GetAccount(string userName)
        {
            return account_ctx.find(userName);
        }

        public AccountDTO UpdateAccount(AccountDTO updateAccount)
        {
            account_ctx.merge(updateAccount);
            return updateAccount;
        }



        public AccountDTO DeleteAccount(AccountDTO deleteAccount)
        {
            account_ctx.remove(deleteAccount);
            return deleteAccount;
        }
    }
}