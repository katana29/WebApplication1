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
using WebApplication1.Hubs;

namespace WebApplication1.Controllers
{
    public class PolaganjeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [CustomAuthorize(Roles = "SalterFONa")]
        // GET: Polaganje
        public async Task<ActionResult> Index()
        {
            var polaganjes = db.Polaganjes.Include(p => p.Predmet).Include(p => p.Student);
            return View(await polaganjes.ToListAsync());
        }

        // GET: Polaganje/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polaganje polaganje = await db.Polaganjes.FindAsync(id);
            if (polaganje == null)
            {
                return HttpNotFound();
            }
            return View(polaganje);
        }

        // GET: Polaganje/Create
        public ActionResult Create()
        {
            ViewBag.PredmetID = new SelectList(db.Predmets, "PredmetID", "NazivPredmeta");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "BrIndexa");
            return View();
        }

        // POST: Polaganje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PolaganjeID,ocena,datum,StudentID,PredmetID")] Polaganje polaganje)
        {
            if (ModelState.IsValid)
            {
                db.Polaganjes.Add(polaganje);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

                /*var isAdded = db.SaveChanges() > 0;
                if (isAdded)
                {
                    BroadcastPolaganjeData();
                }*/

            }

            ViewBag.PredmetID = new SelectList(db.Predmets, "PredmetID", "NazivPredmeta", polaganje.PredmetID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "BrIndexa", polaganje.StudentID);
            return View(polaganje);
        }

        // GET: Polaganje/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polaganje polaganje = await db.Polaganjes.FindAsync(id);
            if (polaganje == null)
            {
                return HttpNotFound();
            }
            ViewBag.PredmetID = new SelectList(db.Predmets, "PredmetID", "NazivPredmeta", polaganje.PredmetID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "BrIndexa", polaganje.StudentID);
            return View(polaganje);
        }

        // POST: Polaganje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PolaganjeID,ocena,datum,StudentID,PredmetID")] Polaganje polaganje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(polaganje).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PredmetID = new SelectList(db.Predmets, "PredmetID", "NazivPredmeta", polaganje.PredmetID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "BrIndexa", polaganje.StudentID);
            return View(polaganje);
        }

        // GET: Polaganje/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polaganje polaganje = await db.Polaganjes.FindAsync(id);
            if (polaganje == null)
            {
                return HttpNotFound();
            }
            return View(polaganje);
        }

        // POST: Polaganje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Polaganje polaganje = await db.Polaganjes.FindAsync(id);
            db.Polaganjes.Remove(polaganje);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        /* public void BroadcastPolaganjeData() {
            var dataList = db.Polaganjes.ToList();
            PolaganjeHub.PolaganjeBroadcasr(dataList);
        }
        */
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
