using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DomainService.DbContext;

namespace DomainService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IAuthService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        bool UserRegistration(store_users userObj);
        [OperationContract]
        bool UserAuth(store_users userObj);
    }
}
