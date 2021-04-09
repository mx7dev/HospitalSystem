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
    public class DataDoctor : IDoctor
    {
        private readonly AppSettings _appSettings;
        private readonly IConnectionBase _connectionBase;

        public DataDoctor(IOptions<AppSettings> appSettings,
                                IConnectionBase ConnectionBase) {
            _appSettings = appSettings.Value;
            _connectionBase = ConnectionBase;
        }

        public async Task<ResultEntity> Delete(int idDoctor)
        {
            ResultEntity entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@niddoctor", idDoctor)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sp_delete_doctor", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
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

        public async Task<IEnumerable<Doctor>> FindAllDoctors()
        {
            IEnumerable<Doctor> entity = null;
            try
            {
                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.sps_list_doctor", null, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    if (dr.HasRows)
                        entity = dr.ReadRows<Doctor>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<IEnumerable<Doctor>>(entity);
        }

        public async Task<Doctor> FinDoctorById(int idDoctor)
        {
            Doctor entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@niddoctor", idDoctor)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sps_get_doctor", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    while (dr.Read())
                    {
                        entity = dr.ReadFields<Doctor>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<Doctor>(entity);
        }

        public async Task<ResultEntity> SaveDoctor(Doctor request)
        {
            ResultEntity entity = null;
            try
            {
                request.SPASSWORD = Cryptography.GetMd5Hash(request.SPASSWORD);
                request.SSECONDNAME = request.SSECONDNAME == null ? string.Empty : request.SSECONDNAME;
                request.SWEBSITE = request.SWEBSITE == null ? string.Empty : request.SWEBSITE;
                request.NPHONE = request.NPHONE == null ? string.Empty : request.NPHONE;
                request.SABOUT = request.SABOUT == null ? string.Empty : request.SABOUT;
                request.DBIRTHDATE = Convert.ToDateTime(request.SBIRTHDATE);

                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@niddoctor", request.NIDDOCTOR),
                    new SqlParameter("@sfirstname", request.SFIRSTNAME),
                    new SqlParameter("@ssecondname", request.SSECONDNAME),
                    new SqlParameter("@slastname", request.SLASTNAME),
                    new SqlParameter("@slastname1", request.SLASTNAME1),
                    new SqlParameter("@dbirthdate", request.DBIRTHDATE),
                    new SqlParameter("@sgender", request.SGENDER),
                    new SqlParameter("@sspeciality", request.SSPECIALITY),
                    new SqlParameter("@nphone", request.NPHONE),
                    new SqlParameter("@semail", request.SEMAIL),
                    new SqlParameter("@sabout", request.SABOUT),
                    new SqlParameter("@spathimage", request.SPATHIMAGE),
                    new SqlParameter("@swebsite", request.SWEBSITE),
                    new SqlParameter("@suser", request.SUSER),
                    new SqlParameter("@spassword", request.SPASSWORD)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spi_save_doctor", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
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

        public Task<ResultEntity> UpdateDoctor(Doctor request)
        {
            throw new NotImplementedException();
        }
    }
}
