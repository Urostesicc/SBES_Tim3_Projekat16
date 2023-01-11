using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [Serializable]
    public class ConfigurationEntry
    {
        private int id;
        private string processName;
        private List<string> users;

        public ConfigurationEntry()
        {
        }

        public ConfigurationEntry(int id, string processName, List<string> users)
        {
            this.id = id;
            this.processName = processName;
            this.users = users;
        }

        public int Id { get => id; set => id = value; }
        public string ProcessName { get => processName; set => processName = value; }
        public List<string> Users { get => users; set => users = value; }

        public override bool Equals(object obj)
        {
            var entry = obj as ConfigurationEntry;
            return entry != null &&
                   Id == entry.Id &&
                   ProcessName == entry.ProcessName &&
                   EqualityComparer<List<string>>.Default.Equals(Users, entry.Users);
        }

        public override int GetHashCode()
        {
            var hashCode = -963973220;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProcessName);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Users);
            return hashCode;
        }
    }
}
