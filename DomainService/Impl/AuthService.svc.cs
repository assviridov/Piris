using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DomainService.DbContext;

namespace DomainService
{
    //11 ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "AuthService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы AuthService.svc или AuthService.svc.cs в обозревателе решений и начните отладку.
    public class AuthService : IAuthService
    {
        private static DatabaseService _databaseService = new DatabaseService();
        public bool UserAuth(store_users userObj)
        {
            var res = _databaseService.GetUserByUserName(userObj.userName);
            if (res == null)
            {
                return false;
            }
            if (userObj.userPassword == res.userPassword)
            {
                return true;
            }
            return true;
        }
        public bool UserRegistration(store_users userObj)
        {
            store_users dbUser = new store_users();
            dbUser.userName = userObj.userName;
            dbUser.userPassword = userObj.userPassword;
            var res = _databaseService.CreateUser(dbUser);
            return res;
        }
    }
}
