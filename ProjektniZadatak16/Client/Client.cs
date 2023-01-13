using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client : ChannelFactory<IClientCommunication>, IClientCommunication
    {
        IClientCommunication factory;

        public Client(NetTcpBinding binding, EndpointAddress address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public void Connect()
        {
            try
            {
                factory.Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                factory.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void CreateConfigurationFile()
        {
            try
            {
                factory.CreateConfigurationFile();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DeleteConfigurationFile()
        {
            try
            {
                factory.DeleteConfigurationFile();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void AddEntry(ConfigurationEntry entry)
        {
            try
            {
                factory.AddEntry(entry);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void ModifyEntry(ConfigurationEntry entry)
        {
            try
            {
                factory.ModifyEntry(entry);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DeleteEntry(int id)
        {
            try
            {
                factory.DeleteEntry(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public List<ConfigurationEntry> ReadConfigurationFile()
        {
            List<ConfigurationEntry> entryList = null;
            try
            {
                entryList = factory.ReadConfigurationFile();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return entryList;
        }
    }
}
