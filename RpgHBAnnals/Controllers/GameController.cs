using Microsoft.AspNet.Identity;
using RpgHBAnnals.Model.Game;
using RpgHBAnnals.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RpgHBAnnals.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userid);
            var model = service.GetGame();
            return View(model);
        }
        //get:
        //create game view
        public ActionResult Create()
        {
            return View();
        }
        //Vallidation
        //Post: game just made
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your Game was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Game could not be created.");

            return View(model);
        }

        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        //Get:
        //single game by id
        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);
            return View(model);
        }

        //Get:
        //bring up game that needs to be edited
        public ActionResult Edit(int id)
        {
            var svc = CreateGameService();
            var detail = svc.GetGameById(id);
            var model = new GameEdit()
            {
                Name = detail.Name,
                Edition = detail.Edition
            };
            return View(model);
        }
        //Post:
        //validation and saving of changes made
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "ID did not match.");
                return View(model);
            }
            var service = CreateGameService();
            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your updates to the game could not be saved.");
            return View(model);
        }

        //Get:
        //game by id for deletion
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }
        //Post:
        // validation and deletion of game
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            var service = CreateGameService();
            service.DeleteGame(id);
            TempData["SaveResult"] = "The game you made has been deleted.";
            return RedirectToAction("Index");
        }
    }
}