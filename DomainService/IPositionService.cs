using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace DomainService
{
    [ServiceContract]
    public interface IPositionService
    {
        [OperationContract]
        bool AddPosition(PositionObject position);
        [OperationContract]
        bool DeletePosition(int id);
        [OperationContract]
        PositionObject GetPositionById(int id);
        [OperationContract]
        List<PositionObject> GetPositions();

        [OperationContract]
        bool UpdatePosition(PositionObject position);
    }
}
