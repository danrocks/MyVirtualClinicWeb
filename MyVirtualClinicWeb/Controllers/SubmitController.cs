using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyVirtualClinicWeb.Models;

namespace MyVirtualClinicWeb.Controllers
{
    [AllowAnonymous]
    public class SubmitController : Controller
    {
        // GET: Submit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Submit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Submit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Submit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Submit/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    System.Web.HttpContext.Current.Application.Lock();
        //    System.Web.HttpContext.Current.Application["image"] = id;
        //    System.Web.HttpContext.Current.Application.UnLock();

        //    return View();
        //}
        //[HttpPost]
        //// public string Edit(int id, string base64)
        //public string Edit(SubmitModel sub)
        //{
        //    System.Diagnostics.Debug.WriteLine("Edit action called...");
        //    System.Diagnostics.Debug.WriteLine(sub.base64);
        //    System.Diagnostics.Debug.WriteLine(sub.Id);
        //    System.Web.HttpContext.Current.Application.Lock();
        //    System.Web.HttpContext.Current.Application["image"] = sub.base64;
        //    System.Web.HttpContext.Current.Application.UnLock();

        //    return "Edit called";
        //}

        [HttpPost]
        public string Edit(string Id, string base64)        
        {
            System.Diagnostics.Debug.WriteLine("New Edit action called...");
            System.Diagnostics.Debug.WriteLine(base64);
            System.Diagnostics.Debug.WriteLine(Id);
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["image"] = base64;
            System.Web.HttpContext.Current.Application.UnLock();

            return "Edit called";
        }


        //// POST: Submit/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        System.Diagnostics.Debug.WriteLine("Original Edit action called");
        //        System.Web.HttpContext.Current.Application.Lock();
        //     //   System.Web.HttpContext.Current.Application["image"] = base64;
        //        System.Web.HttpContext.Current.Application.UnLock();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Submit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Submit/Delete/5
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
