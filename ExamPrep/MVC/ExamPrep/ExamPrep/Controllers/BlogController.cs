using ExamPrep.Models;
using ExamPrep.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPrep.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        BlogDbContext db = new BlogDbContext();
        public ActionResult Index()
        {
            //var blog = db.Blogs.Create();
            //blog.Title = "Ishwor's Blog";
            //blog.CreatedBy = "Ishwor";
            //db.Blogs.Add(blog);
            //db.SaveChanges();
            return View(db.Blogs.ToList());
        }

        public ActionResult Details(int id)
        {
            var blog=db.Blogs.FirstOrDefault(m=>m.Id==id);
            return View(blog);
        }

        public ActionResult Edit(int id)
        {
            var blog = db.Blogs.FirstOrDefault(m => m.Id == id);
            return View(blog);
        }

        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return View(blog);
            }

            return View("Index");
        }


    }
}
