using ExamPrep.Models;
using ExamPrep.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

            var blog = db.Blogs.Include(m => m.Metadata).FirstOrDefault(m => m.Id == id);
            return View(blog);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            

            blog.Metadata.CreatedOn = DateTime.Now;
            blog.Metadata.LastUpdated = DateTime.Now;
            blog.Metadata.Blog = blog;
            //db.BlogMetadatas.Add(blog.Metadata);
            //var metadata = blog.Metadata;
            //blog.Metadata = null;

            db.Blogs.Add(blog);
            //blog.Metadata = new BlogMetadata();
            
            db.SaveChanges();

            //metadata.BlogId = blog.Id;
            //metadata.Blog = blog;

           // db.BlogMetadatas.Add(metadata);
           // db.SaveChanges();

            return RedirectToAction("Edit", new { id = blog.Id });
        }

        public ActionResult Edit(int id)
        {
            var blog = db.Blogs.FirstOrDefault(m => m.Id == id);

            return View(blog);
        }

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var originalBlog = db.Blogs.Include(m=>m.Metadata).FirstOrDefault(m => m.Id == blog.Id);
                originalBlog.Title = blog.Title;
                originalBlog.CreatedBy = blog.CreatedBy;
                originalBlog.Metadata.Language = blog.Metadata.Language;
                originalBlog.Metadata.LastUpdated = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(blog);
        }

        public ActionResult Remove(int id)
        {
            var blog = db.Blogs.FirstOrDefault(m => m.Id == id);
            if (blog != null)
            {
                blog.Posts.Clear();
                db.Blogs.Remove(blog);
                
                db.SaveChanges();
                
            }

            return RedirectToAction("Index");
        }

        public ActionResult Posts(int id)
        {
            var blog = db.Blogs.Include(m=>m.Metadata).FirstOrDefault(m => m.Id == id);
            db.Entry(blog).Collection(m => m.Posts).Load();
            return View(blog);
        }


        public ActionResult AddPost(int id)
        {
            var blog = db.Blogs.FirstOrDefault(m => m.Id == id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult AddPost(int id,Post post)
        {
            var blog = db.Blogs.FirstOrDefault(m => m.Id == id);
            if (ModelState.IsValid)
            {
                
                blog.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Posts", new { id = blog.Id });
            }

            return View(blog);
        }

    }
}
