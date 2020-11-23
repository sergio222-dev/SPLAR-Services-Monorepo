#region Imports

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SPLAR.Shared.Domain.Bus.Command;
using SPLAR.Wiki.Animes.Application.Create;

#endregion

namespace SPLAR.Wiki.Animes.Application.Create
{
    public class AnimeCreateCommandHandler : ICommandHandler<AnimeCreateCommand>
    {
        public async Task<Unit> Handle(AnimeCreateCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Anime Create Command received with name {request.AnimeName}");
            return new Unit();
        }
    }
}