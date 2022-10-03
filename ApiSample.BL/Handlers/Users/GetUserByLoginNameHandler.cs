using ApiSample.BL.Interfaces;
using ApiSample.BL.Queries.Users;
using ApiSample.Models.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Handlers.Users
{
    public class GetUserByLoginNameHandler : IRequestHandler<GetUserByLoginNameQuery, User>
    {
        private readonly IDataAccess _dataAccess;

        public GetUserByLoginNameHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<User?> Handle(GetUserByLoginNameQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetUserByLoginName(request.loginName));
        }
    }
}
