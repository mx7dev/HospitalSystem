using HospitalSystem.Backend.Connection;
using HospitalSystem.Backend.Entity;
using HospitalSystem.Backend.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Data.Interfaces
{
    public class DataUser : IUser
    {
        private readonly AppSettings _appSettings;
        private readonly IConnectionBase _connectionBase;

        public DataUser(IOptions<AppSettings> appSettings,
                                IConnectionBase ConnectionBase)
        {
            _appSettings = appSettings.Value;
            _connectionBase = ConnectionBase;
        }

        public async Task<ResultEntity> Authenticate(string susername, string spassword)
        {
            ResultEntity entity = null;
            spassword = Cryptography.GetMd5Hash(spassword);
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@susername", susername),
                    new SqlParameter("@spassword", spassword)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sp_authenticate", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    while (dr.Read())
                    {
                        entity = dr.ReadFields<ResultEntity>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<ResultEntity>(entity);
        }

        public async Task<UserInfo> GetUserInfo(string username)
        {
            UserInfo entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@susername", username)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sps_get_userinfo", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    while (dr.Read())
                    {
                        entity = dr.ReadFields<UserInfo>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<UserInfo>(entity);
        }
    }
}
