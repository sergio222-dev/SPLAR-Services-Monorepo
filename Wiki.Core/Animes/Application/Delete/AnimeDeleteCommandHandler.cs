using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SPLAR.Shared.Domain.Bus.Command;

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