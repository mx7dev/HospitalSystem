using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Data.Interfaces
{
    public interface IAppointment
    {
        Task<ResultEntity> SaveAppointment(Appointment request);
        Task<ResultEntity> Delete(int idAppointment);
        Task<IEnumerable<Appointment>> FindAppointments(DateTime date, int idDoctor);
        Task<IEnumerable<Hour>> GetHours(int idDoctor, int idPatient, DateTime dAppointment);
        Task<IEnumerable<AppointmentDetail>> FindAppointmentById(int idAppointment);
    }
}
