using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Business.Interfaces
{
    public interface IBusinessUser
    {
        Task<UserInfo> GetUserInfo(string username);
        Task<ResultEntity> Authenticate(string susername, string spassword);
    }
}
