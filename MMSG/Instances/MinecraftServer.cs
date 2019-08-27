using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMSG.Config;

namespace MMSG.Instances
{
    public class MinecraftServer : JavaServer
    {
        public ServerProperties Properties { get; set; }
        public MinecraftServer(string ram, ServerProperties properties, string workingDir, string jarLocation) : base(workingDir)
        {
            Properties = properties;
            StartInfo.Arguments = $"-Xms{ram} -Xmx{ram} -Dcom.mojang.eula.agree=true -jar \"{jarLocation}\"";
           //$"-Xms{ram} -Xmx{ram} -XX:+UseG1GC -XX:+UnlockExperimentalVMOptions -XX:MaxGCPauseMillis=100 -XX:+DisableExplicitGC -XX:TargetSurvivorRatio=90 -XX:G1NewSizePercent=50 -XX:G1MaxNewSizePercent=80 -XX:G1MixedGCLiveThresholdPercent=35 -XX:+AlwaysPreTouch -XX:+ParallelRefProcEnabled -jar {jarLocation}";
        }
    }
}
