using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryList.DAL;
using GroceryList.Models;

namespace GroceryList
{
    public class IngredientsTestController : Controller
    {
        private GroceryListContext db = new GroceryListContext();

        // GET: IngredientsTest
        public ActionResult Index()
        {
            var ingredients = db.Ingredients.Include(i => i.GroceryStoreSection);
            return View(ingredients.ToList());
        }

        // GET: IngredientsTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: IngredientsTest/Create
        public ActionResult Create()
        {
            ViewBag.GroceryStoreSectionId = new SelectList(db.GroceryStoreSections, "Id", "Name");
            return View();
        }

        // POST: IngredientsTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,GroceryStoreSectionId")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroceryStoreSectionId = new SelectList(db.GroceryStoreSections, "Id", "Name", ingredient.GroceryStoreSectionId);
            return View(ingredient);
        }

        // GET: IngredientsTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroceryStoreSectionId = new SelectList(db.GroceryStoreSections, "Id", "Name", ingredient.GroceryStoreSectionId);
            return View(ingredient);
        }

        // POST: IngredientsTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,GroceryStoreSectionId")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroceryStoreSectionId = new SelectList(db.GroceryStoreSections, "Id", "Name", ingredient.GroceryStoreSectionId);
            return View(ingredient);
        }

        // GET: IngredientsTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: IngredientsTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
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
