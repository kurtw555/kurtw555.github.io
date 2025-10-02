namespace HydraulicGradient.Models
{
    public class GradientResult
    {
        public int NumberOfPoints { get; set; }
        public double MaxHeadDifference { get; set; }
        public double GradientMagnitude { get; set; }
        public double FlowDirection { get; set; }
        public double CoefficientOfDetermination { get; set; }
    }
}