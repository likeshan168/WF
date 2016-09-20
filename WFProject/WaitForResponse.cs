using System;
using System.Activities;

namespace WFProject
{
    public sealed class WaitForResponse<TResult> : NativeActivity<TResult>
    {
        public WaitForResponse()
        : base()
        {
        }
        public string ResponseName { get; set; }


        protected override bool CanInduceIdle
        { //override when the custom activity is allowed to make he workflow go idle
            get
            {
                return true;
            }
        }
        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(this.ResponseName, new
            BookmarkCallback(this.ReceivedResponse));
        }
        void ReceivedResponse(NativeActivityContext context, Bookmark bookmark,
        object obj)
        {
            this.Result.Set(context, (TResult)obj);
        }
    }
}
