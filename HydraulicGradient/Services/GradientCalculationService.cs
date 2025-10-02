using HydraulicGradient.Models;

namespace HydraulicGradient.Services
{
    public class GradientCalculationService
    {
        public GradientResult CalculateGradient(List<DataPoint> dataPoints, bool useHeadSquared = false)
        {
            var validPoints = dataPoints.Where(p => p.IsValid).ToList();
            
            if (validPoints.Count < 3)
            {
                return new GradientResult();
            }

            // Prepare data for least squares fitting
            var n = validPoints.Count;
            var x = validPoints.Select(p => p.X!.Value).ToArray();
            var y = validPoints.Select(p => p.Y!.Value).ToArray();
            var h = validPoints.Select(p => useHeadSquared ? Math.Pow(p.Head!.Value, 2) : p.Head!.Value).ToArray();

            // Calculate least squares coefficients for plane fitting: ax + by + c = h
            var result = FitPlane(x, y, h);
            var a = result.A;
            var b = result.B;
            var c = result.C;
            var r2 = result.R2;

            // Calculate gradient magnitude
            var gradientMagnitude = Math.Sqrt(a * a + b * b);

            // Calculate flow direction (degrees from north/positive y-axis)
            var flowDirection = CalculateFlowDirection(a, b);

            // Calculate max head difference
            var maxHeadDiff = h.Max() - h.Min();

            return new GradientResult
            {
                NumberOfPoints = n,
                MaxHeadDifference = maxHeadDiff,
                GradientMagnitude = gradientMagnitude,
                FlowDirection = flowDirection,
                CoefficientOfDetermination = r2
            };
        }

        private (double A, double B, double C, double R2) FitPlane(double[] x, double[] y, double[] h)
        {
            var n = x.Length;
            
            // Calculate sums for normal equations
            var sumX = x.Sum();
            var sumY = y.Sum();
            var sumH = h.Sum();
            var sumXX = x.Select(xi => xi * xi).Sum();
            var sumYY = y.Select(yi => yi * yi).Sum();
            var sumXY = x.Zip(y, (xi, yi) => xi * yi).Sum();
            var sumXH = x.Zip(h, (xi, hi) => xi * hi).Sum();
            var sumYH = y.Zip(h, (xi, hi) => xi * hi).Sum();

            // Solve normal equations using matrix methods
            // [sumXX  sumXY  sumX ] [a]   [sumXH]
            // [sumXY  sumYY  sumY ] [b] = [sumYH]
            // [sumX   sumY   n    ] [c]   [sumH ]

            var det = sumXX * (sumYY * n - sumY * sumY) - 
                     sumXY * (sumXY * n - sumX * sumY) + 
                     sumX * (sumXY * sumY - sumYY * sumX);

            if (Math.Abs(det) < 1e-12)
            {
                return (0, 0, 0, 0);
            }

            var a = (sumXH * (sumYY * n - sumY * sumY) - 
                    sumYH * (sumXY * n - sumX * sumY) + 
                    sumH * (sumXY * sumY - sumYY * sumX)) / det;

            var b = (sumXX * (sumYH * n - sumH * sumY) - 
                    sumXY * (sumXH * n - sumH * sumX) + 
                    sumX * (sumXH * sumY - sumYH * sumX)) / det;

            var c = (sumXX * (sumYY * sumH - sumY * sumYH) - 
                    sumXY * (sumXY * sumH - sumX * sumYH) + 
                    sumX * (sumXY * sumYH - sumYY * sumXH)) / det;

            // Calculate R²
            var hMean = h.Average();
            var sstot = h.Select(hi => Math.Pow(hi - hMean, 2)).Sum();
            var ssres = x.Zip(y, (xi, yi) => new { xi, yi })
                         .Zip(h, (coord, hi) => Math.Pow(hi - (a * coord.xi + b * coord.yi + c), 2))
                         .Sum();

            var r2 = sstot > 0 ? 1 - (ssres / sstot) : 0;

            return (a, b, c, r2);
        }

        private double CalculateFlowDirection(double a, double b)
        {
            // Flow direction is opposite to gradient direction
            var gradientAngle = Math.Atan2(-a, -b) * 180.0 / Math.PI;
            
            // Convert to degrees from north (positive y-axis)
            var flowDirection = gradientAngle;
            
            // Normalize to 0-360 degrees
            if (flowDirection < 0)
            {
                flowDirection += 360;
            }

            return flowDirection;
        }

        public List<DataPoint> GetExampleDataSet1()
        {
            return new List<DataPoint>
            {
                new DataPoint { Id = "MW-1", X = 100, Y = 200, Head = 150.5 },
                new DataPoint { Id = "MW-2", X = 200, Y = 300, Head = 149.8 },
                new DataPoint { Id = "MW-3", X = 300, Y = 250, Head = 148.2 },
                new DataPoint { Id = "MW-4", X = 150, Y = 150, Head = 151.1 },
                new DataPoint { Id = "MW-5", X = 250, Y = 200, Head = 149.0 }
            };
        }

        public List<DataPoint> GetExampleDataSet2()
        {
            return new List<DataPoint>
            {
                new DataPoint { Id = "PZ-1", X = 0, Y = 0, Head = 100.0 },
                new DataPoint { Id = "PZ-2", X = 100, Y = 0, Head = 99.5 },
                new DataPoint { Id = "PZ-3", X = 200, Y = 0, Head = 99.0 },
                new DataPoint { Id = "PZ-4", X = 0, Y = 100, Head = 99.8 },
                new DataPoint { Id = "PZ-5", X = 100, Y = 100, Head = 99.3 },
                new DataPoint { Id = "PZ-6", X = 200, Y = 100, Head = 98.8 },
                new DataPoint { Id = "PZ-7", X = 0, Y = 200, Head = 99.6 },
                new DataPoint { Id = "PZ-8", X = 100, Y = 200, Head = 99.1 },
                new DataPoint { Id = "PZ-9", X = 200, Y = 200, Head = 98.6 }
            };
        }
    }
}