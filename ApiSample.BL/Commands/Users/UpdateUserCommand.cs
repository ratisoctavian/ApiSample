using ApiSample.Models.DataModel;
using ApiSample.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Commands.Users
{
    public record UpdateUserCommand(string firstName, string lastName, string loginName, string email, string phoneNumber, UserTypes userType): IRequest<User>;
}
