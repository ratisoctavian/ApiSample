using ApiSample.BL.Commands.Users;
using ApiSample.BL.Interfaces;
using ApiSample.Models.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Handlers.Users
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IDataAccess _dataAccess;

        public UpdateUserHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<User?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.UpdateUser(request.firstName, request.lastName, request.loginName, request.email, request.phoneNumber, request.userType));
        }
    }
}
