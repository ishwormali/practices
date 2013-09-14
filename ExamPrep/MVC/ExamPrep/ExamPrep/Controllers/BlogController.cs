using ExamPrep.Models;
using ExamPrep.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            db.Configuration.ValidateOnSaveEnabled = false;
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

        public ActionResult EditPost(int id)
        {
            var post = db.Posts.Include(m=>m.Blog).FirstOrDefault(m => m.Id == id);
            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    //post = db.Posts.Include(m=>m.Blog).FirstOrDefault(m => m.Id == post.Id);
                    ////Reading original value of a property
                    //var orgBody = db.Entry(post).Property(m => m.Body).OriginalValue;
                    ////Reading the current changed value
                    //var changedBody = db.Entry(post).Property(m => m.Body).CurrentValue;
                    ////Check if the property is modified?
                    //var isBodyModified = db.Entry(post).Property(m => m.Body).IsModified;
                    ////Returns all properties original values as DbPropertyValues 
                    //var allOriginalValues=db.Entry(post).OriginalValues;
                    ////Returns all properties current values as DbPropertyValues 
                    //var allCurrentValues = db.Entry(post).CurrentValues;
                    ////Get values from db as DbPropertyValues
                    //var dbValues = db.Entry(post).GetDatabaseValues();
                    ////looping and displaying values
                    //foreach (var propName in dbValues.PropertyNames)
                    //{
                    //    var propValue = dbValues[propName]; //returns object
                    //    var propValue2 = dbValues.GetValue<string>(propName); //strongly typed
                        
                    //}

                    ////setting new values 
                    //dbValues.SetValues(post);

                    return RedirectToAction("Posts", new { id = post.Blog.Id });
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.SingleOrDefault();
                    var dbPost = entry.GetDatabaseValues().ToObject() as Post;
                    if (!dbPost.Title.Equals(post.Title))
                    {
                        ModelState.AddModelError("Title",string.Format( "Current Value : {0}", dbPost.Title));
                    }

                    if (!dbPost.Body.Equals(post.Body))
                    {
                        ModelState.AddModelError("Body",string.Format( "Current Value : {0}", dbPost.Body));
                    }

                    return View(post);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View(post);

        }

    }
}
