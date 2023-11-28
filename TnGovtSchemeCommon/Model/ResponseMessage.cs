using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnGovtSchemeCommon.Model
{
    public class ResponseMessage
    {
        public ResponseCode Code { get; }
        public dynamic Message { get; set; }
        public ResponseMessage(ResponseCode code, dynamic message)
        {
            Code = code;
            Message = message;
        }
        public static ResponseMessage New(ResponseCode code, dynamic message)
        {
            return new ResponseMessage(code, message);
        }
    }
}
