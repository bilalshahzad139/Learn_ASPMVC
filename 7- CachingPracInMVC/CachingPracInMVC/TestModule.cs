using System;
using System.Web;

namespace CachingPracInMVC
{
    /* -----------Following text is taken from 70-486 book ---------------------------------
     * The general application flow is validation, URL mapping, a set of events, the handler, and a set of events. 
     * Validation occurs when the system examines the information sent by the browser to evaluate whether 
     * it contains markup that could be malicious. The process then performs URL mapping if any URLs have been 
     * configured in the <UrlMappingsSection> section of the Web.config file. 
     * After it has completed the URL mapping process, the HttpApplication runs through security and caching processes 
     * until it gets to the assigned handler. After the handler completes processing the request, it goes through 
     * the recaching and logging events and sends the response back to the client. 
    */
    public class TestModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {


            //System.Web.HttpApplication has 22 available events

            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
            context.PostAuthenticateRequest += context_PostAuthenticateRequest;
            context.AuthorizeRequest += context_AuthorizeRequest;
            context.PostAuthorizeRequest += context_PostAuthorizeRequest;
            context.ResolveRequestCache += context_ResolveRequestCache;
            context.PostResolveRequestCache += context_PostResolveRequestCache;
            context.MapRequestHandler += context_MapRequestHandler;
            context.PostMapRequestHandler += context_PostMapRequestHandler;
            context.AcquireRequestState += context_AcquireRequestState;
            context.PostAcquireRequestState += context_PostAcquireRequestState;
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
            context.PostRequestHandlerExecute += context_PostRequestHandlerExecute;
            context.ReleaseRequestState += context_ReleaseRequestState;
            context.PostReleaseRequestState += context_PostReleaseRequestState;
            context.UpdateRequestCache += context_UpdateRequestCache;
            context.PostUpdateRequestCache += context_PostUpdateRequestCache;
            context.LogRequest += context_LogRequest;
            context.PostLogRequest += context_PostLogRequest;
            context.EndRequest += context_EndRequest;
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
            context.PreSendRequestContent += context_PreSendRequestContent;

        }

        //1- The first event raised; always raised when processing a request
        void context_BeginRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "1- TestModule: Beginning of Request");
        }

        //2- Raised when a security module has identified the user
        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "2- TestModule: AuthenticateRequest");
        }
        //3- Raised after the AuthenticateRequest event is raised
        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "3- TestModule: PostAuthenticateRequest");
        }
        //4- Raised after a security module has authorized the user
        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "4- TestModule: AuthorizeRequest");
        }
        //5- Raised after the AuthorizeRequest event is raised
        void context_PostAuthorizeRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "5- TestModule: PostAuthorizeRequest");
        }
        //6- Raised to let caching modules serve the requests
        void context_ResolveRequestCache(object sender, EventArgs e)
        {
            WriteToResponse(sender, "6- TestModule: ResolveRequestCache");
        }
        //7- Raised when a caching module served the request
        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            WriteToResponse(sender, "7- TestModule: PostResolveRequestCache");
        }
        //8- Raised when the appropriate HttpHandler is selected
        void context_MapRequestHandler(object sender, EventArgs e)
        {
            WriteToResponse(sender, "8- TestModule: MapRequestHandler");
        }
        //9-Raised after the MapRequestHandler event is raised
        void context_PostMapRequestHandler(object sender, EventArgs e)
        {
            WriteToResponse(sender, "9- TestModule: PostMapRequestHandler");
        }
        //10- Raised when the current state, such as session state, is acquired
        void context_AcquireRequestState(object sender, EventArgs e)
        {
            WriteToResponse(sender, "10- TestModule: AcquireRequestState");
        }
        //11- Raised after the AcquireRequestState event is raised
        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            WriteToResponse(sender, "11- TestModule: PostAcquireRequestState");
        }
        //12- Raised just prior to executing an event handler
        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            WriteToResponse(sender, "12- TestModule: PreRequestHandlerExecute");
        }
        //13- Raised when the HttpHandler has completed execution
        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            WriteToResponse(sender, "13- TestModule: PostRequestHandlerExecute");
        }
        //14- Raised when all request event handlers are completed
        void context_ReleaseRequestState(object sender, EventArgs e)
        {
            WriteToResponse(sender, "14- TestModule: ReleaseRequestState");
        }
        //15- Raised after the PostReleaseRequestState event is raised
        void context_PostReleaseRequestState(object sender, EventArgs e)
        {
            WriteToResponse(sender, "15- TestModule: PostReleaseRequestState");
        }
        //16- Raised after caching modules store the response for future use
        void context_UpdateRequestCache(object sender, EventArgs e)
        {
            WriteToResponse(sender, "16- TestModule: UpdateRequestCache");
        }
        //17- Raised after the UpdateRequestCache is raised
        void context_PostUpdateRequestCache(object sender, EventArgs e)
        {
            WriteToResponse(sender, "17- TestModule: PostUpdateRequestCache");
        }
        //18- Raised just prior to logging the request
        void context_LogRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "18- TestModule: LogRequest");
        }
        //19- Raised when all LogRequest event handlers are completed
        void context_PostLogRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "19- TestModule: PostLogRequest");
        }
        //20- The last event raised in the HTTP pipeline
        void context_EndRequest(object sender, EventArgs e)
        {
            WriteToResponse(sender, "20- TestModule: End of Request");
        }
        //21- Raised just before the HTTP headers are sent to the client
        void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            WriteToResponse(sender, "21- TestModule: PreSendRequestHeaders");
        }
        //22- Raised just before the content is sent to the client
        void context_PreSendRequestContent(object sender, EventArgs e)
        {
            WriteToResponse(sender, "22- TestModule: PreSendRequestContent");
        }


        //Helper function
        private void WriteToResponse(object sender, string message)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Response.Write(String.Format("<font color=red>{0} on {1}</font><hr>", message,DateTime.Now.ToString()));
        }


        #endregion


    }
}
