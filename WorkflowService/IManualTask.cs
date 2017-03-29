using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowService
{
    [ServiceContract(Namespace = "http://tempuri.org")]
    public interface IManualTask
    {
        [OperationContract]
        void Complete(string taskData);
        [OperationContract(Name = "Complete")]
        Task CompleteAsync(string taskData);
    }
}
