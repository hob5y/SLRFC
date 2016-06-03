namespace SLRFC.PlayerManager.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using SLRFC.Model;
    using SLRFC.PlayerManager.ViewModels;

    public class EventsController : Controller
    {
        private MyDbContext dbContext;

        private EventsViewModel vm;

        public EventsController()
        {
            this.dbContext = new MyDbContext();
            this.vm = new EventsViewModel();
        }

        // GET: Events
        public ActionResult Index()
        {
            this.vm.Events = this.dbContext.Events.ToList();

            return this.View(this.vm);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,StartDateTime,EndDateTime,TypeOfEvent,Notes")] Event @event)
        {
            if (ModelState.IsValid)
            {
                this.dbContext.Events.Add(@event);
                this.dbContext.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(@event);
        }
    }
}
