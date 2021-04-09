using HospitalSystem.Backend.Connection;
using HospitalSystem.Backend.Data.Interfaces;
using HospitalSystem.Backend.Entity;
using HospitalSystem.Backend.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Data
{
    public class DataPatient : IPatient
    {
        private readonly AppSettings _appSettings;
        private readonly IConnectionBase _connectionBase;

        public DataPatient(IOptions<AppSettings> appSettings,
                                IConnectionBase ConnectionBase)
        {
            _appSettings = appSettings.Value;
            _connectionBase = ConnectionBase;

        }

        public async Task<ResultEntity> Delete(int idPatient)
        {
            ResultEntity entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidpatient", idPatient)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sp_delete_patient", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
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

        public async Task<IEnumerable<Patient>> FindAllPatients()
        {
            IEnumerable<Patient> entity = null;
            try
            {
                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.sps_list_patient", null, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    if (dr.HasRows)
                        entity = dr.ReadRows<Patient>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<IEnumerable<Patient>>(entity);
        }

        public async Task<Patient> FindPatientById(int idPatient)
        {
            Patient entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidpatient", idPatient)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sps_get_patient", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    while (dr.Read())
                    {
                        entity = dr.ReadFields<Patient>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<Patient>(entity);
        }

        public async Task<ResultEntity> SavePatient(Patient request)
        {
            ResultEntity entity = null;
            try
            {
                request.SSECONDNAME = request.SSECONDNAME == null ? string.Empty : request.SSECONDNAME;
                request.NPHONE = request.NPHONE == null ? string.Empty : request.NPHONE;
                request.SDESCRIPTION = request.SDESCRIPTION == null ? string.Empty : request.SDESCRIPTION;
                request.DBIRTHDATE = Convert.ToDateTime(request.SBIRTHDATE);

                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidpatient", request.NIDPATIENT),
                    new SqlParameter("@sfirstname", request.SFIRSTNAME),
                    new SqlParameter("@ssecondname", request.SSECONDNAME),
                    new SqlParameter("@slastname", request.SLASTNAME),
                    new SqlParameter("@slastname1", request.SLASTNAME1),
                    new SqlParameter("@dbirthdate", request.DBIRTHDATE),
                    new SqlParameter("@sgender", request.SGENDER),
                    new SqlParameter("@nphone", request.NPHONE),
                    new SqlParameter("@semail", request.SEMAIL),
                    new SqlParameter("@sdescription", request.SDESCRIPTION),
                    new SqlParameter("@spathimage", request.SPATHIMAGE)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spi_save_patient", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
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

        public Task<ResultEntity> UpdatePatient(Patient request)
        {
            throw new NotImplementedException();
        }
    }
}
