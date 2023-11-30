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

       /* [HttpPost("GenerateAndDownloadPdf")]
        public IActionResult GenerateAndDownloadPdf(LoginModel loginDetails)
        {
            var candidateDetail = _context.CandidateRegister
                .Where(a => a.UserName == loginDetails.UserName)
                .FirstOrDefault();

            if (candidateDetail != null)
            {
                var pdfBytes = _pdfGenrate.GeneratePdf(candidateDetail);

                // Return the PDF file as a downloadable file
                return File(pdfBytes, "application/pdf", "EncryptedDocument.pdf");
            }

            // Handle the case where candidateDetail is null (not found)
            return NotFound();
        }*/

        [HttpPost("GenaratePdf")]
        public async Task<IActionResult> GeneratePdf(LoginModel loginDetails)
        {
            var pdfBytes = await _mediator.Send(new PdfGenarateCommand(loginDetails.UserName, loginDetails.Password));

            if (pdfBytes != null)
            {
                // Return the PDF file as a downloadable file
                return File(pdfBytes, "application/pdf", "EncryptedDocument.pdf");
            }

            // Handle the case where the PDF data is null
            return NotFound();
        }



    }
}
