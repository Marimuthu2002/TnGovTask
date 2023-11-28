using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Model;

namespace TnGovtSchemeRepository.InterFace
{
    public interface IcandidateRegister
    {
        Task<LoginModel> Addcandidate(RegisterModel employee);

        Task<ResponseMessage> Login(LoginModel employee);
        
    }
}
