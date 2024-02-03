using NoteProject.DAL.Repositories;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.BLL.Services
{
    public class UserService
    {
        UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public User GetByUserName(string userName)
        {
            return userRepository.GetByUserName(userName);
        }
        public User GetByUserId(int userId)
        {
            return userRepository.GetByID(userId);
        }

        public List<User> GetAllStandartUsers() 
        {
            return userRepository.GetStandartUsers();
        }

        public void AddStandartUser(User user)
        {
            user.UserType = Domain.Enums.UserType.Standart;
            user.IsActive = false;
            user.Status = Domain.Enums.Status.Added;
            userRepository.Add(user);
        }

        public void Update(User user)
        {
            user.Status = Domain.Enums.Status.Modified;
            user.ModifiedDate = DateTime.Now;
            userRepository.Update(user);
        }

        public void Delete(int userId)
        {
            User user = userRepository.GetByID(userId);
            user.Status = Domain.Enums.Status.Deleted;
            user.DeletedDate = DateTime.Now;
            user.IsActive = false;
            userRepository.Update(user);
        }

        public void ChangeActiveStatus(int userId)
        {
            User user = userRepository.GetByID(userId);
            if(user.IsActive)
            {
                user.IsActive = false;
            }
            else
                user.IsActive = true;
            Update(user);
        }

        public bool CheckUser(string userName)
        {
            User user = GetByUserName(userName);
            if (user is null)
                return false;
            else
                return true;
        }
    }
}
