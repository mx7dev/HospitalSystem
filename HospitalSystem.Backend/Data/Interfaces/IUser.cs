using HospitalSystem.Backend.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Data.Interfaces
{
    public interface IUser
    {
        Task<UserInfo> GetUserInfo(string username);
        Task<ResultEntity> Authenticate(string susername, string spassword);
    }
}
