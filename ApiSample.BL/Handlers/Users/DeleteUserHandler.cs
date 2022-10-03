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
    public class DeleteUserHandler: IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IDataAccess _dataAccess; 

        public DeleteUserHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<User?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.DeleteUser(request.loginName));
        }
    }
}
