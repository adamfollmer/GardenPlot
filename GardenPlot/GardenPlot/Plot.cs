using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenPlot
{
    class Plot
    {
        int xCoord;
        int yCoord;
        int width;
        int height;
        Tuple<int, int> upperLeft;
        Tuple<int, int> upperRight;
        Tuple<int, int> lowerLeft;
        Tuple<int, int> lowerRight;
        int plotID;

        public Plot(int XCoord, int YCoord, int Width, int Height, int PlotID)
        {
            xCoord = XCoord;
            yCoord = YCoord;
            width = Width;
            height = Height;
            upperLeft = new Tuple<int, int>(xCoord, yCoord);
            upperRight = new Tuple<int, int>((xCoord + width), yCoord);
            lowerLeft = new Tuple<int, int>(xCoord, (yCoord + height));
            lowerRight = new Tuple<int, int>((xCoord + width), (yCoord + height));
            plotID = PlotID;
        }
        public int XCoord
        {
            get { return xCoord; }
        }
        public int YCoord
        {
            get { return yCoord; }
        }
        public Tuple<int, int> UpperLeft
        {
            get { return upperLeft; }
        }
        public Tuple<int, int> UpperRight
        {
            get { return upperRight; }
        }
        public Tuple<int, int> LowerLeft
        {
            get { return lowerLeft; }
        }
        public Tuple<int, int> LowerRight
        {
            get { return lowerRight; }
        }
        public int PlotID
        {
            get { return plotID; }
        }
        public int CalculatePerimeter()
        {
            int perimeter = (width * 2) + (height * 2);
            return perimeter;
        }
        public int CalculateArea()
        {
            int area = width * height;
            return area;
        }
        public void Rotate90()
        {
            Tuple<int, int> holdForRotation = upperLeft;
            upperLeft = lowerLeft;
            lowerLeft = lowerRight;
            lowerRight = upperRight;
            upperRight = holdForRotation;
        }
        public void Rotate180()
        {
            Tuple<int, int> holdUL = upperLeft;
            Tuple<int, int> holdLL = lowerLeft;
            upperLeft = lowerRight;
            lowerLeft = upperRight;
            upperRight = holdLL;
            lowerRight = holdUL;
        }
        public void Rotate270()
        {
            Tuple<int, int> holdForRotation = upperLeft;
            upperLeft = upperRight;
            upperRight = lowerRight;
            lowerRight = lowerLeft;
            lowerLeft = holdForRotation;
        }

    }
}
