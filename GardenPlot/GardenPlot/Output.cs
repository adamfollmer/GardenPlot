using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    class Output
    {
        Garden garden;
        StreamWriter writer;
        public Output (Garden garden, String outputFilePath)
        {
            this.garden = garden;
            writer = new StreamWriter(outputFilePath);
        }
        public void RunSelectedFunction(string outputFunction)
        {
            switch (outputFunction) {
                case "1":
                    One();
                    break;
                case "2":
                    Two();
                    break;
                case "3":
                    Three();
                    break;
                case "4":
                    Four();
                    break;
                case "5":
                    Five();
                    break;
                default:
                    break;
            }
        }
        public void One()
        {
            garden.CheckOverlap();
            foreach(Tuple<Plot,Plot> overLappedSection in garden.OverlappedPlots)
            {
                writer.WriteLine("Plot " + overLappedSection.Item1.PlotID + " overlaps with Plot " + overLappedSection.Item2.PlotID);
            }
            writer.Close();
        }
        public void Two()
        {
            foreach (Plot plot in garden.TotalPlots)
            {
                writer.WriteLine("Plot " + plot.PlotID + " requires " + plot.CalculatePerimeter() + " feet of fencing.");
            }
            writer.Close();
        }
        public void Three()
        {
            writer.WriteLine("Total amount of fencing for the garden is " + garden.CalculateMinimumFencing() + " feet.");
            writer.Close();
        }
        public void Four()
        {
            garden.CheckOverlap();
            writer.WriteLine("Total amount of fertilizer required is " + garden.CalculateFertilizerRequired() + " bottles.");
            writer.Close();
        }
        public void Five()
        {
            foreach(Plot plot in garden.TotalPlots)
            {
                writer.WriteLine("Rotating plot " + plot.PlotID + " by 90 degrees");
                writer.WriteLine("Upper left coordinates: " + plot.UpperLeft);
                writer.WriteLine("Lower left coordinates: " + plot.LowerLeft);
                writer.WriteLine("Lower right coordinates: " + plot.LowerRight);
                writer.WriteLine("Upper right coordinates: " + plot.UpperRight);
            }
            writer.Close();
        }
    }
}
