﻿using SharedTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldDempProject
{
    public class LoggingService : ILoggingService, ILoggingServiceInit
    {
        #region private Fields
        private int _currentRowIndex = -1;
        public string logFile;
        #endregion

        #region ILoggingService

        /// <summary>
        /// Soll einen Eintrag in die Infos.log anhängen.
        /// </summary>
        /// <param name="toLog">Wird als neue Zeile angehängt.</param>
        public void Log(string toLog)
        {
            //var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];

            //var folder = Path.Combine(path, "SageAT");
            //Directory.CreateDirectory(folder);
            //var logFile = Path.Combine(folder, "Infos.log");
            using (StreamWriter sw = new StreamWriter(logFile, append: true))
            {
                var line = toLog.Replace("_", "");
                _currentRowIndex++;
                sw.WriteLine($"{_currentRowIndex} | {toLog}");
            }
        }

        public void Log(LogLineModel toLog)
        {
            //string logMessageZeile = string.Empty;


            //using (StreamWriter sw = new StreamWriter(logFile, append: true))
            //{
            //    var line = logMessageZeile.Replace("_", "");
            //    _currentRowIndex++;
            //    logMessageZeile = $"{_currentRowIndex} | {toLog.LoggingTime.ToString() } | { toLog.Message}";
            //    sw.WriteLine(logMessageZeile);
            //}

            using (StreamWriter sw = new StreamWriter(logFile, append: true))
            {
                _currentRowIndex++;
                var line = _Mapper(toLog);
                sw.WriteLine(line);
            }
        }

        public void DeleteLine(int rowIndex)
        {

            using (var sr = new StreamReader(logFile))
            {
                var list = new List<string>();
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
                sr.Close();

                for (int i = 0; i < list.Count; i++)
                {
                    var istLineToDelete = list[i].StartsWith(rowIndex.ToString());
                    if (istLineToDelete)
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }
                //TODO list in Datei zurückschreiben
                using (var sw = new StreamWriter(logFile))
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                         sw.WriteLine(list[i]);
                    }
                }
            }

        }


        #endregion

        #region ILoggingServiceInit
        public void Init()
        {
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "SageAT");
            Directory.CreateDirectory(folder);
            logFile = Path.Combine(folder, "Infos.log");
        }
        #endregion

        #region private Methods

        private StringBuilder _Mapper(LogLineModel logLineModel)
        {
            var sb = new StringBuilder();
            sb.Append(logLineModel.RowIndex);
            sb.Append(" | ");
            sb.Append(logLineModel.LoggingTime);
            sb.Append(" | ");
            sb.Append(logLineModel.Message);

            return sb;
        }

        #endregion private Methods

        public LoggingService()
        {

        }

        public void DeleteLog()
        {
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];

            var folder = Path.Combine(path, "SageAT");
            Directory.CreateDirectory(folder);

            var logFile = Path.Combine(folder, "Infos.log");

            using (var sr = new StreamReader(logFile))
            {
                var logContent = sr.ReadToEnd();
                string[] logZeilen = logContent.Split('\n');
                int i = logZeilen.Count();
                
                for(int j=0;j<i; j++)
                {
                    var logFile2 = Path.Combine(folder, "Infos1.log");
                    using (StreamWriter sw2 = new StreamWriter(logFile2, append: true))
                    {
                        sw2.WriteLine(logZeilen[j]);
                    }
                }
                if (File.Exists(logFile))
                    File.Delete(logFile);
                //File.Replace(logFile, logFile2, logFile2);
            }

            

        }
        
    }
}
