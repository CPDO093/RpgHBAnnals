using Microsoft.AspNet.Identity;
using RpgHBAnnals.Model.Weapon;
using RpgHBAnnals.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RpgHBAnnals.Controllers
{
    public class WeaponController : Controller
    {
        // GET: Weapon
        public ActionResult Index()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new WeaponService(userid);
            var model = service.GetWeapon();
            return View(model);
        }
        //get:
        //create weapon view
        public ActionResult Create()
        {
            return View();
        }
        //Vallidation
        //Post: game just made
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeaponCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWeaponService();

            if (service.CreateWeapon(model))
            {
                TempData["SaveResult"] = "Your Weapon was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Weapon could not be created.");

            return View(model);
        }
        private WeaponService CreateWeaponService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WeaponService(userId);
            return service;
        }

        //Get:
        //single weapon by id
        public ActionResult Details(int id)
        {
            var svc = CreateWeaponService();
            var model = svc.GetWeaponById(id);
            return View(model);
        }

        //Get:
        //bring up Weapon that needs to be edited
        public ActionResult Edit(int id)
        {
            var svc = CreateWeaponService();
            var detail = svc.GetWeaponById(id);
            var model = new WeaponEdit()
            {
                Type = detail.Type,
                Name = detail.Name,
                Damage = detail.Damage,
                Properties = detail.Properties
            };
            return View(model);
        }

        //Post:
        //validation and saving of changes made
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WeaponEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WeaponId != id)
            {
                ModelState.AddModelError("", "ID did not match.");
                return View(model);
            }
            var service = CreateWeaponService();
            if (service.UpdateWeapon(model))
            {
                TempData["SaveResult"] = "Your Weapon was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your updates to the weapon could not be saved.");
            return View(model);
        }

        //Get:
        //weapon by id for deletion
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWeaponService();
            var model = svc.GetWeaponById(id);

            return View(model);
        }

        //Post:
        // validation and deletion of weapon
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWeapon(int id)
        {
            var service = CreateWeaponService();
            service.DeleteWeapon(id);
            TempData["SaveResult"] = "The Weapon you made has been deleted.";
            return RedirectToAction("Index");
        }
    }
}