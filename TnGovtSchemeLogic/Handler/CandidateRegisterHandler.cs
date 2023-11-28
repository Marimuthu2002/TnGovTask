using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Helper;
using TnGovtSchemeCommon.Model;
using TnGovtSchemeLogic.Command;
using TnGovtSchemeRepository.InterFace;

namespace TnGovtSchemeLogic.Handler
{
    public class CandidateRegisterHandler : IRequestHandler<CustomerRegisterCommand, LoginModel>
    {
        private readonly IcandidateRegister _icandidateRegister;
        private readonly ApplicationDbContext _context;
        public CandidateRegisterHandler(IcandidateRegister icandidateRegister, ApplicationDbContext context)
        {
            _icandidateRegister = icandidateRegister;
            _context = context;
        }

        public async Task<LoginModel> Handle(CustomerRegisterCommand command, CancellationToken cancellationToken)
        {
            UserNameGenerate US = new UserNameGenerate(_context);
            var canditate = new RegisterModel()
            {

                Candidate_Id = command.Id,
                Firstname = command.Firstname,
                Lastname = command.Lastname,
                Email = command.Email,
                DateOfBirth = command.DateOfBirth,
                Mobilenumber = command.Mobilenumber,
                Aadhar = command.Aadhar,
                Role= command.Role,
                UserName = await US.UserNameAsync(),
                PassWord = await US.GeneratePasswordAsync(command.DateOfBirth),
            };

           

            return await _icandidateRegister.Addcandidate(canditate);
        }
    }
}
