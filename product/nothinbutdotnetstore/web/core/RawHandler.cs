using System.Web;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

        public RawHandler() : this(IOC.get.an_instance_of<FrontController>(),
                                   IOC.get.an_instance_of<RequestFactory>())
        {
        }

        public RawHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}