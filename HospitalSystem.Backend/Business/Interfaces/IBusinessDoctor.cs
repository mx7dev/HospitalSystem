using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business.Interfaces
{
    public interface IBusinessDoctor
    {
        Task<ResultEntity> SaveDoctor(Doctor request);
        Task<ResultEntity> UpdateDoctor(Doctor request);
        Task<ResultEntity> Delete(int idDoctor);
        Task<IEnumerable<Doctor>> FindAllDoctors();
        Task<Doctor> FinDoctorById(int idDoctor);
    }
}
