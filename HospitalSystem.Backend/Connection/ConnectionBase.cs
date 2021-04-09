using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using HospitalSystem.Backend.Utilities;
using Microsoft.Extensions.Options;

namespace HospitalSystem.Backend.Connection
{
    public class ConnectionBase : IConnectionBase
    {
        private string strConexionOracle = null;
        private string strConexionOracleVTime = null;
        private string strConexionSqlServer = null;

        //OracleConnection DataConnectionOracle = new OracleConnection();
        //OracleConnection DataConnectionOracleTIME = new OracleConnection();
        SqlConnection DataConnectionSQLServer = new SqlConnection();


        private readonly AppSettings _appSettings;

        public enum enuTypeDataBase
        {
            OracleCanalP,
            OracleVTime,
            SqlServer
        }

        public enum enuTypeExecute
        {
            ExecuteNonQuery,
            ExecuteReader
        }

        //public DbParameterCollection ParamsCollectionResult;

        public DbParameterCollection ParamsCollectionResult { get; set; }


        //Constructor de la clase 
        public ConnectionBase(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            //this.strConexionOracle = _appSettings.ConnectionStringPrtCanal;
            //DataConnectionOracle.ConnectionString = this.strConexionOracle;

            //this.strConexionOracleVTime = _appSettings.ConnectionStringTimeP;
            //DataConnectionOracleTIME.ConnectionString = this.strConexionOracleVTime;

            this.strConexionSqlServer = _appSettings.ConnectionStringSqlServer;
            DataConnectionSQLServer.ConnectionString = this.strConexionSqlServer;

        }


        public DbConnection ConnectionGet(enuTypeDataBase typeDataBase = enuTypeDataBase.SqlServer)
        {
            DbConnection DataConnection = null;
            switch (typeDataBase)
            {
                //case enuTypeDataBase.OracleCanalP:
                //    DataConnection = DataConnectionOracle;
                //    break;
                //case enuTypeDataBase.OracleVTime:
                //    DataConnection = DataConnectionOracleTIME;
                //    break;
                case enuTypeDataBase.SqlServer:
                    DataConnection = DataConnectionSQLServer;
                    break;
                default:
                    break;
            }
            return DataConnection;
        }

        public DbDataReader ExecuteByStoredProcedure(string nameStore,
                IEnumerable<DbParameter> parameters = null,
                enuTypeDataBase typeDataBase = enuTypeDataBase.OracleCanalP,
                enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader
                )
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = nameStore;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeDataBase == enuTypeDataBase.SqlServer && typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                cmdCommand.Connection.Close();
                myReader = null;
            }

            return myReader;
        }

        /// <summary>
        /// </summary>
        /// <param name="cmdCommand"></param>
        /// <returns></returns>
        //private bool IsOracleReader(DbCommand cmdCommand)
        //{
        //    bool isOracleReader = false;
        //    foreach (DbParameter item in cmdCommand.Parameters)
        //    {
        //        if (item is OracleParameter)
        //        {
        //            if ((item as OracleParameter).OracleDbType == OracleDbType.RefCursor)
        //            {
        //                isOracleReader = true;
        //                break;
        //            }
        //        }
        //    }
        //    return isOracleReader;
        //}
    }
}
