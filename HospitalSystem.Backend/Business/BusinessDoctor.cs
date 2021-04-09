using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Data.Interfaces;
using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business
{
    public class BusinessDoctor : IBusinessDoctor
    {
        private readonly IDoctor _doctorRepository;

        public BusinessDoctor(IDoctor doctorRepository) {
            _doctorRepository = doctorRepository;
        }

        public async Task<ResultEntity> Delete(int idDoctor)
        {
            try
            {
                var result = await _doctorRepository.Delete(idDoctor);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Doctor>> FindAllDoctors()
        {
            try
            {
                var result = await _doctorRepository.FindAllDoctors();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Doctor> FinDoctorById(int idDoctor)
        {
            try
            {
                var result = await _doctorRepository.FinDoctorById(idDoctor);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultEntity> SaveDoctor(Doctor request)
        {
            try
            {
                var result = await _doctorRepository.SaveDoctor(request);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultEntity> UpdateDoctor(Doctor request)
        {
            try
            {
                var result = await _doctorRepository.UpdateDoctor(request);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
