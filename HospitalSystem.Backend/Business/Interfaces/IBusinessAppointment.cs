using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business.Interfaces
{
    public interface IBusinessAppointment
    {
        Task<ResultEntity> SaveAppointment(Appointment request);
        Task<ResultEntity> Delete(int idAppointment);
        Task<IEnumerable<Appointment>> FindAppointments(DateTime date, int idDoctor);
        Task<IEnumerable<Hour>> GetHours(int idDoctor, int idPatient, DateTime dAppointment);
        Task<IEnumerable<AppointmentDetail>> FindAppointmentById(int idAppointment);
    }
}
