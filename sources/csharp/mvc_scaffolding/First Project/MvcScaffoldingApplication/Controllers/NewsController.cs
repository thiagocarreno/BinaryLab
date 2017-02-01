using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcScaffoldingApplication.Models;

namespace MvcScaffoldingApplication.Controllers
{   
    public class NewsController : Controller
    {
        private MvcScaffoldingApplicationContext context = new MvcScaffoldingApplicationContext();

        //
        // GET: /News/

        public ViewResult Index()
        {
            return View(context.News.ToList());
        }

        //
        // GET: /News/Details/5

        public ViewResult Details(int id)
        {
            News news = context.News.Single(x => x.IdNews == id);
            return View(news);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                context.News.Add(news);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(news);
        }
        
        //
        // GET: /News/Edit/5
 
        public ActionResult Edit(int id)
        {
            News news = context.News.Single(x => x.IdNews == id);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                context.Entry(news).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(int id)
        {
            News news = context.News.Single(x => x.IdNews == id);
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = context.News.Single(x => x.IdNews == id);
            context.News.Remove(news);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}