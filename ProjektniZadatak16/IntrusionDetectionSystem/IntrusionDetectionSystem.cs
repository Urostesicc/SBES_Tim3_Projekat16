using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrusionDetectionSystem
{
    public class IntrusionDetectionSystem : IIntrusionDetectionSystem
    {
        public void UpdateIDS(Alarm alarm)
        {
            Console.WriteLine(alarm.ProcessName);
            Console.WriteLine(alarm.CriticalityLevel);
            Console.WriteLine(alarm.Timestamp);
            Console.WriteLine();
        }
    }
}
