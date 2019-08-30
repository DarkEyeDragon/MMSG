using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Command
{
    class WorldBorderCommand : Command
    {
        public string World { get; set; }
        public int Radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public WorldBorderCommand(Process process) : base(process)
        {
        }

        public WorldBorderCommand(Process process, string world, int radius, int x, int y) : this(process)
        {
            World = world;
            Radius = radius;
            X = x;
            Y = y;
        }

        public virtual void Send()
        {
            Send($"wb {World} set {Radius} {X} {Y}");
        }
    }
}