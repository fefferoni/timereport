using System;
using System.Collections.Generic;
using System.Text;

namespace TimeReport.Service
{
    public interface ITimeReportService
    {
        IEnumerable<Data.Entities.TimeReport> GetTimeReports();
        Data.Entities.TimeReport GetTimeReport(int id);
        void InsertTimeReport(Data.Entities.TimeReport task);
        void UpdateTimeReport(Data.Entities.TimeReport task);
        void DeleteTimeReport(int id);
    }
}
