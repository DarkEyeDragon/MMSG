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
        protected JavaServer(string workingDir)
        {
            StartInfo.FileName = "java";
            StartInfo.UseShellExecute = true;
            StartInfo.WorkingDirectory = workingDir;
            StartInfo.CreateNoWindow = false;
            StartInfo.ErrorDialog = true;
            EnableRaisingEvents = true;
        }

        protected JavaServer(string ram, string workingDir, string jarLocation) : this(workingDir)
        {
            StartInfo.Arguments = $"-Xms{ram} -Xmx{ram} -jar \"{jarLocation}\"";
        }
    }
}