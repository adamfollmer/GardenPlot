using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenPlot
{
    class PopulatedTestGarden
    {
        public Garden testGarden = new Garden();
        public Plot plotOne = new Plot(1, 1, 4, 4, 1);
        public Plot plotTwo = new Plot(20, 20, 1, 1, 2);
        public Plot plotThree = new Plot(2, 2, 4, 4, 3);

        public void RunProgram()
        {
            PopulateTestGarden();
        }
        public void PopulateTestGarden()
        {
            testGarden.AddPlot(plotOne);
            testGarden.AddPlot(plotTwo);
            testGarden.AddPlot(plotThree);
        }
    }
}
