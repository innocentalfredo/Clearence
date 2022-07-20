using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Clearence.Repository
{
    public class UserRepository
    {
        private ApplicationDbContext _userInfo;

        public UserRepository()
        {
            _userInfo = new ApplicationDbContext();
        }
        public ApplicationUser UserInfoById(string userID)
        {
            var userInfo = (from g in _userInfo.Users
                            where g.Id == userID
                            select g);
            return userInfo.FirstOrDefault();
        }

        public string UserInfoByForceNumber(string regNumber)
        {
            var user = (from g in _userInfo.Users
                where g.RegistrationNumber == regNumber
                        select g.Id);
            return user.FirstOrDefault();
        }
    }
}