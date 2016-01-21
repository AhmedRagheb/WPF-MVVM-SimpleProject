using System;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Models;
using CompanyProjectWPF.ViewModels;

namespace CompanyProjectWPF.Wrapper
{

    public class EmployeeWrapper : ModelWrapper<Employee>
    {
        public EmployeeWrapper(Employee model)
            : base(model)
        {

        }

        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [Required]
        [StringLength(35, MinimumLength = 3)]
        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        [Required]
        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string EmailAddress
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DateTime BirthDate
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        //public string Photo
        //{
        //    get { return GetValue(() => Photo); }
        //    set { SetValue(() => Photo, value); }
        //}

        public string SocialNumber
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}

