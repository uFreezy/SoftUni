namespace BigMani.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using Core;
    using Data;

    public class ReportController : Controller
    {
        public string FindReport(string manufacturer, string model)
        {
            var report = AirConditionerData.GetReport(manufacturer, model);
            throw new InvalidOperationException(report.ToString());
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            var reports = AirConditionerData.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Messages.NoReports;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            var reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            //return reportsPrint.ToString();
            throw new InvalidOperationException(reportsPrint.ToString());
        }
    }
}