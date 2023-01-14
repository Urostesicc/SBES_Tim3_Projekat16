using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SecurityManager;
using Formatter = SecurityManager.Formatter;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name = "chiefOfficer";
            string name = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine(name);

            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/Service";

            //Windows Authentification
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            string str;
            bool exit = false;
        }
            
    }
}
