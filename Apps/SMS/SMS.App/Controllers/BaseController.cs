namespace SMS.App.Controllers
{
    using Data;
    using SIS.MvcFramework;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new SMSContext();
        }

        protected SMSContext Context { get; set; }
    }
}