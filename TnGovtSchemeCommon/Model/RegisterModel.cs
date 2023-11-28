using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnGovtSchemeCommon.Model
{
    public class RegisterModel
    {
        [Key]
        public int Candidate_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Aadhar { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
    } 
    public class LoginModel
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
      
    }
}
