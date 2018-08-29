namespace BigMani.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class AirConditionerData
    {
        static AirConditionerData()
        {
            // Potential Bottleneck => Use hashset instead.
            AirConditioners = new List<AirConditioner>();
            Reports = new List<Reprot>();
        }

        internal static List<AirConditioner> AirConditioners { get; set; }

        public static List<Reprot> Reports { get; set; }


        public static void AddReport(Reprot report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Reprot report)
        {
            Reports.Remove(report);
        }

        public static Reprot GetReport(string manufacturer, string model)
        {
            return Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Reprot> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }

        internal static void AddAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Add(airConditioner);
        }

        internal static void RemoveAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        internal static AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return AirConditioners.First(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        internal static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }
    }
}