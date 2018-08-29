namespace BigMani.Controllers
{
    using System;
    using Core;
    using Data;
    using Models;

    public class AirConditionerController
    {
        public string RegisterStationaryAirConditioner(string manufacturer, string model, char energyEfficiencyRating,
            int powerUsage)
        {
            var airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            AirConditionerData.AirConditioners.Add(airConditioner);

            return string.Format(
                Messages.Register,
                airConditioner.Model,
                airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            var airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            AirConditionerData.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(Messages.Register, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string RegisterPlaneAirConditioner(
            string manufacturer,
            string model,
            int volumeCoverage,
            string electricityUsed)
        {
            var airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, int.Parse(electricityUsed));
            AirConditionerData.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(Messages.Register, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            var airConditioner = AirConditionerData.GetAirConditioner(manufacturer, model);
            // airConditioner.energyRating += 5;
            var mark = airConditioner.Test();
            AirConditionerData.Reports.Add(new Reprot(airConditioner.Manufacturer, airConditioner.Model, mark));
            throw new InvalidOperationException(string.Format(Messages.Test, model, manufacturer));
        }

        public string FindAirConditioner(string manufacturer, string model)
        {
            var airConditioner = AirConditionerData.GetAirConditioner(manufacturer, model);
            throw new InvalidOperationException(airConditioner.ToString());
        }
    }
}