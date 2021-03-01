using BusinessLogicLayer.IRepository;
using DataAccessLayer.Models;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Service
{
    public class UserProfileService : IUserProfileService
    {
        private IRepository<UserProfile> userProfileRepository;

        public UserProfileService(IRepository<UserProfile> userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        public UserProfile GetUserProfile(long id)
        {
            return userProfileRepository.Get(id);
        }
    }
}
