#region Imports

using System;
using System.Threading;
using System.Threading.Tasks;
using SPAR.Shared.Domain.Bus.Command;
using MediatR;

#endregion

namespace SPLAR.Wiki.Animes.Application.Delete
{
    public class AnimeDeleteCommandHandler : ICommandHandler<AnimeDeleteCommand>
    {
        public async Task<Unit> Handle(AnimeDeleteCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Anime Delete Command receiver with name {request.AnimeName}");
            return new Unit();
        }
    }
}