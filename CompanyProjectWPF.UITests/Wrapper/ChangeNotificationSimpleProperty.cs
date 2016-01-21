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
    [TestClass]
    public class ChangeNotificationSimpleProperty
    {
        private Employee _employee;

        [TestInitialize]
        public void Initialize()
        {
            _employee = new Employee
            {
                FirstName = "Ahmed",
                LastName = "Ragheb",
            };
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventOnPropertyChange()
        {
            var fired = false;
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FirstName")
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Julia";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldNotRaisePropertyChangedEventIfPropertyIsSetToSameValue()
        {
            var fired = false;
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FirstName")
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Ahmed";
            Assert.IsFalse(fired);
        }
    }
}
