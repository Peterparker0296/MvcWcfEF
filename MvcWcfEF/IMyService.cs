using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MvcWcfEF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService 
    {
        [OperationContract]
        List<UserDetail> GetAllUser();
 //-------------------------------------------------------------------------------------------
        [OperationContract]
        int AddUser(string Name, string Email);

 //-------------------------------------------------------------------------------------------
        [OperationContract]
        UserDetail GetAllUserById(int id);
 //-------------------------------------------------------------------------------------------
        [OperationContract]
        int UpdateUser(int Id, string Name, string Email);
 //-------------------------------------------------------------------------------------------
        [OperationContract]
        int DeleteUserById(int Id);




    }

//-------------------------------------------------------------------------------------------
    [DataContract]
    public class UserDetails
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }


    }


}
