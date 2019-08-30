using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMSG.Instances;

namespace MMSG.Command
{
    public abstract class Command : ICommand
    {
        public Process Process { get; set; }

        public Command(Process process)
        {
            Process = process;
        }

        public void Send(string command)
        {
            Process.StandardInput.WriteLine(command);
        }
    }
}
