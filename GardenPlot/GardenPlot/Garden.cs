using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenPlot
{
    class Garden
    {
        List<Plot> totalPlots = new List<Plot>();
        List<Tuple<Plot, Plot>> overlappedPlots = new List<Tuple<Plot, Plot>>();
        public Garden()
        {
        }
        public void AddPlot(Plot PlotToAdd)
        {
            totalPlots.Add(PlotToAdd);
        }
        public List<Plot> TotalPlots
        {
            get { return totalPlots; }
        }
        public List<Tuple<Plot, Plot>> OverlappedPlots
        {
            get { return overlappedPlots; }
        }
        public void CheckOverlap()
        {
            foreach(Plot plotToCheck in totalPlots)
            {
                foreach(Plot plotToCompare in totalPlots)
                {
                    if (plotToCheck.PlotID != plotToCompare.PlotID)
                    {
                        if ((plotToCheck.UpperLeft.Item1 > plotToCompare.LowerRight.Item1) ||
                           (plotToCompare.UpperLeft.Item1 > plotToCheck.LowerRight.Item1) ||
                           (plotToCheck.UpperLeft.Item2 > plotToCompare.LowerRight.Item2)||
                           (plotToCompare.UpperLeft.Item2 > plotToCheck.LowerRight.Item2))
                        {
                            //no overlap
                        }  else
                        {
                            Tuple<Plot, Plot> compareOverlap = new Tuple<Plot, Plot>(plotToCompare, plotToCheck);
                            if (!overlappedPlots.Contains(compareOverlap))
                            {
                                Tuple<Plot, Plot> newOverlap = new Tuple<Plot, Plot>(plotToCheck, plotToCompare);
                                overlappedPlots.Add(newOverlap);
                            }
                        }
                        
                    }
                }
            }
        }
        public int FindMaxX()
        {
            int maxX = 0;
            foreach(Plot plot in totalPlots)
            {
                if (plot.UpperRight.Item1 > maxX)
                {
                    maxX = plot.UpperRight.Item1;
                }
            }
            return maxX;
        }
        public int FindMinX()
        {
            int minX = 100000;
            foreach (Plot plot in totalPlots)
            {
                if (plot.UpperLeft.Item1 < minX)
                {
                    minX = plot.UpperLeft.Item1;
                }
            }
            return minX;
        }
        public int FindMinY()
        {
            int minY = 100000;
            foreach (Plot plot in totalPlots)
            {
                if (plot.UpperLeft.Item2 < minY)
                {
                    minY = plot.UpperLeft.Item1;
                }
            }
            return minY;
        }
        public int FindMaxY()
        {
            int maxY = 0;
            foreach (Plot plot in totalPlots)
            {
                if (plot.LowerLeft.Item2 > maxY)
                {
                    maxY = plot.LowerLeft.Item2;
                }
            }
            return maxY;
        }
        public int CalculateMinimumFencing()
        {
            int maxX = FindMaxX();
            int minX = FindMinX();
            int maxY = FindMaxY();
            int minY = FindMinY();
            int gardenWidth = maxX - minX;
            int gardenHeight = maxY - minY;
            int gardenPerimeter = (gardenWidth * 2) + (gardenHeight * 2);
            return gardenPerimeter;
        }
        //public int CalculateOverlappedArea()
        //{
        //    int overlappedWidth = 0;
        //    int overlappedHeight = 0;
        //    int overlappedArea = 0;
        //    foreach (Tuple<Plot,Plot> overlappedPair in overlappedPlots)
        //    {
        //        overlappedWidth = overlappedPair.Item1.UpperRight.Item1 - overlappedPair.Item2.XCoord;
        //        overlappedHeight = overlappedPair.Item1.LowerLeft.Item2 - overlappedPair.Item2.YCoord;
        //        overlappedArea += overlappedWidth * overlappedHeight;
        //    }
        //    return overlappedArea;
        //}
        public int CalculateOverlappedArea()
        {
            int overlappedArea = 0;
            foreach (Tuple<Plot, Plot> overlappedPair in overlappedPlots)
            {
                int leftSide = Math.Max(overlappedPair.Item1.UpperLeft.Item1, overlappedPair.Item2.UpperLeft.Item1);
                int rightSide = Math.Min(overlappedPair.Item1.LowerRight.Item1, overlappedPair.Item2.LowerRight.Item1);
                int bottom = Math.Min(overlappedPair.Item1.LowerRight.Item2, overlappedPair.Item2.LowerRight.Item2);
                int top = Math.Max(overlappedPair.Item1.UpperLeft.Item2, overlappedPair.Item2.UpperLeft.Item2);
                int intersectedArea = (rightSide - leftSide) * (bottom - top);
                overlappedArea += intersectedArea;
            }
            return overlappedArea;
        }
        public int CalculateRawArea()
        {
            int rawArea = 0;
            foreach (Plot plot in totalPlots)
            {
                rawArea += plot.CalculateArea();
            }
            return rawArea;
        }
        public int CalculateRawMinusOverlappedArea()
        {
            int totalArea = CalculateRawArea() - CalculateOverlappedArea();
            return totalArea;
        }
        public double CalculateFertilizerRequired()
        {
            double fertilizerRequired;
            fertilizerRequired = CalculateRawMinusOverlappedArea() / 2;
            return fertilizerRequired;
        }

    }
}
