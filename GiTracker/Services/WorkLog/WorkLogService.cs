﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.WorkLog
{
    internal class WorkLogService : IWorkLogService
    {
        public Task LogTimeAsync(int issueId, DateTime logDate, TimeSpan logTime, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}