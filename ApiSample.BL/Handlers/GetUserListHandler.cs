﻿using ApiSample.BL.Interfaces;
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
    public class GetUserListHandler: IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IDataAccess _dataAccess;

        public GetUserListHandler(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }   

        public Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetUsers());
        }
    }
}
