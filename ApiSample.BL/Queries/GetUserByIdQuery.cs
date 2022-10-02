using ApiSample.Models.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Queries
{
    public record GetUserByIdQuery() : IRequest<User>
    {
        public long Id;
    }
}
