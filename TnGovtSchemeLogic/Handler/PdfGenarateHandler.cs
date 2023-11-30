using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Model;
using TnGovtSchemeLogic.Command;
using TnGovtSchemeRepository.InterFace;

namespace TnGovtSchemeLogic.Handler
{
    public class PdfGenarateHandler : IRequestHandler<PdfGenarateCommand, byte[]>
    {
        private readonly IcandidateRegister _icandidateRegister;
        public PdfGenarateHandler(IcandidateRegister icandidateRegister)
        {
            _icandidateRegister = icandidateRegister;
        }
        public async Task<byte[]> Handle(PdfGenarateCommand request, CancellationToken cancellationToken)
        {
            var loginData = new LoginModel()
            {
                UserName = request.UserName,
                Password = request.Password,
            };
            return await _icandidateRegister.GeneratePdf(loginData);
        }
    }

}
