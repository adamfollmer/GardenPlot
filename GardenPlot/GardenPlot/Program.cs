using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenPlot
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulatedTestGarden run = new PopulatedTestGarden();
            run.PopulateTestGarden();
            Output output = new Output(run.testGarden);
            //output.one(); WORKING
            //output.two(); WORKING
            //output.three(); WORKING
            output.four();
        }
    }
}
