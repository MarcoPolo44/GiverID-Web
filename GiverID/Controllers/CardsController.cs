using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GiverID.Models;
using Microsoft.AspNet.Identity;

namespace GiverID.Controllers
{
    [Authorize]
    public class CardsController : Controller
    {
        private CardDBContext db = new CardDBContext();

        // GET: Cards
        public ActionResult Index()
        {
            string currentUserID;
            UserCards currentUserCards = new UserCards();

            currentUserID = User.Identity.GetUserId();

            foreach (Card c in db.Cards)
            {
                if (c.UserID == currentUserID)
                {
                    currentUserCards.CardList.Add(c);
                }
            }

            return View(currentUserCards.CardList.AsEnumerable());
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CardNumber")] Card card)
        {
            if (ModelState.IsValid)
            {
                card.UserID = User.Identity.GetUserId();

                if (db.Cards.Where(a => a.CardNumber == card.CardNumber).Any() == false)
                {
                    db.Cards.Add(card);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "This card has already been registered.");
                }
            }

            return View(card);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card card = db.Cards.Find(id);
            db.Cards.Remove(card);
            db.SaveChanges();
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
