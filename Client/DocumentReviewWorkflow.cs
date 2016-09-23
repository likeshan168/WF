﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ITicket")]
public interface ITicket
{
    
    // CODEGEN: 操作 CreateTicket 以后生成的消息协定不是 RPC，也不是换行文档。
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicket/CreateTicket", ReplyAction="http://tempuri.org/ITicket/CreateTicketResponse")]
    CreateTicketResponse CreateTicket(CreateTicketRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicket/CreateTicket", ReplyAction="http://tempuri.org/ITicket/CreateTicketResponse")]
    System.Threading.Tasks.Task<CreateTicketResponse> CreateTicketAsync(CreateTicketRequest request);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITicket/UpdateTicket")]
    void UpdateTicket(string action, string comment, int reviewID);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITicket/UpdateTicket")]
    System.Threading.Tasks.Task UpdateTicketAsync(string action, string comment, int reviewID);
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateTicketRequest
{
    
    public CreateTicketRequest()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class CreateTicketResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/", Order=0)]
    public System.Nullable<int> @int;
    
    public CreateTicketResponse()
    {
    }
    
    public CreateTicketResponse(System.Nullable<int> @int)
    {
        this.@int = @int;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ITicketChannel : ITicket, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class TicketClient : System.ServiceModel.ClientBase<ITicket>, ITicket
{
    
    public TicketClient()
    {
    }
    
    public TicketClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public TicketClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public TicketClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public TicketClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    CreateTicketResponse ITicket.CreateTicket(CreateTicketRequest request)
    {
        return base.Channel.CreateTicket(request);
    }
    
    public System.Nullable<int> CreateTicket()
    {
        CreateTicketRequest inValue = new CreateTicketRequest();
        CreateTicketResponse retVal = ((ITicket)(this)).CreateTicket(inValue);
        return retVal.@int;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    System.Threading.Tasks.Task<CreateTicketResponse> ITicket.CreateTicketAsync(CreateTicketRequest request)
    {
        return base.Channel.CreateTicketAsync(request);
    }
    
    public System.Threading.Tasks.Task<CreateTicketResponse> CreateTicketAsync()
    {
        CreateTicketRequest inValue = new CreateTicketRequest();
        return ((ITicket)(this)).CreateTicketAsync(inValue);
    }
    
    public void UpdateTicket(string action, string comment, int reviewID)
    {
        base.Channel.UpdateTicket(action, comment, reviewID);
    }
    
    public System.Threading.Tasks.Task UpdateTicketAsync(string action, string comment, int reviewID)
    {
        return base.Channel.UpdateTicketAsync(action, comment, reviewID);
    }
}