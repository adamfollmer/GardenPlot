using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GardenPlot
{
    class Input
    {
        StreamReader reader;
        public Garden garden = new Garden();
        public Input(string path)
        {
            reader = new StreamReader(path);
        }
        public List<string> TakeInput()
        {
            List<string> listOfPlots = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                listOfPlots.Add(line);
            }
            reader.Close();
            return listOfPlots;
        }
        public void AssignStringToPlots (List<string> plots)
        {
            foreach (string futurePlot in plots)
            {
                string[] plotArray = futurePlot.Split(',');
                int[] intPlotArray = Array.ConvertAll(plotArray, int.Parse);
                Plot plot =
                    new Plot
                    (
                        intPlotArray[0],
                        intPlotArray[1],
                        intPlotArray[2],
                        intPlotArray[3],
                        intPlotArray[4]
                    );
                garden.AddPlot(plot);
            }
        }
         
    }
}
