using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Data.Interfaces;
using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business
{
    public class BusinessPatient : IBusinessPatient
    {
        private readonly IPatient _patientRepository;

        public BusinessPatient(IPatient patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<ResultEntity> Delete(int idPatient)
        {
            try
            {
                var result = await _patientRepository.Delete(idPatient);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Patient>> FindAllPatients()
        {
            try
            {
                var result = await _patientRepository.FindAllPatients();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Patient> FindPatientById(int idPatient)
        {
            try
            {
                var result = await _patientRepository.FindPatientById(idPatient);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultEntity> SavePatient(Patient request)
        {
            try
            {
                var result = await _patientRepository.SavePatient(request);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultEntity> UpdatePatient(Patient request)
        {
            try
            {
                var result = await _patientRepository.UpdatePatient(request);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
