using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrossEduAsp.Models;
using CrossEduAsp.Models.Entities;

namespace CrossEduAsp.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comment
        public ActionResult Index()
        {
            var commentEntities = db.CommentEntities.Include(c => c.ApplicationUser).Include(c => c.Game);
            return View(commentEntities.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentEntity commentEntity = db.CommentEntities.Find(id);
            if (commentEntity == null)
            {
                return HttpNotFound();
            }
            return View(commentEntity);
        }


        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentEntity commentEntity = db.CommentEntities.Find(id);
            if (commentEntity == null)
            {
                return HttpNotFound();
            }
            
			return View(commentEntity);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,DateOfPublication,GameId,ApplicationUserId")] CommentEntity commentEntity)
        {
	        commentEntity.DateOfPublication = DateTime.Now;
			if (ModelState.IsValid)
            {
                db.Entry(commentEntity).State = EntityState.Modified;
                db.SaveChanges();
            }

			return RedirectToAction("ShowGame", "Game", new { id = commentEntity.GameId });
        }

        // POST: Comment/Delete/5

        public ActionResult Delete(int id)
        {
            CommentEntity commentEntity = db.CommentEntities.Find(id);
	        var backPage = commentEntity.Game.Id;
            db.CommentEntities.Remove(commentEntity);
            db.SaveChanges();

			return RedirectToAction("ShowGame", "Game", new {id = backPage});
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
