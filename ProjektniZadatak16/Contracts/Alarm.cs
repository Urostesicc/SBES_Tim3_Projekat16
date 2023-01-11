using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public enum AlarmCriticality
    {
        Information = 0,
        Warning = 1,
        Critical = 2
    }

    [Serializable]
    public class Alarm
    {
        int id;
        string processName;
        AlarmCriticality criticalityLevel;
        DateTime timestamp;

        public Alarm()
        {
        }

        public Alarm(int id, string processName, AlarmCriticality criticalityLevel, DateTime timestamp)
        {
            this.id = id;
            this.processName = processName;
            this.criticalityLevel = criticalityLevel;
            this.timestamp = timestamp;
        }

        public int Id { get => id; set => id = value; }
        public string ProcessName { get => processName; set => processName = value; }
        public AlarmCriticality CriticalityLevel { get => criticalityLevel; set => criticalityLevel = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }

        public override bool Equals(object obj)
        {
            var alarm = obj as Alarm;
            return alarm != null &&
                   id == alarm.id &&
                   processName == alarm.processName &&
                   criticalityLevel == alarm.criticalityLevel &&
                   timestamp == alarm.timestamp;
        }

        public override int GetHashCode()
        {
            var hashCode = -1000034898;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(processName);
            hashCode = hashCode * -1521134295 + criticalityLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + timestamp.GetHashCode();
            return hashCode;
        }
    }
}
