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
            string functionToRun = args[0];
            string inputFilePath = args[1];
            string outputFilePath = args[2];
            Input input = new Input(inputFilePath);
            input.AssignStringToPlots(input.TakeInput());
            Output output = new Output(input.garden, outputFilePath);
            output.RunSelectedFunction(functionToRun);
        }
    }
}
