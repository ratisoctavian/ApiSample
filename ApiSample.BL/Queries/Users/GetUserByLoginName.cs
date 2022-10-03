using ApiSample.Models.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Queries.Users
{
    public record GetUserByLoginName(string loginName) : IRequest<ApiSample.Models.DataModel.User>;
}
