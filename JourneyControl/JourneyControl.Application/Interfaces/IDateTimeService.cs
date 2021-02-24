using System;
using System.Collections.Generic;
using System.Text;

namespace JourneyControl.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
