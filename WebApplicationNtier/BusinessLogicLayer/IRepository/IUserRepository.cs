using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.IRepository
{
  
    public interface IUserRepository 
    {
        
        User GetStudentByID(int userId);
       
    }
}
