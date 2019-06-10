﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Infrastructure.Domain.Commands;
using Manufactures.Application.Helpers;
using Manufactures.Domain.DailyOperations.Loom;
using Manufactures.Domain.DailyOperations.Loom.Commands;
using Manufactures.Domain.DailyOperations.Loom.Entities;
using Manufactures.Domain.DailyOperations.Loom.Repositories;
using Microsoft.EntityFrameworkCore;
using Moonlay;

namespace Manufactures.Application.DailyOperations.Loom.CommandHandlers
{
    public class StopDailyOperationLoomCommandHandler 
        : ICommandHandler<StopDailyOperationLoomCommand,
                          DailyOperationLoomDocument>
    {
        private readonly IStorage _storage;
        private readonly IDailyOperationLoomRepository
            _dailyOperationalDocumentRepository;

        public StopDailyOperationLoomCommandHandler(IStorage storage)
        {
            _storage = storage;
            _dailyOperationalDocumentRepository =
                _storage.GetRepository<IDailyOperationLoomRepository>();
        }

        public async Task<DailyOperationLoomDocument> Handle(StopDailyOperationLoomCommand request, 
                                                       CancellationToken cancellationToken)
        {
            var query =
                _dailyOperationalDocumentRepository
                    .Query
                    .Include(o => o.DailyOperationLoomDetails);
            var existingDailyOperation =
                _dailyOperationalDocumentRepository
                    .Find(query)
                    .Where(e => e.Identity.Equals(request.Id))
                    .FirstOrDefault();
            var detail = 
                existingDailyOperation
                    .DailyOperationMachineDetails
                    .OrderByDescending(e => e.DateTimeOperation);

            if (detail.FirstOrDefault().OperationStatus != DailyOperationMachineStatus.ONSTART ||
                detail.FirstOrDefault().OperationStatus != DailyOperationMachineStatus.ONRESUME)
            {
                throw Validator.ErrorValidation(("Status", "Can't stop, check your latest status"));
            }

            var dateTimeOperation =
                request.StopDate.ToUniversalTime().AddHours(7).Date + request.StopTime;
            var firstDetail =
               existingDailyOperation
                   .DailyOperationMachineDetails
                   .OrderByDescending(o => o.DateTimeOperation)
                   .FirstOrDefault();

            if (dateTimeOperation < firstDetail.DateTimeOperation)
            {
                throw Validator.ErrorValidation(("Status", "Date and Time cannot less than latest operation"));
            }

            var newOperation =
                new DailyOperationLoomDetail(Guid.NewGuid(),
                                             request.ShiftId,
                                             request.OperatorId,
                                             Constants.EMPTYvALUE,
                                             Constants.EMPTYvALUE,
                                             dateTimeOperation,
                                             DailyOperationMachineStatus.ONSTOP,
                                             false,
                                             true);

            existingDailyOperation.AddDailyOperationMachineDetail(newOperation);

            await _dailyOperationalDocumentRepository.Update(existingDailyOperation);

            _storage.Save();

            return existingDailyOperation;
        }
    }
}
