using ApiSample.Models.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Commands.Users
{
    public record DeleteUserCommand(string loginName): IRequest<User>;
}
