using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnGovtSchemeCommon.Model
{
    public class UserImageData
    {
        public List<IFormFile> files { get; set; }
        public string UserName { get; set; }
    }
}
