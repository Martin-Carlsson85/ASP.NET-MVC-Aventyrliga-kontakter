using AdventurousContacts.Models;
using AdventurousContacts.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        public ContactController()
            :this(new Repository())
        {

        }
        public ContactController(IRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult Index()
        {
            return View(_repository.GetLastContacts());
        }
    
        public ActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, EmailAddress")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(contact);
                    _repository.Save();
                    TempData["success"] = "Skapades korrekt!.";
                }
            }
            catch (DataException ex)
            {
                TempData["error"] = "Det gick inte att skapa!";
                TempData["errorDetails"] = ex.InnerException.InnerException.Message.ToString();
                return RedirectToAction("Create", contact);
            }

            return View("Success", contact);
        }
        
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
      
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            if (TryUpdateModel(contact, String.Empty, new string[] { "FirstName", "LastName", "EmailAddress" }))
            {
                try
                {
                    _repository.Update(contact);
                    _repository.Save();
                    TempData["success"] = "Sparades korrekt!";
                }
                catch (DataException ex)
                {
                    TempData["error"] = "Inga ändringar har sparats";
                    TempData["errorDetails"] = ex.InnerException.InnerException.Message.ToString();
                    return RedirectToAction("Edit", contact);
                }
            }
            return View("Success", contact);
        }
      
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }
     
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Contact contact = _repository.GetContactById(id);
            try
            {
                _repository.Delete(contact);
                _repository.Save();
                TempData["success"] = "Raderades korrekt!";
            }
            catch (DataException ex)
            {
                TempData["error"] = "Raderades inte korrekt!";
                TempData["errorDetails"] = ex.InnerException.InnerException.Message.ToString();
                return RedirectToAction("Delete", new { id = id });
            }

            return View("Success", contact);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
