using Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditManager
{
    public class Audit
    {
        private static EventLog customLog = null;
        const string SourceName = "MST.Audit";
        const string LogName = "MalwareScanningTool";

        static Audit()
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }
                customLog = new EventLog(LogName,
                    Environment.MachineName, SourceName);
            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }
        }
        
        public static void ThreatDetected(string processName, AlarmCriticality criticality, DateTime timestamp)
        {
            if (customLog != null)
            {
                string ThreatDetected = AuditEvents.ThreatDetected;
                string message = String.Format(ThreatDetected, processName, criticality, timestamp);
                if(criticality == AlarmCriticality.Information)
                    customLog.WriteEntry(message, EventLogEntryType.Information);
                else if(criticality == AlarmCriticality.Warning)
                    customLog.WriteEntry(message, EventLogEntryType.Warning);
                else if (criticality == AlarmCriticality.Critical)
                    customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.ThreatDetected));
            }
        }
        
    }
}
