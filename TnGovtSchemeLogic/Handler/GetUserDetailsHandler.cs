using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Model;
using TnGovtSchemeLogic.Query;
using TnGovtSchemeRepository.InterFace;

namespace TnGovtSchemeLogic.Handler
{
    public class GetUserDetailsHandler : IRequestHandler<UserList, List<getUserModel>>
    {
        private readonly IcandidateRegister _user;
        public GetUserDetailsHandler(IcandidateRegister user)
        {
            _user = user;
        }
        public async Task<List<getUserModel>> Handle(UserList request, CancellationToken cancellationToken)
        {
            return await _user.GetEmploye();
        }
    }
}
