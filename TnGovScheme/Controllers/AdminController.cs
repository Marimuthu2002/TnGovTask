using MediatR;
using Microsoft.AspNetCore.Mvc;
using TnGovtSchemeCommon.Model;
using TnGovtSchemeLogic.Query;

namespace TnGovScheme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<List<getUserModel>> GetEmployeeListAsync()
        {
            var EmployeeDetails = await _mediator.Send(new UserList());

            return EmployeeDetails;
        }
        [HttpPost("Uploadfile")]
        public async Task<IActionResult> Upload([FromForm]UserImageData userImage)
        {
            try
            {
                string Username = userImage.UserName;
                if (userImage.files != null && userImage.files.Any())
                {
                    string userFolderPath = Path.Combine("wwwroot", "Certificate", Username);

                    if (!Directory.Exists(userFolderPath))
                    {
                        Directory.CreateDirectory(userFolderPath);
                    }


                    if (!Directory.Exists(userFolderPath))
                    {
                        Directory.CreateDirectory(userFolderPath);
                    }

                    List<string> uploadedFileNames = new List<string>();

                    foreach (var file in userImage.files)
                    {
                        var fileName = $"{file.FileName}.pdf";

                        var filePath = Path.Combine(userFolderPath, fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        uploadedFileNames.Add(fileName);
                    }

                    return Ok($"Files uploaded successfully: {string.Join(", ", uploadedFileNames)}");
                }
                else
                {
                    return BadRequest("Invalid files");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
