using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CrossEduAsp.Models;
using CrossEduAsp.Models.Entities;

namespace CrossEduAsp.Controllers.GameController
{
    public class GameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Game/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var gameentities = db.GameEntities;
            return View(gameentities.ToList());
        }

        // GET: /Game/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameEntity gameentity = db.GameEntities.Find(id);
            if (gameentity == null)
            {
                return HttpNotFound();
            }
            return View(gameentity);
        }

        // GET: /Game/Create

        public ActionResult Create()
        {
            GameEntity model = new GameEntity();
            return View(model);
        }

        // POST: /Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Path,ReleaseDate,Title,Description,PicturePath,ApplicationUserId")] GameEntity gameentity)
        {
            if (ModelState.IsValid)
            {
                db.GameEntities.Add(gameentity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameentity);
        }

        // GET: /Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameEntity gameentity = db.GameEntities.Find(id);
            if (gameentity == null)
            {
                return HttpNotFound();
            }

            return View(gameentity);
        }

        // POST: /Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Path,Title,Description,PicturePath,ReleaseDate,ApplicationUserId")] GameEntity gameentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameentity);
        }

        // GET: /Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameEntity gameentity = db.GameEntities.Find(id);
            if (gameentity == null)
            {
                return HttpNotFound();
            }
            return View(gameentity);
        }

        // POST: /Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameEntity gameentity = db.GameEntities.Find(id);
            List<CommentEntity> commentsOnGame = db.CommentEntities.Where(com => com.Game.Id == id).ToList();

            foreach (var comment in commentsOnGame)
            {
                db.CommentEntities.Remove(comment);                
            }
            db.GameEntities.Remove(gameentity);
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

        // GET: /Game/Show/5
        [AllowAnonymous]
        public ActionResult ShowGame(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			var gameentity = db.GameEntities.Find(id);

	        gameentity.CounterViews++;
			if (ModelState.IsValid)
			{
				db.Entry(gameentity).State = EntityState.Modified;
				db.SaveChanges();
			}

			var comment = new CommentEntity();
	        List<CommentEntity> commentList = db.CommentEntities.Where(x => x.GameId == id).ToList();
			if (gameentity == null)
            {
                return HttpNotFound();
            }

	        var gameViewModel = new GameViewModel()
	        {
		        Game = gameentity,
		        Comment = comment,
		        CommentList = commentList
	        };

            return View(gameViewModel);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public void ShowGame(GameViewModel gameViewModel)
		{
			gameViewModel.Comment.DateOfPublication = DateTime.Now;
			gameViewModel.Comment.GameId= gameViewModel.Game.Id;
			db.CommentEntities.Add(gameViewModel.Comment);
			db.SaveChanges();
			
			/*ToDo: Don't valid, because title, path and description from game is required
						if (ModelState.IsValid)
						{
							db.CommentEntities.Add(gameViewModel.Comment);
							db.SaveChanges();
						}
			*/
			Response.Redirect(gameViewModel.Game.Id.ToString());
		}
    }
}
