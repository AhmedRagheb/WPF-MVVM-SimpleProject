using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompanyProject.Models;
using CompanyProjectWPF.Wrapper;

namespace CompanyProjectWPF.UITests.Wrapper
{
    [TestClass()]
    public class BasicTest
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

        [TestMethod()]
        public void ShouldContainModelInModelProperty()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.AreEqual(_employee, wrapper.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            try
            {
                var wrapper = new EmployeeWrapper(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void ShouldGetValueOfUnderlyingModelProperty()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.AreEqual(_employee.FirstName, wrapper.FirstName);
        }

        [TestMethod]
        public void ShouldSetValueOfUnderlyingModelProperty()
        {
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.FirstName = "Ragheb";
            Assert.AreEqual("Ragheb", _employee.FirstName);
        }
    }
}
