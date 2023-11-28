using Microsoft.EntityFrameworkCore;
using TnGovtSchemeCommon.Model;
namespace TnGovtSchemeCommon.Helper
{
    public class UserNameGenerate
    {
        private readonly ApplicationDbContext _context;

        public UserNameGenerate(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegisterModel>> GetAllUserData()
        {
            var data = await _context.CandidateRegister.ToListAsync();
            return data;
        }

        public async Task<string> UserNameAsync()
        {
            var data = await GetAllUserData();

            int lastTwoDigits = data
                .Where(e => e.UserName.StartsWith("TN"))
                .Select(e => int.Parse(e.UserName.Split('N').Last()))
                .DefaultIfEmpty(0)
                .Max();

            var userQuery = data
                .Where(u => u.UserName.StartsWith($"TN{lastTwoDigits:000}"))
                .Select(u => u.UserName);

            var userIDs = userQuery.ToList();

            if (userIDs.Count == 0)
            {
                return $"TN001";
            }

            var maxNumericPart = userIDs
                .Select(u => int.Parse(u.Split('N').Last()))
                .Max();

            string newUserId = $"TN{(maxNumericPart + 1):000}";

            return newUserId;

        }

        public async Task<string> GeneratePasswordAsync(DateTime userdateofbirth)
        {
            var data = await GetAllUserData();

            int lastThreeDigits = data
                .Where(e => e.UserName.StartsWith("TN"))
                .Select(e => int.Parse(e.UserName.Substring(e.UserName.Length - 3)))
                .DefaultIfEmpty(0)
                .Max();

            var userQuery = data
                .Where(u => u.UserName.StartsWith($"TN{lastThreeDigits:000}"))
                .Select(u => new { u.UserName, u.DateOfBirth });

            var userIDs = userQuery.ToList();

            if (userIDs.Count == 0)
            {
                return $"001{userdateofbirth.ToString("ddMMyyyy")}";
            }

            var dateOfBirthPart = userdateofbirth.ToString("ddMMyyyy");
            //var dateOfBirthPart = userIDs[0].DateOfBirth.ToString("ddMMyyyy").Substring(3);

            string newPassword = $"{(lastThreeDigits + 1):000}{dateOfBirthPart}";

            return newPassword;
        }

    }
}
