﻿using ExtCore.Data.Abstractions;
using Infrastructure.Domain.Commands;
using Manufactures.Domain.Rings;
using Manufactures.Domain.Rings.Commands;
using Manufactures.Domain.Rings.Repositories;
using Moonlay;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manufactures.Application.Rings.CommandHandlers
{
    public class UpdateRingDocumentCommandHandler : ICommandHandler<UpdateRingDocumentCommand, RingDocument>
    {
        private readonly IStorage _storage;
        private readonly IRingRepository _ringRepository;

        public UpdateRingDocumentCommandHandler(IStorage storage)
        {
            _storage = storage;
            _ringRepository = storage.GetRepository<IRingRepository>();
        }

        public async Task<RingDocument> Handle(UpdateRingDocumentCommand request, 
                                               CancellationToken cancellationToken)
        {
            var ringDocument = 
                _ringRepository.Find(entity => entity.Identity.Equals(request.Id))
                                                              .FirstOrDefault();

            if(ringDocument == null)
            {
                throw Validator.ErrorValidation(("Id", "Invalid ring Id: " + request.Id));
            }
            
            ringDocument.SetCode(request.Code);
            ringDocument.SetNumber(request.Number);
            ringDocument.SetRingType(request.RingType);
            ringDocument.SetDescription(request.Description);

            await _ringRepository.Update(ringDocument);

            _storage.Save();

            return ringDocument;
        }
    }
}
