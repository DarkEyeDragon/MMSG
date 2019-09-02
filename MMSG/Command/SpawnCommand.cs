using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MMSG.Util;

namespace MMSG.Command
{
    class SpawnCommand : Command
    {
        public SpawnCommand(Process process) : base(process)
        {
            
        }

        /*public Point3 GetSpawn(string world)
        {
            base.Send($"mmsg getspawn {world}");
        }*/
    }
}
