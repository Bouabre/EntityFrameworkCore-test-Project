using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IService
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(long id);
    }
}
