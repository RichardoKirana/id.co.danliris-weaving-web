﻿using Infrastructure.Domain;
using Manufactures.Domain.DailyOperations.Loom.ReadModels;
using Manufactures.Domain.DailyOperations.Loom.ValueObjects;
using Manufactures.Domain.Shared.ValueObjects;
using System;

namespace Manufactures.Domain.DailyOperations.Loom.Entities
{
    public class DailyOperationLoomDetail
        : EntityBase<DailyOperationLoomDetail>
    {
        public Guid OrderId { get; private set; }
        public Guid ShiftId { get; private set; }
        public Guid BeamOperatorId { get; private set; }
        public Guid SizingOperatorId { get; private set; }
        public Guid BeamId { get; private set; }
        public string DailyOperationLoomHistory { get; private set; }
        public string WarpOrigin { get; private set; }
        public string WeftOrigin { get; private set; }
        public Guid DailyOperationLoomDocumentId { get; set; }
        public DailyOperationLoomReadModel DailyOperationLoomDocument { get; set; }

        public DailyOperationLoomDetail(Guid identity) : base(identity)
        {
        }

        public DailyOperationLoomDetail(Guid identity,
                                             OrderId orderDocumentId,
                                             Origin warpOrigin,
                                             Origin weftOrigin,
                                             BeamId beamDocumentId,
                                             DailyOperationLoomHistory dailyOperationLoomHistory,
                                             ShiftId shiftDocumentId,
                                             OperatorId beamOperatorDocumentId,
                                             OperatorId sizingOperatorDocumentId) 
            : base(identity)
        {
            Identity = identity;
            OrderId = orderDocumentId.Value;
            WarpOrigin = warpOrigin.Serialize();
            WeftOrigin = weftOrigin.Serialize();
            BeamId = beamDocumentId.Value;
            DailyOperationLoomHistory = dailyOperationLoomHistory.Serialize();
            ShiftId = shiftDocumentId.Value;
            BeamOperatorId = beamOperatorDocumentId.Value;
            SizingOperatorId = sizingOperatorDocumentId.Value;
        }

        protected override DailyOperationLoomDetail GetEntity()
        {
            return this;
        }
    }
}