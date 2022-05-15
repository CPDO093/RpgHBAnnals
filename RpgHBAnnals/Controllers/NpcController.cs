using Microsoft.AspNet.Identity;
using RpgHBAnnals.Model.Npc;
using RpgHBAnnals.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RpgHBAnnals.Controllers
{
    public class NpcController : Controller
    {
        // GET: Npc
        public ActionResult Index()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new NpcService(userid);
            var model = service.GetNpc();
            return View(model);
        }
        //get:
        //create npc view
        public ActionResult Create()
        {
            return View();
        }
        //Vallidation
        //Post: Npc just made
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NpcCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNpcService();

            if (service.CreateNpc(model))
            {
                TempData["SaveResult"] = "Your Npc was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Npc could not be created.");

            return View(model);
        }
        private NpcService CreateNpcService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NpcService(userId);
            return service;
        }
        //Get:
        //single Npc by id
        public ActionResult Details(int id)
        {
            var svc = CreateNpcService();
            var model = svc.GetNpcById(id);
            return View(model);
        }

        //Get:
        //bring up Npc that needs to be edited
        public ActionResult Edit(int id)
        {
            var svc = CreateNpcService();
            var detail = svc.GetNpcById(id);
            var model = new NpcEdit()
            {
                GameId = detail.GameId,
                Name = detail.Name,
                Race = detail.Race,
                Notes = detail.Notes
            };
            return View(model);
        }
        //Post:
        //validation and saving of changes made
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NpcEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NpcId != id)
            {
                ModelState.AddModelError("", "ID did not match.");
                return View(model);
            }
            var service = CreateNpcService();
            if (service.UpdateNpc(model))
            {
                TempData["SaveResult"] = "Your Npc was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your updates to the Npc could not be saved.");
            return View(model);
        }
        //Get:
        //Npc by id for deletion
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNpcService();
            var model = svc.GetNpcById(id);

            return View(model);
        }

        //Post:
        // validation and deletion of Npc
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNpc(int id)
        {
            var service = CreateNpcService();
            service.DeleteNpc(id);
            TempData["SaveResult"] = "The Npc you made has been deleted.";
            return RedirectToAction("Index");
        }
    }
}