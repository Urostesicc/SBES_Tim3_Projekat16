using CertificateManager;
using Contracts;
using SecurityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace IntrusionDetectionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            name = name.ToLower();
            Console.WriteLine(name);

            NetTcpBinding bindingIDS = new NetTcpBinding();

            bindingIDS.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            string addressIDS = "net.tcp://localhost:9998/IDS";
            ServiceHost host = new ServiceHost(typeof(IntrusionDetectionSystem));
            host.AddServiceEndpoint(typeof(IIntrusionDetectionSystem), bindingIDS, addressIDS);

            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;
            host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            host.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, name);

            try
            {
                host.Open();
                Console.WriteLine("Intrusion Detection System started.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] {0}", e.Message);
                Console.WriteLine("[StackTrace] {0}", e.StackTrace);
            }
            finally
            {
                host.Close();
            }
        }
    }
}
