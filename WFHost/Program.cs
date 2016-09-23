using System;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Activities.Description;
using System.ServiceModel.Description;
using System.Xml.Linq;
using DocumentReviewLib;

namespace WFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            #region code host
            //var host = new WorkflowServiceHost(new DocumentReviewWorkflow(), new Uri("http://localhost:8080/DRS"));
            //host.AddDefaultEndpoints();
            //host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
            //host.AddServiceEndpoint("IMetadataExchange", MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            //var store = new SqlWorkflowInstanceStore("server=.;database=test;uid=sa;pwd=sa;");
            //host.DurableInstancingOptions.InstanceStore = store;

            //host.UnknownMessageReceived += (o, e) =>
            //{
            //    Console.WriteLine("\n" + e.Message + "\n");
            //};

            //host.Description.Behaviors.Add(new WorkflowIdleBehavior()
            //{
            //    TimeToPersist = TimeSpan.FromSeconds(0)
            //});
            //XNamespace xns = XNamespace.Get("http://sherman.com/DocumentReview");
            //store.Promote("DocumentReview", new List<XName> { xns.GetName("TicketID") }, null);

            //host.WorkflowExtensions.Add(new Extensions.MyInstanceStoreParticpant());

            //host.Open();


            //var common = new ServiceHost(typeof(CommonService), new Uri("http://localhost:8080/Common"));
            //common.AddServiceEndpoint(typeof(ICommonService).FullName, new BasicHttpBinding(), "");
            //common.Open();

            //Console.WriteLine("Server is ready.");
            //Console.Read(); 
            #endregion

            #region by using config files

            var host = new WorkflowServiceHost(new WorkflowService()
            {
                ConfigurationName = "DocumentReviewLib.DocumentReviewWorkflow",
                Body=new DocumentReviewWorkflow()
            });

            XNamespace xNS = XNamespace.Get("http://sherman.com/DocumentReview");
            var store = (SqlWorkflowInstanceStoreBehavior)host.Description.Behaviors.FirstOrDefault(b => b.GetType() == typeof(SqlWorkflowInstanceStoreBehavior));

            store.Promote("DocumentReview", new List<XName> { xNS.GetName("TicketID") }, null);
            host.WorkflowExtensions.Add(new Extensions.MyInstanceStoreParticpant());
            host.Open();

            var common = new ServiceHost(typeof(CommonService));

            common.Open();


            Console.WriteLine("Server is ready.");
            Console.Read();
            #endregion
        }
    }
}
