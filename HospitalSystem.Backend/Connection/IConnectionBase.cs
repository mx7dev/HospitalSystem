using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HospitalSystem.Backend.Connection
{
    public interface IConnectionBase
    {
        DbParameterCollection ParamsCollectionResult { get; set; }
        DbConnection ConnectionGet(ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.OracleCanalP);
        DbDataReader ExecuteByStoredProcedure(string nameStore, IEnumerable<DbParameter> parameters = null,
            ConnectionBase.enuTypeDataBase typeDataBase = ConnectionBase.enuTypeDataBase.OracleCanalP,
            ConnectionBase.enuTypeExecute typeExecute = ConnectionBase.enuTypeExecute.ExecuteReader
            );
    }
}
