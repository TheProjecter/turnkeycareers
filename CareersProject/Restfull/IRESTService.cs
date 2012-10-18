using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

    [ServiceContract]
    public interface IRESTService
    {
        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "/add/user/", Method = "POST")]
        Person CreatePerson(Person createPerson);

        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "/get/all/")]
        List<Person> GetAllPerson();

        [OperationContract]
        [WebGet(UriTemplate = "/get/user/{id}")]
        Person GetAPerson(string id);

        //------------------------------------------------------
        //Account
        //POST operation
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/add/account/", Method = "POST")]
        AccountDTO CreateAccount(AccountDTO CreateAccount);

        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "/getall/accounts/")]
        List<AccountDTO> GetAllAccounts();

        [OperationContract]
        [WebGet(UriTemplate = "/get/account/{userName}")]
        AccountDTO GetAccount(string userName);

        //POST operation
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/update/account/", Method = "POST")]
        AccountDTO UpdateAccount(AccountDTO updateAccount);

        //Get operation
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/delete/account/", Method = "POST")]
        AccountDTO DeleteAccount(AccountDTO deleteAccount);

    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string ID;
        [DataMember]
        public string Name;
        [DataMember]
        public string Age;
        

    } 
