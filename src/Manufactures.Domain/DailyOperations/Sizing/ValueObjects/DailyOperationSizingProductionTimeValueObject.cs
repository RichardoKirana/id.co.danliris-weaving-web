﻿using Manufactures.Domain.DailyOperations.Sizing.Commands;
using Moonlay.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Domain.DailyOperations.Sizing.ValueObjects
{
    public class DailyOperationSizingProductionTimeValueObject : ValueObject
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Pause { get; set; }
        public DateTimeOffset Resume { get; set; }
        public DateTimeOffset Doff { get; set; }

        public DailyOperationSizingProductionTimeValueObject(DateTimeOffset start, DateTimeOffset pause, DateTimeOffset resume, DateTimeOffset doff)
        {
            Start = start;
            Pause = pause;
            Resume = resume;
            Doff = doff;
        }

        public DailyOperationSizingProductionTimeValueObject(DailyOperationSizingProductionTimeCommand dailyOperationSizingProduction)
        {
            Start = dailyOperationSizingProduction.Start;
            Pause = dailyOperationSizingProduction.Pause;
            Resume = dailyOperationSizingProduction.Resume;
            Doff = dailyOperationSizingProduction.Doff;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Start;
            yield return Pause;
            yield return Resume;
            yield return Doff;
        }
    }
}