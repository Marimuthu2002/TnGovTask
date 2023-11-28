using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Model;

namespace TnGovtSchemeLogic.Command
{
    public class CandidateLoginCommand : IRequest<ResponseMessage>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CandidateLoginCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
