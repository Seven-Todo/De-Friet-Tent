using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Friet_Tent.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public string Emailaddress { get; set; } = null!;
        public string Address { get; set; } = null!;


        //public Employee(int id, string firstname, string lastname, string phonenumber, string emailaddress, string address, string occupation)
        //{
        //    Id = id;
        //    Firstname = firstname;
        //    Lastname = lastname;
        //    Phonenumber = phonenumber;
        //    Emailaddress = emailaddress;
        //    Address = address;
        //    Occupation = occupation;
        //}
    }
}
