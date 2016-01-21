using System;
using System.ComponentModel;

namespace CompanyProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public string SocialNumber { get; set; }
    }
}
