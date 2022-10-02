using ApiSample.BL.Interfaces;
using ApiSample.BL.Queries;
using ApiSample.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Handlers
{
    public class GetUserByIdHandler
    {
        private readonly IDataAccess _dataAccess;

        public GetUserByIdHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = _dataAccess.GetUsers();

            var user = users.FirstOrDefault(u => u.Id == request.Id);

            return Task.FromResult(user);
        }
    }
}
