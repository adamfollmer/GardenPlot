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
        StreamWriter writer = new StreamWriter("C:\\GardenData\\gardenSpace.txt");
        public Output (Garden Garden)
        {
            garden = Garden;
        }

        public void one()
        {
            garden.CheckOverlap();
            foreach(Tuple<Plot,Plot> overLappedSection in garden.OverlappedPlots)
            {
                writer.WriteLine("Plot " + overLappedSection.Item1.PlotID + " overlaps with Plot " + overLappedSection.Item2.PlotID);
            }
            writer.Close();
        }
        public void two()
        {
            foreach (Plot plot in garden.TotalPlots)
            {
                writer.WriteLine("Plot " + plot.PlotID + " requires " + plot.CalculatePerimeter() + " feet of fencing.");
            }
            writer.Close();
        }
        public void three()
        {
            writer.WriteLine("Total amount of fencing for the garden is " + garden.CalculateMinimumFencing() + " feet.");
            writer.Close();
        }
        public void four()
        {

        }
    }
}
