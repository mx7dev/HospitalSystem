using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Data.Interfaces;
using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business
{
    public class BusinessAppointment : IBusinessAppointment
    {
        private readonly IAppointment _appointmentRepository;

        public BusinessAppointment(IAppointment appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

        }
        public async Task<ResultEntity> Delete(int idAppointment)
        {
            try
            {
                var result = await _appointmentRepository.Delete(idAppointment);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AppointmentDetail>> FindAppointmentById(int idAppointment)
        {
            try
            {
                var result = await _appointmentRepository.FindAppointmentById(idAppointment);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Appointment>> FindAppointments(DateTime date, int idDoctor)
        {
            try
            {
                var result = await _appointmentRepository.FindAppointments(date, idDoctor);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Hour>> GetHours(int idDoctor, int idPatient, DateTime dAppointment)
        {
            try
            {
                var result = await _appointmentRepository.GetHours(idDoctor, idPatient, dAppointment);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultEntity> SaveAppointment(Appointment request)
        {
            try
            {
                var result = await _appointmentRepository.SaveAppointment(request);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
