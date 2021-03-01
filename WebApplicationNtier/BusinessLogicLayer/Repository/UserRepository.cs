using BusinessLogicLayer.IRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private  ApplicationContext _context;
       
        string errorMessage = string.Empty;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
           
        }

        public User GetStudentByID(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
