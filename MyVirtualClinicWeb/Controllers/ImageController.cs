using MyVirtualClinicWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVirtualClinicWeb.Controllers
{
    
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        // GET: Image/Details
        public ActionResult Details(int id = 0)
        {
            var db = new ApplicationDbContext();
            VirtualClinicSubmissionModel virtualClientSubmissionModel;
            if (id == 0)
            {
                virtualClientSubmissionModel = db.VirtualClientSubmissionModels.Include("ImageModels").AsEnumerable().Last();
            }
            else {
                virtualClientSubmissionModel = db.VirtualClientSubmissionModels.Include("ImageModels").Include("PersonModel").AsEnumerable().Where(m => m.SubmissionId == id).SingleOrDefault();
            }

            if (virtualClientSubmissionModel == null) {
                return Content(id.ToString() + " is not a valid My Virtual Clinic submission number.");
            }

            return View(virtualClientSubmissionModel);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(VirtualClinicSubmissionModel virtualClinicSubmissionModel)
        {
            try
            {
                // Note Entity Framework really good - imageModel.SubmissionId is identity column
                // in DB. SubmissionId passed in will be replaced by that calculated by database(!).                
                //Unfortunately constituent elements  of virtualClinicSubmissionModelare not parsed by 
                //MVC model binding so I do that be hand.
                var db = new ApplicationDbContext();
                
                //db.VirtualClientSubmissionModels.Add(virtualClinicSubmissionModel);
                //db.SaveChanges();
                
                //var newdb = new ApplicationDbContext();
                List<string> images = JsonConvert.DeserializeObject<List<string>>(HttpContext.Request["ImageModels"]);

                foreach (string image in images) {
                    //    newdb.ImageModels.Add(new ImageModel { SubmissionId = virtualClinicSubmissionModel.SubmissionId, Image = image });
                    virtualClinicSubmissionModel.ImageModels.Add(new ImageModel {  Image = image });
                }

                dynamic anonPerson = JsonConvert.DeserializeObject<dynamic>( HttpContext.Request["PersonModel"]);

                //var personModel = new PersonModel { SubmissionId = virtualClinicSubmissionModel.SubmissionId,
                //                                        Firstname = anonPerson.FirstName,
                //                                        Surname=anonPerson.LastName,
                //                                        Dob=anonPerson.Dob
                //                                        };
                //newdb.PersonModels.Add(personModel);
                //newdb.SaveChanges();

                virtualClinicSubmissionModel.PersonModel.Add(
                    new PersonModel
                    {
                        
                        Firstname = anonPerson.FirstName,
                        Surname = anonPerson.LastName,
                        Dob = anonPerson.Dob
                    });

                db.VirtualClientSubmissionModels.Add(virtualClinicSubmissionModel);
                db.SaveChanges();

                ViewBag.Notes = JsonConvert.SerializeObject(virtualClinicSubmissionModel);

                //return RedirectToAction("Index");
                //This called from MyVirtClinic app- provide a suitable return value
                return View("index");
            }
            catch(DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                             ve.PropertyName,
                             eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                             ve.ErrorMessage);
                    }
                }
                return View();
            }
        }
        
        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
