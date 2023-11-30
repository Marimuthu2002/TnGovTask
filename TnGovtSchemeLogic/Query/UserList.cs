using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnGovtSchemeCommon.Model;

namespace TnGovtSchemeLogic.Query
{
    public class UserList : IRequest<List<getUserModel>>
    {

    }
}
