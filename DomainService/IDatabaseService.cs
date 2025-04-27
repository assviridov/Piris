using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainService.DbContext;

namespace DomainService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDatabaseService
    {

        [OperationContract]
        List<store_positions> GetPositions();
        [OperationContract]
        bool AddPosition(store_positions position);
        [OperationContract]
        store_positions GetPositionById(int id);
        [OperationContract]
        store_users GetUserByUserName(string userName);
        [OperationContract]
        store_positions UpdatePosition(store_positions position);
        [OperationContract]
        bool DeletePosition(int id);
        [OperationContract]
        bool CreateUser(store_users user);
    }
}
