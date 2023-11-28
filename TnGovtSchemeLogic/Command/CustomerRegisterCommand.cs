using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Model;

namespace TnGovtSchemeLogic.Command
{
    public class CustomerRegisterCommand : IRequest<LoginModel>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Aadhar { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public CustomerRegisterCommand(int id, string firstname, string lastname, string email, string mobilenumber, DateTime dob, string aadhar, string username, string password,string role)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Mobilenumber = mobilenumber;
            DateOfBirth = dob;
            Aadhar = aadhar;
            UserName = username;
            PassWord = password;
            Role = role;
        }
    }
}
