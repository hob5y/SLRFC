namespace SLRFC.PlayerManager.Controllers
{
    using System;
    using System.Web.Mvc;

    using SLRFC.PlayerManager.Helpers;
    using SLRFC.PlayerManager.ViewModels;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var vm = new PlayersViewModel();

            //vm.WeekBeginningDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday);

            //vm.Load();

            return this.View();
        }

        public ActionResult SearchByWeekBeginning(DateTime weekBeginningDate)
        {
            //var vm = new MembersViewModel();

            //vm.WeekBeginningDate = weekBeginningDate;

            //vm.Load();

            return this.View();
        }
    }
}