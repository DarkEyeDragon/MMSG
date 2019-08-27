using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Config
{
    public class ServerProperties
    {
        public string BaseDir { get; set; }

        public string Properties { get;}

        public ServerProperties(string baseDir, int port, string world, string seed)
        {
            BaseDir = baseDir;

            Properties =
                "spawn-protection=16" + Environment.NewLine +
                "max-tick-time=60000" + Environment.NewLine +
                "query.port=25565" + Environment.NewLine +
                "generator-settings=" + Environment.NewLine +
                "force-gamemode=false" + Environment.NewLine +
                "allow-nether=false" + Environment.NewLine +
                "enforce-whitelist=true" + Environment.NewLine +
                "gamemode=survival" + Environment.NewLine +
                "broadcast-console-to-ops=true" + Environment.NewLine +
                "enable-query=false" + Environment.NewLine +
                "player-idle-timeout=0" + Environment.NewLine +
                "difficulty=peaceful" + Environment.NewLine +
                "spawn-monsters=true" + Environment.NewLine +
                "broadcast-rcon-to-ops=true" + Environment.NewLine +
                "op-permission-level=4" + Environment.NewLine +
                "pvp=true" + Environment.NewLine +
                "snooper-enabled=true" + Environment.NewLine +
                "level-type=default" + Environment.NewLine +
                "hardcore=false" + Environment.NewLine +
                "enable-command-block=false" + Environment.NewLine +
                "max-players=20" + Environment.NewLine +
                "network-compression-threshold=256" + Environment.NewLine +
                "resource-pack-sha1=" + Environment.NewLine +
                "max-world-size=29999984" + Environment.NewLine +
                "function -permission-level=2" + Environment.NewLine +
                "rcon.port=25575" + Environment.NewLine +
                $"server-port={port}" + Environment.NewLine +
                "debug=false" + Environment.NewLine +
                "server-ip=" + Environment.NewLine +
                "spawn-npcs=true" + Environment.NewLine +
                "allow-flight=false" + Environment.NewLine +
                $"level-name={world}" + Environment.NewLine +
                "view-distance=10" + Environment.NewLine +
                "resource-pack=" + Environment.NewLine +
                "spawn-animals=false" + Environment.NewLine +
                "white-list=true" + Environment.NewLine +
                "rcon.password=" + Environment.NewLine +
                "generate-structures=true" + Environment.NewLine +
                "online-mode=true" + Environment.NewLine +
                "max-build-height=256" + Environment.NewLine +
                $"level-seed={seed}" + Environment.NewLine +
                "prevent-proxy-connections=false" + Environment.NewLine +
                "use-native-transport=true" + Environment.NewLine +
                "motd=PREGEN SERVER - DO NOT JOIN" + Environment.NewLine +
                "enable-rcon=false";
        }

        public void Save()
        {
            File.WriteAllText(Path.Combine(BaseDir, "server.properties"), Properties);
        }
    }
}