using System.ServiceModel;

namespace MyHelloWorld
{
    [ServiceContract]
    public interface IAppServer
    {
        [OperationContract]
        string GetStringFromWCF();
    }
}
