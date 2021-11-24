using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PredmetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Predmet
        [CustomAuthorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Predmets.ToListAsync());
        }

        // GET: Predmet/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = await db.Predmets.FindAsync(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // GET: Predmet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PredmetID,NazivPredmeta")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Predmets.Add(predmet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(predmet);
        }

        // GET: Predmet/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = await db.Predmets.FindAsync(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PredmetID,NazivPredmeta")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predmet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(predmet);
        }

        // GET: Predmet/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmet predmet = await db.Predmets.FindAsync(id);
            if (predmet == null)
            {
                return HttpNotFound();
            }
            return View(predmet);
        }

        // POST: Predmet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Predmet predmet = await db.Predmets.FindAsync(id);
            db.Predmets.Remove(predmet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
