using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldDempProject
{
    public class LoggingService
    {
        public LoggingService()
        { 
            
        }


        /// <summary>
        /// Soll einen Eintrag in die Infos.log anhängen.
        /// </summary>
        /// <param name="toLog">Wird als neue Zeile angehängt.</param>
        public void Log(string toLog)
        {
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];

            var folder = Path.Combine(path, "SageAT");
            Directory.CreateDirectory(folder);

            var logFile = Path.Combine(folder, "Infos.log");
            using (StreamWriter sw = new StreamWriter(logFile, append: true))
            {
                sw.WriteLine(toLog);
            }
        }
    }
}
