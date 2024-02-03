using Microsoft.EntityFrameworkCore;
using NoteProject.DAL.Context;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Repositories
{
    public class UserRepository
    {
        AppDbContext dbContext;
        public UserRepository()
        {
            dbContext = new AppDbContext();
        }

        public void Add(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            dbContext.Users.Update(user);
            dbContext.SaveChanges();
        }

        public void Delete(int userId)
        {
            User user = dbContext.Users.Find(userId);
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

        public User GetByID(int userId)
        {
            User user = dbContext.Users.Find(userId);
            return user;
        }

        public User GetByUserName(string userName)
        {
            User user = dbContext.Users.FirstOrDefault(x=> x.UserName == userName);
            return user;
        }

        public List<User> GetStandartUsers()
        {
            List<User> users = dbContext.Users.Where(x=> x.UserType == Domain.Enums.UserType.Standart).ToList();
            return users;
        }
    }
}
