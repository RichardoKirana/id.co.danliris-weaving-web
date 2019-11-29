﻿using Infrastructure.Domain;
using Infrastructure.Domain.Events;
using Manufactures.Domain.DailyOperations.Sizing.ReadModels;
using Manufactures.Domain.Shared.ValueObjects;
using System;
using System.Linq;

namespace Manufactures.Domain.DailyOperations.Sizing.Entities
{
    public class DailyOperationSizingHistory : EntityBase<DailyOperationSizingHistory>
    {
        public Guid ShiftDocumentId { get; private set; }

        public Guid OperatorDocumentId { get; private set; }

        public DateTimeOffset DateTimeMachine { get; private set; }

        public string MachineStatus { get; private set; }

        public string Information { get; private set; }

        public int BrokenBeam { get; private set; }

        public int MachineTroubled { get; private set; }

        public string SizingBeamNumber { get; private set; }

        public Guid DailyOperationSizingDocumentId { get; set; }

        public DailyOperationSizingReadModel DailyOperationSizingDocument { get; set; }

        public DailyOperationSizingHistory(Guid identity) : base(identity)
        {
        }

        public DailyOperationSizingHistory(Guid identity,
                                           ShiftId shiftDocumentId,
                                           OperatorId operatorDocumentId,
                                           DateTimeOffset dateTimeMachine,
                                           string machineStatus,
                                           string information,
                                           int brokenBeam,
                                           int machineTroubled,
                                           string sizingBeamNumber) : base(identity)
        {
            ShiftDocumentId = shiftDocumentId.Value;
            OperatorDocumentId = operatorDocumentId.Value;
            DateTimeMachine = dateTimeMachine;
            MachineStatus = machineStatus;
            Information = information;
            BrokenBeam = brokenBeam;
            MachineTroubled = machineTroubled;
            SizingBeamNumber = sizingBeamNumber;
        }

        public void SetShiftId(ShiftId shiftDocumentId)
        {
            ShiftDocumentId = shiftDocumentId.Value;
            MarkModified();
        }

        public void SetOperatorDocumentId(OperatorId operatorDocumentId)
        {
            if (!OperatorDocumentId.Equals(operatorDocumentId.Value))
            {
                OperatorDocumentId = operatorDocumentId.Value;
                MarkModified();
            }
        }

        public void SetDateTimeMachine(DateTimeOffset dateTimeMachine)
        {
            DateTimeMachine = dateTimeMachine;
            MarkModified();
        }

        public void SetMachineStatus(string machineStatus)
        {
            MachineStatus = machineStatus;
            MarkModified();
        }

        public void SetInformation(string information)
        {
            Information = information;
            MarkModified();
        }

        public void SetBrokenBeam(int brokenBeam)
        {
            BrokenBeam = brokenBeam;
            MarkModified();
        }

        public void SetMachineTroubled(int machineTroubled)
        {
            MachineTroubled = machineTroubled;
            MarkModified();
        }

        public void SetSizingBeamNumber(string sizingBeamNumber)
        {
            SizingBeamNumber = sizingBeamNumber;
            MarkModified();
        }

        protected override DailyOperationSizingHistory GetEntity()
        {
            return this;
        }

        protected override void MarkRemoved()
        {
            DeletedBy = "System";
            Deleted = true;
            DeletedDate = DateTimeOffset.UtcNow;

            if (this.DomainEvents == null || !this.DomainEvents.Any(o => o is OnEntityDeleted<DailyOperationSizingHistory>))
                this.AddDomainEvent(new OnEntityDeleted<DailyOperationSizingHistory>(GetEntity()));

            // clear updated events
            if (this.DomainEvents.Any(o => o is OnEntityUpdated<DailyOperationSizingHistory>))
            {
                this.DomainEvents.Where(o => o is OnEntityUpdated<DailyOperationSizingHistory>)
                    .ToList()
                    .ForEach(o => this.RemoveDomainEvent(o));
            }
        }
    }
}
