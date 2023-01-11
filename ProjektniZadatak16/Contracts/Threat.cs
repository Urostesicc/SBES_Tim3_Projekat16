using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Threat
    {
        Process process;
        int timesDetected;

        public Threat()
        {
        }

        public Threat(Process process, int timesDetected)
        {
            this.process = process;
            this.timesDetected = timesDetected;
        }

        public Process Process { get => process; set => process = value; }
        public int TimesDetected { get => timesDetected; set => timesDetected = value; }

        public override bool Equals(object obj)
        {
            var threat = obj as Threat;
            return threat != null &&
                   EqualityComparer<Process>.Default.Equals(Process, threat.Process) &&
                   TimesDetected == threat.TimesDetected;
        }

        public override int GetHashCode()
        {
            var hashCode = -910020611;
            hashCode = hashCode * -1521134295 + EqualityComparer<Process>.Default.GetHashCode(Process);
            hashCode = hashCode * -1521134295 + TimesDetected.GetHashCode();
            return hashCode;
        }
    }
}
