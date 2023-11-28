using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TnGovtSchemeCommon.Helper;
using TnGovtSchemeCommon.Model;
using TnGovtSchemeLogic.Command;

namespace TnGovScheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<LoginModel> AddStudentAsync(RegisterModel EmployeeDetails)
        {
            var studentDetail = await _mediator.Send(new CustomerRegisterCommand(
                EmployeeDetails.Candidate_Id,
                EmployeeDetails.Firstname,
                EmployeeDetails.Lastname,
                EmployeeDetails.Email,
                EmployeeDetails.Mobilenumber,
                EmployeeDetails.DateOfBirth,
                EmployeeDetails.Aadhar,
                EmployeeDetails.UserName,
                EmployeeDetails.PassWord,
                EmployeeDetails.Role
                ));
            return studentDetail;   
        }
        [HttpPost("Login")]
        public async Task<ResponseMessage> LoginCandidate(LoginModel LoginDetails)
        {
            var CandidateDetail = await _mediator.Send(new CandidateLoginCommand(
                       LoginDetails.UserName,
                       LoginDetails.Password
                       ));
            return CandidateDetail;
        }

        [HttpGet]
        public IActionResult generatepdf()
        {
            PdfGenrate pdf = new PdfGenrate();
            pdf.GeneratePdf();
            return Ok();

        }
    }
}
