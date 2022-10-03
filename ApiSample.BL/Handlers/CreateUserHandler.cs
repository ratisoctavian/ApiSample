using ApiSample.BL.Commands;
using ApiSample.BL.Interfaces;
using ApiSample.BL.Queries;
using ApiSample.Models.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IDataAccess _dataAccess;

        public CreateUserHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            return Task.FromResult(_dataAccess.CreateUser(request.firstName, request.lastName, request.loginName, request.email, request.phoneNumber, request.userType));
        }
    }
}
