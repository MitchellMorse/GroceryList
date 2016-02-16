using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryList.DAL;
using GroceryList.Models;
using GroceryList.ViewModels;

namespace GroceryList
{
    public class ListsController : Controller
    {
        private GroceryListContext db = new GroceryListContext();

        // GET: Lists
        public async Task<ActionResult> Index()
        {
            return View(await db.Lists.ToListAsync());
        }

        // GET: Lists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return HttpNotFound();
            }

            var listIngredients = new ListIngredients();
            listIngredients.UnusedIngredients = db.Ingredients.OrderBy(i => i.Name).Where(i => !db.ListIngredients.Any(li => li.ListId == id && li.IngredientId == i.Id))
                                                .Select(i => new SelectListItem() { Text = i.Name, Value = i.Id.ToString() })
                                                .ToList();

            listIngredients.AddedIngredients = db.Ingredients.OrderBy(i => i.Name).Where(i => db.ListIngredients.Any(li => li.ListId == id && li.IngredientId == i.Id))
                                                .Select(i => i)
                                                .ToList();

            listIngredients.CurrentList = list;
            listIngredients.CurrentListId = list.Id;

            return View(listIngredients);
        }

        [HttpPost, ActionName("AddIngredientToList")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details([Bind(Include = "CurrentListId,SelectedIngredientId")] ListIngredients listIngredients, int listId)
        {
            if (ModelState.IsValid && listIngredients.SelectedIngredientId > 0)
            {
                ListIngredient li = new ListIngredient()
                {
                    IngredientId = listIngredients.SelectedIngredientId,
                    ListId = listId
                };

                db.ListIngredients.Add(li);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = listId });
            }
            
            return RedirectToAction("Index");
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateCreated")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Lists.Add(list);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(list);
        }

        // GET: Lists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateCreated")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(list);
        }

        // GET: Lists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            List list = await db.Lists.FindAsync(id);
            db.Lists.Remove(list);
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
