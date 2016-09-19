using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading;

namespace WorkflowConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, object> wfArg = new Dictionary<string, object>();
            //wfArg.Add("argInAge", 50);

            //Activity workflow1 = new Workflow1();

            //WorkflowInvoker.Invoke(workflow1,wfArg);

            try
            {
                //Activity workflow1 = new ExceptionActivity();
                //WorkflowInvoker.Invoke(workflow1);

                //Activity workflow1 = new Workflow1();
                //Dictionary<string, object> wfarg = new Dictionary<string, object>() { { "argInSeconds", 5 } };
                //WorkflowInvoker.Invoke(workflow1,wfarg);
                StateMachine workflow = new StateMachine();
                WorkflowApplication wfapp = new WorkflowApplication(workflow);
                AutoResetEvent autoEvent = new AutoResetEvent(false);
                wfapp.Completed = (WorkflowApplicationCompletedEventArgs e) => 
                {
                    Console.WriteLine("Workflow has completed!");
                    autoEvent.Set();
                };
                wfapp.Run();
                wfapp.ResumeBookmark("BookMarkResponse", Convert.ToInt32(Console.ReadLine()));
                Console.ReadKey();
            }
            catch(ApplicationException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Variable<int> varAge = new Variable<int>()
            //{
            //    Name = "varAge",
            //    Default = 18
            //};

            //#region activities
            //Activity wfVoting = new Sequence
            //{
            //    Variables = { varAge },
            //    Activities =
            //    {
            //        new If
            //        {
            //            Condition= new InArgument<bool>((e)=>varAge.Get(e)>=18),
            //            Then=new WriteLine
            //            {
            //                Text="You can vote!"
            //            },
            //            Else = new Sequence
            //            {
            //                Activities=
            //                {
            //                    new WriteLine
            //                    {
            //                        Text="Sorry, too young to vote"
            //                    },
            //                    new TerminateWorkflow
            //                    {
            //                        Exception= new InArgument<Exception>((ex)=>new ApplicationException("Too young"))
            //                    }
            //                }

            //            }

            //        },
            //        new WriteLine
            //        {
            //            Text="Thanks for voting"
            //        }
            //    }
            //};
            //#endregion

            //WorkflowInvoker.Invoke(wfVoting);
            //Console.ReadLine();
        }

    }
}
