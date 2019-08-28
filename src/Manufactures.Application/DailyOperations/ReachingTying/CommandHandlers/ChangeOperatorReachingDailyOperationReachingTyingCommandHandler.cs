﻿using ExtCore.Data.Abstractions;
using Infrastructure.Domain.Commands;
using Manufactures.Application.Helpers;
using Manufactures.Domain.DailyOperations.ReachingTying;
using Manufactures.Domain.DailyOperations.ReachingTying.Command;
using Manufactures.Domain.DailyOperations.ReachingTying.Entities;
using Manufactures.Domain.DailyOperations.ReachingTying.Repositories;
using Manufactures.Domain.DailyOperations.ReachingTying.ValueObjects;
using Manufactures.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Moonlay;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Manufactures.Application.DailyOperations.ReachingTying.CommandHandlers
{
    public class ChangeOperatorReachingDailyOperationReachingTyingCommandHandler : ICommandHandler<ChangeOperatorReachingDailyOperationReachingTyingCommand, DailyOperationReachingTyingDocument>
    {
        private readonly IStorage _storage;
        private readonly IDailyOperationReachingTyingRepository
            _dailyOperationReachingTyingDocumentRepository;

        public ChangeOperatorReachingDailyOperationReachingTyingCommandHandler(IStorage storage)
        {
            _storage = storage;
            _dailyOperationReachingTyingDocumentRepository =
                _storage.GetRepository<IDailyOperationReachingTyingRepository>();
        }

        public async Task<DailyOperationReachingTyingDocument> Handle(ChangeOperatorReachingDailyOperationReachingTyingCommand request, CancellationToken cancellationToken)
        {
            var query =
                _dailyOperationReachingTyingDocumentRepository.Query
                                                         .Include(d => d.ReachingTyingDetails)
                                                         .Where(doc => doc.Identity.Equals(request.Id));
            var existingReachingTyingDocument = _dailyOperationReachingTyingDocumentRepository.Find(query).FirstOrDefault();
            var existingReachingTyingDetail =
                existingReachingTyingDocument.ReachingTyingDetails
                .OrderByDescending(d => d.DateTimeMachine);
            var lastReachingTyingDetail = existingReachingTyingDetail.FirstOrDefault();

            //Validation for Operation Status
            var operationStatus = existingReachingTyingDocument.OperationStatus;
            if (operationStatus.Equals(OperationStatus.ONFINISH))
            {
                throw Validator.ErrorValidation(("OperationStatus", "Can's Finish. This operation's status already FINISHED"));
            }

            //Reformat DateTime
            var year = request.ChangeOperatorReachingDate.Year;
            var month = request.ChangeOperatorReachingDate.Month;
            var day = request.ChangeOperatorReachingDate.Day;
            var hour = request.ChangeOperatorReachingTime.Hours;
            var minutes = request.ChangeOperatorReachingTime.Minutes;
            var seconds = request.ChangeOperatorReachingTime.Seconds;
            var dateTimeOperation =
                new DateTimeOffset(year, month, day, hour, minutes, seconds, new TimeSpan(+7, 0, 0));

            //Validation for Start Date
            var lastDateMachineLogUtc = new DateTimeOffset(lastReachingTyingDetail.DateTimeMachine.Date, new TimeSpan(+7, 0, 0));
            var reachingChangeOperatorDateMachineLogUtc = new DateTimeOffset(request.ChangeOperatorReachingDate.Date, new TimeSpan(+7, 0, 0));

            if (reachingChangeOperatorDateMachineLogUtc < lastDateMachineLogUtc)
            {
                throw Validator.ErrorValidation(("ReachingChangeOperator", "Change Operator date cannot less than latest date log"));
            }
            else
            {
                if (dateTimeOperation < lastReachingTyingDetail.DateTimeMachine)
                {
                    throw Validator.ErrorValidation(("ReachingChangeOperator", "Change Operator time cannot less than latest time log"));
                }
                else
                {
                    if (lastReachingTyingDetail.MachineStatus.Equals(MachineStatus.ONSTARTREACHING) || lastReachingTyingDetail.MachineStatus.Equals(MachineStatus.CHANGEOPERATORREACHING))
                    {
                        var reachingValueObjects = JsonConvert.DeserializeObject<DailyOperationReachingValueObject>(existingReachingTyingDocument.ReachingValueObjects);
                        existingReachingTyingDocument.SetReachingValueObjects(new DailyOperationReachingValueObject(reachingValueObjects.ReachingTypeInput,
                                                                                                                    reachingValueObjects.ReachingTypeOutput,
                                                                                                                    reachingValueObjects.ReachingWidth));

                        var newOperationDetail =
                            new DailyOperationReachingTyingDetail(Guid.NewGuid(),
                                                                  new OperatorId(request.OperatorDocumentId.Value),
                                                                  request.YarnStrandsProcessed,
                                                                  dateTimeOperation,
                                                                  new ShiftId(request.ShiftDocumentId.Value),
                                                                  MachineStatus.CHANGEOPERATORREACHING);
                        existingReachingTyingDocument.AddDailyOperationReachingTyingDetail(newOperationDetail);

                        await _dailyOperationReachingTyingDocumentRepository.Update(existingReachingTyingDocument);

                        _storage.Save();

                        return existingReachingTyingDocument;
                    }
                    else
                    {
                        throw Validator.ErrorValidation(("OperationStatus", "Can's Change Operator. This operation's status not ONSTARTREACHING"));
                    }
                }
            }
        }
    }
}
