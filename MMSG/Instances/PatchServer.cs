using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMSG.Config;

namespace MMSG.Instances
{
    public class PatchServer : JavaServer
    {
        public PatchServer(string ram, string workingDir, string jarLocation) : base(ram, workingDir, jarLocation)
        {   
            StartInfo.Arguments = $"-Xms{ram} -Xmx{ram} -Dpaperclip.patchonly=true -jar \"{jarLocation}\"";
        }
    }
}
