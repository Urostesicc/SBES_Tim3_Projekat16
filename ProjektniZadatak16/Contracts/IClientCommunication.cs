using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IClientCommunication
    {
        [OperationContract]
        void Connect();
        [OperationContract]
        void Disconnect();
        [OperationContract]
        void CreateConfigurationFile();
        [OperationContract]
        void DeleteConfigurationFile();
        [OperationContract]
        void AddEntry(ConfigurationEntry entry);
        [OperationContract]
        void ModifyEntry(ConfigurationEntry entry);
        [OperationContract]
        void DeleteEntry(int id);
        [OperationContract]
        List<ConfigurationEntry> ReadConfigurationFile();
    }
}
