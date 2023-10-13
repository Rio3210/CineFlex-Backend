using cineflex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Cinemas.Requests.Commands
{
    public class DeleteCinemaCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; } 
    }
}