using HospitalSystem.Backend.Data.Interfaces;
using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business.Interfaces
{
    public class BusinessUser : IBusinessUser
    {
        private readonly IUser _userRepository;
        public BusinessUser(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultEntity> Authenticate(string susername, string spassword)
        {
            try
            {
                var result = await _userRepository.Authenticate(susername, spassword);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserInfo> GetUserInfo(string username)
        {
            try
            {
                var result = await _userRepository.GetUserInfo(username);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
