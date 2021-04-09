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
    public class DataAppointment : IAppointment
    {
        private readonly AppSettings _appSettings;
        private readonly IConnectionBase _connectionBase;

        public DataAppointment(IOptions<AppSettings> appSettings,
                                IConnectionBase ConnectionBase)
        {
            _appSettings = appSettings.Value;
            _connectionBase = ConnectionBase;
        }

        public async Task<ResultEntity> Delete(int idAppointment)
        {
            ResultEntity entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidappointment", idAppointment)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("sp_delete_appointment", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
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

        public async Task<IEnumerable<Appointment>> FindAppointments(DateTime date, int idDoctor)
        {
            IEnumerable<Appointment> entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@niddoctor", idDoctor),
                    new SqlParameter("@dappointment", date)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.sps_list_appointment", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    if (dr.HasRows)
                        entity = dr.ReadRows<Appointment>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<IEnumerable<Appointment>>(entity);
        }

        public async Task<IEnumerable<AppointmentDetail>> FindAppointmentById(int idAppointment)
        {
            IEnumerable<AppointmentDetail> entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidappointment", idAppointment)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.sps_get_appointment", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    if (dr.HasRows)
                        entity = dr.ReadRows<AppointmentDetail>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<IEnumerable<AppointmentDetail>>(entity);
        }

        public async Task<ResultEntity> SaveAppointment(Appointment request)
        {
            ResultEntity entity = null;
            try
            {

                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidpattient", request.NIDPATIENT),
                    new SqlParameter("@niddoctor", request.NIDDOCTOR),
                    new SqlParameter("@dappoitnment", request.DAPPOINTMENT),
                    new SqlParameter("@scomment", request.SCOMENT)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spi_save_appointment", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    while (dr.Read())
                    {
                        entity = dr.ReadFields<ResultEntity>();
                    }
                }

                //Si se registro correctament
                if (entity.resultado > 0)
                {
                    int idAppointment = entity.resultado;

                    foreach(var item in request.cadenaConfigHoras.Split(','))
                    {
                        List<SqlParameter> parametersDetail = new List<SqlParameter> {
                            new SqlParameter("@nidappointment", idAppointment),
                            new SqlParameter("@nidconfighora", Convert.ToInt32(item))
                        };

                        using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spi_save_appointment_detail", parametersDetail, ConnectionBase.enuTypeDataBase.SqlServer))
                        {
                            while (dr.Read())
                            {
                                entity = dr.ReadFields<ResultEntity>();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<ResultEntity>(entity);
        }

        public async Task<IEnumerable<Hour>> GetHours(int idDoctor, int idPatient, DateTime dAppointment)
        {
            IEnumerable<Hour> entity = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter> {
                    new SqlParameter("@nidpatient", idPatient),
                    new SqlParameter("@niddoctor", idDoctor),
                    new SqlParameter("@ddate", dAppointment)
                };

                using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("dbo.sps_list_hours", parameters, ConnectionBase.enuTypeDataBase.SqlServer))
                {
                    if (dr.HasRows)
                        entity = dr.ReadRows<Hour>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<IEnumerable<Hour>>(entity);
        }
    }
}
