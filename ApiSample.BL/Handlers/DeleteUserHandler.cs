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
    public class DeleteUserHandler
    {
        private readonly IDataAccess _dataAccess;

        public DeleteUserHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }
        public Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            return Task.FromResult(_dataAccess.DeleteUser(request.loginName));
        }
    }
}
