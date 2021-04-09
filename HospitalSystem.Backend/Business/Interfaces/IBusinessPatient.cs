using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business.Interfaces
{
    public interface IBusinessPatient
    {
        Task<ResultEntity> SavePatient(Patient request);
        Task<ResultEntity> UpdatePatient(Patient request);
        Task<ResultEntity> Delete(int idPatient);
        Task<IEnumerable<Patient>> FindAllPatients();
        Task<Patient> FindPatientById(int idPatient);
    }
}
