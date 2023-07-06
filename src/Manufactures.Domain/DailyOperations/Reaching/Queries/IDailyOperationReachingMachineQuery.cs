﻿using Infrastructure.Domain.Queries;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manufactures.Domain.DailyOperations.Reaching.Queries
{
    public interface IDailyOperationReachingMachineQuery<TModel> : IQueries<TModel>
    {
        Task<bool> Upload(ExcelWorksheets sheet, string month, int year, int monthId);
        Task<List<TModel>> GetByMonthYear(int monthId, string year);
        List<TModel> GetDailyReports(DateTime fromDate, DateTime toDate, string shift, string mcNo);
    }
}
