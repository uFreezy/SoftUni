namespace BigMani.Models
{
    public class Reprot
    {
        public Reprot(string manufacturer, string model, bool mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public bool Mark { get; set; }

        //BUG: the result from the report was kept in the overall report var.
        public override string ToString()
        {
            var reportResult = string.Empty;
            if (!this.Mark)
            {
                reportResult = "Failed";
            }
            else if (this.Mark)
            {
                reportResult = "Passed";
            }

            var result = "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + this.Manufacturer +
                         "\r\n" +
                         "Model: " + this.Model + "\r\n" + "Mark: " + reportResult + "\r\n" + "====================";

            return result;
        }
    }
}