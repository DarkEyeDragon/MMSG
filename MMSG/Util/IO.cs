using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Util
{
    public static class IO
    {
        /// <summary>
        /// Copy the original jar to the server directory to launch
        /// </summary>
        /// <param name="jarLocation">The absolute path of the jar you want to copy from</param>
        /// <param name="directory">The output directory where the jar is copied to</param>
        public static void CopyJarToDir(string jarLocation, string directory)
        {
            try
            {
                if(!File.Exists(Path.Combine(directory, "server.jar")))
                    File.Copy(jarLocation, Path.Combine(directory, "server.jar"));
            }
            catch (IOException e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
