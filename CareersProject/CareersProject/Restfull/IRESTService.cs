using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Restfull;

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
        string CreateAccount(RestAccount CreateAccount);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/getall/accounts/", Method = "POST")]
        List<AccountDTO> GetAllAccounts(RestAccount getAccount);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/get/account/", Method = "POST")]
        AccountDTO GetAccount(RestAccount getAccount);

        //POST operation
        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/update/account/", Method = "POST")]
        string UpdateAccount(RestAccount updateAccount);

        [OperationContract, XmlSerializerFormat]
        [WebInvoke(UriTemplate = "/delete/account/", Method = "POST")]
        string DeleteAccount(RestAccount deleteAccount);

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
