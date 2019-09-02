using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MMSG.Config;
using MMSG.Util;

namespace MMSG.Instances
{
    public class InstanceHandler
    {
        public List<JavaServer> Instances { get; set; }
        public string JarLocation { get; set; }

        public InstanceHandler()
        {
            Instances = new List<JavaServer>();
        }

        public InstanceHandler(string jarLocation) : this()
        {
            JarLocation = jarLocation;
        }

        /// <summary>
        /// Create a MinecraftServer and add it to Instances
        /// </summary>
        /// <param name="startingPort">The starting port. Incremented for each server created</param>
        /// <param name="amount">Amount of instances to create</param>
        /// <param name="ram">RAM for each server</param>
        /// <param name="world">The world name</param>
        /// <param name="baseDir">The base/root directory of the application</param>
        /// <param name="seed">The world seed</param>
        public void Create(int startingPort, byte amount, string ram, string world, string baseDir, string seed)
        {
            for (byte i = 0; i < amount; i++)
            {
                //Create server.properties based on settings
                var pregenServerDir = Path.Combine(baseDir, "pregenServer-" + i);
                var fullPath = Path.Combine(baseDir, pregenServerDir);
                var properties = new ServerProperties(fullPath,startingPort + i, world, seed);
                Directory.CreateDirectory(fullPath);
                //Get the list and take the first file.
                var files = Directory.GetFiles(Path.Combine(baseDir, "cache"), "patched_*.jar");


                var minecraftServer = new MinecraftServer(ram, properties, fullPath, files[0]);
                Instances.Add(minecraftServer);
                minecraftServer.Properties.Save();
            }

            IO.CopyJarToDir(JarLocation, baseDir);
        }

        /// <summary>
        /// Create a PatchServer
        /// </summary>
        /// <param name="ram">RAM</param>
        /// <param name="workingDir">The base/root directory of the application</param>
        /// <returns>The PatchServer instance</returns>
        public PatchServer CreatePatchServer(string ram, string workingDir)
        {
            var patchServer = new PatchServer(ram, workingDir, JarLocation);
            Instances.Add(patchServer);
            return patchServer;
        }

        /// <summary>
        /// Run all instances in Instances
        /// </summary>
        public void RunAll()
        {
            foreach (var javaServer in Instances)
            {
                javaServer.Start();
            }
        }

        /// <summary>
        /// Stop all instances in Instances
        /// </summary>
        public void StopAll()
        {
            foreach (var javaServer in Instances)
            {
                javaServer.StandardInput.WriteLine("stop");
            }
        }

        
    }
}