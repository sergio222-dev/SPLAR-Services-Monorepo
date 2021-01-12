#region Imports

using System;
using System.Threading;
using System.Threading.Tasks;
using SPAR.Shared.Domain.Bus.Command;
using MediatR;
using Microsoft.Extensions.Configuration;
using SPAR.Wiki.Animes.Domain;
using SPLAR.Wiki.Shared.Domain.Animes;
using SPLAR.Wiki.Shared.Domain.Studios;

#endregion

namespace SPLAR.Wiki.Animes.Application.Create
{
    public class AnimeCreateCommandHandler : ICommandHandler<AnimeCreateCommand>
    {
        private AnimeCreator AnimeCreator { get; set; }

        public AnimeCreateCommandHandler( AnimeCreator oCreaotr)
        {
            AnimeCreator = oCreaotr;
        }
        
        public Task<Unit> Handle(AnimeCreateCommand request, CancellationToken cancellationToken)
        {
            var id = new AnimeId(Guid.Parse(request.AnimeId));
            var name = new AnimeName(request.AnimeName);
            var studioId = new StudioId(Guid.Parse(request.StudioId));
            
            AnimeCreator.Create(id, name, studioId);

            return new Task<Unit>(() => Unit.Value);
        }
    }
}