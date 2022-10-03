using ApiSample.BL.Commands;
using ApiSample.BL.Interfaces;
using ApiSample.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Handlers
{
    public class UpdateUserHandler
    {
        private readonly IDataAccess _dataAccess;

        public UpdateUserHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        public Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            return Task.FromResult(_dataAccess.UpdateUser(request.firstName, request.lastName, request.loginName, request.email, request.phoneNumber, request.userType));
        }
    }
}
