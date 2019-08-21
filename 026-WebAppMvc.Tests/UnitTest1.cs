using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _026_WebAppMvc.Models;
using _026_WebAppMvc.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace _026_WebAppMvc.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void CanChangeLoginName()
        {
            //Arrange
            User user = new User()
            {
                LoginName = "Bob"
            };

            FakeRepository repositoryParam = new FakeRepository();
            repositoryParam.Add(user);

            AdminController target = new AdminController(repositoryParam);

            string oldLoginParam = user.LoginName;
            string newLoginParam = "Joe";

            //Act
            target.ChangeLoginName(oldLoginParam, newLoginParam);

            //Assert
            Assert.AreEqual(newLoginParam, user.LoginName);
            Assert.IsTrue(repositoryParam.DidSubmitChanges);
        }
    }

    public class FakeRepository : IUserRepository
    {
        public List<User> Users = new List<User>();
        public bool DidSubmitChanges = false;

        public void Add(User newUser)
        {
            Users.Add(newUser);
        }

        public User FetchByLoginName(string loginName)
        {
            return Users.First(x => x.LoginName == loginName);
        }

        public void SubmitChanges()
        {
            DidSubmitChanges = true;
        }
    }
}
