using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompanyProject.Models;
using CompanyProjectWPF.Wrapper;

namespace CompanyProjectWPF.UITests.Wrapper
{
    [TestClass]
    public class ValidationClassLevel
    {
        private Employee _employee;

        [TestInitialize]
        public void Initialize()
        {
            _employee = new Employee
            {
                FirstName = "Ahmed",
                LastName = "Ali",
            };
        }

        [TestMethod]
        public void ShouldBeValidAgainWhenFirstNameChanged()
        {
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.FirstName = "";

            Assert.IsFalse(wrapper.IsValid);

            wrapper.FirstName = "ab";
            Assert.IsFalse(wrapper.IsValid);

            wrapper.FirstName = "Ahmed";
            Assert.IsTrue(wrapper.IsValid);

            var emailsErrors = wrapper.GetErrors("FirstName").Cast<string>().ToList();
            Assert.AreEqual(0, emailsErrors.Count);

        }


        [TestMethod]
        public void ShouldIntializeWithoutProblems()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.IsTrue(wrapper.IsValid);
        }
    }
}
