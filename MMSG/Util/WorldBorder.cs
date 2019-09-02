using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MMSG.Command;

namespace MMSG.Util
{
    class WorldBorder
    {

        public Process Process { get; set; }
        public string World { get; set; }
        public int Radius { get; set; }

        public WorldBorder(Process process, string world, int radius, Point p1, Point p2)
        {
            Process = process;
            World = world;
            Radius = radius;
        }

        /// <summary>
        /// Initialize the commands on the JavaServer
        /// </summary>
        public void Init()
        {
            var wb = new WorldBorderCommand(Process) {Radius = Radius, World = World};


            /*var sqrt = Math.Sqrt(count);
            var width = canWidth / sqrt;
            for (var i = 0; i < sqrt; i++)
            {
                for (var j = 0; j < sqrt; j++)
                {
                    double x = centerX / sqrt * i * 2;
                    double y = centerY / sqrt * j * 2;


                    Square.Draw(Canvas, (int)Math.Round(x), (int)Math.Round(y), (int)(Math.Round(x) + width),
                        (int)Math.Round(y + width));
                }
            }*/

            wb.Send();
        }
    }
}
