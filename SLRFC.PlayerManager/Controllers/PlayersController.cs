using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SLRFC.Model;

namespace SLRFC.PlayerManager.Controllers
{
    using System.Data.Entity.Migrations;

    using SLRFC.PlayerManager.ViewModels;

    public class PlayersController : Controller
    {
        private MyDbContext dbContext;

        private PlayersViewModel vm;

        public PlayersController()
        {
            this.dbContext = new MyDbContext();
            this.vm = new PlayersViewModel();
        }

        // GET: Players
        public ActionResult Index()
        {
            this.vm.Players = this.dbContext.Members.OfType<Player>().Where(x => x.IsActive).ToList();

            return this.View(this.vm);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.vm.Player = this.dbContext.Members.OfType<Player>().ToList().Find(x => x.MembershipId == id);

            if (this.vm.Player == null)
            {
                return this.HttpNotFound();
            }

            return this.View(this.vm.Player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembershipId,FirstName,LastName,MembershipType,PlayerId,IsActive,Position")] Player player)
        {
            this.vm.Player = player;

            if (ModelState.IsValid)
            {
                foreach (var ev in this.dbContext.Events.Where(x => x.StartDateTime > DateTime.Now))
                {
                    this.vm.Player.Availabilities.Add(new Availability { Event = ev });
                }

                this.dbContext.Players.Add(this.vm.Player);

                this.dbContext.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(this.vm.Player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.vm.Player = this.dbContext.Members.OfType<Player>().ToList().Find(x => x.MembershipId == id);

            if (this.vm.Player == null)
            {
                return this.HttpNotFound();
            }

            return this.View(this.vm.Player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembershipId,FirstName,LastName,MembershipType,PlayerId,IsActive,Position")] Player player)
        {
            this.vm.Player = player;

            if (ModelState.IsValid)
            {
                this.dbContext.Entry(this.vm.Player).State = EntityState.Modified;
                this.dbContext.SaveChanges();

                return this.RedirectToAction("Index");
            }
            return this.View(this.vm.Player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.vm.Player = this.dbContext.Members.OfType<Player>().ToList().Find(x => x.MembershipId == id);

            if (this.vm.Player == null)
            {
                return this.HttpNotFound();
            }

            return this.View(this.vm.Player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.vm.Player = this.dbContext.Members.OfType<Player>().ToList().Find(x => x.MembershipId == id);

            this.dbContext.Members.Remove(this.vm.Player);
            this.dbContext.SaveChanges();

            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
