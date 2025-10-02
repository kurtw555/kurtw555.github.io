namespace HydraulicGradient.Models
{
    public class DataPoint
    {
        public string Id { get; set; } = string.Empty;
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Head { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Id) && X.HasValue && Y.HasValue && Head.HasValue;
    }
}