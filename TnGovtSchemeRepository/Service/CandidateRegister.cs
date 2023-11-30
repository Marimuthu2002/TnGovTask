using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Helper;
using TnGovtSchemeCommon.Model;
using TnGovtSchemeRepository.InterFace;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace TnGovtSchemeRepository.Service
{
    public class CandidateRegister : IcandidateRegister
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public CandidateRegister(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<LoginModel> Addcandidate(RegisterModel candidate)
        {
            var data = _context.CandidateRegister.Add(candidate);
            await _context.SaveChangesAsync();

            var card = new LoginModel()
            {
                UserName = candidate.UserName,
                Password = "*********"
            };

            return card;
        }

        /* public async Task<List<RegisterModel>> GetAllUserData()
         {
             var data = await _context.CandidateRegister.ToListAsync();
             return data;
         }*/

        public async Task<ResponseMessage> Login(LoginModel employee)
        {
            var data = await _context.CandidateRegister
                .Where(a => a.UserName == employee.UserName && a.PassWord == employee.Password)
                .FirstOrDefaultAsync();

            if (data != null)
            {
                var jwtTokenGenerator = new JWTTocken(_config);
                var token = jwtTokenGenerator.TockenGenarate(data);

                if (!string.IsNullOrEmpty(token))
                {
                    return ResponseMessage.New(ResponseCode.OK, token);
                }

                return ResponseMessage.New(ResponseCode.InternalServerError, "Failed to generate token");
            }

            return ResponseMessage.New(ResponseCode.BadRequest, "UserName or Password incorrect");
        }

        public async Task<byte[]> GeneratePdf(LoginModel employee)
        {
            var data = await _context.CandidateRegister
                .Where(a => a.UserName == employee.UserName)
                .FirstOrDefaultAsync();

            if (data != null)
            {
                PdfGenrate pdf = new PdfGenrate();
                byte[] datas = pdf.GeneratePdf(data);
                return datas;
            }

            return null;
        }

        public async Task<List<getUserModel>> GetEmploye()
        {
            var data = await _context.CandidateRegister.ToListAsync();
            var data1 = new List<getUserModel>();
            foreach (var item in data)
            {
                getUserModel getUserModels = new getUserModel()
                {
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    UserName = item.UserName,
                    Aadhar = item.Aadhar,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    Mobilenumber = item.Mobilenumber,
                    Role = item.Role
                };
                data1.Add(getUserModels);
            }

            return data1;
        }

    }
}
