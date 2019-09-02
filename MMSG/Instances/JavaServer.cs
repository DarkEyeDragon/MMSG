using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Instances
{
    public abstract class JavaServer : Process
    {

        public OutputHandler OutputHandler { get; set; }

        protected JavaServer(string workingDir)
        {
            StartInfo.FileName = "java";
            StartInfo.UseShellExecute = false;
            StartInfo.WorkingDirectory = workingDir;
            StartInfo.CreateNoWindow = false;
            StartInfo.ErrorDialog = true;
            StartInfo.RedirectStandardOutput = true;
            EnableRaisingEvents = true;
            OutputHandler = new OutputHandler(this);
        }

        protected JavaServer(string ram, string workingDir, string jarLocation) : this(workingDir)
        {
            StartInfo.Arguments = $"-Xms{ram} -Xmx{ram} -jar \"{jarLocation}\"";
        }

        public new bool Start()
        {
            bool state = base.Start();
            if (state)
            {
                BeginOutputReadLine();
            }
            return state;
        }
    }
}