using NAA.Data.Models.Domain;
using NAA.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    public class ApplicationAdminController : Controller
    {
        //private Helper helper;

        private IApplicationService applicationService;
        public ApplicationAdminController()
        {
            //helper = new Helper();
            applicationService = new ApplicationService();
        }
        // GET: ApplicationAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicationAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // Get: Delete Music
        public ActionResult DeleteApplication(int applicationId)
        {
            Application application = applicationService.GetApplication(applicationId);

            return View(application);
        }

        // POST: MusicAdmin/Delete/5
        [HttpPost]
        public ActionResult DeleteApplication(int applicationId, Application application)
        {
            try
            {
                applicationService.DeleteApplication(applicationId, "maxmustermann"); //TODO: UserID
                return RedirectToAction("GetApplications", "Application");
            }
            catch
            {
                return View();
            }
        }

        // POST: ApplicationAdmin/Create
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

        // GET: ApplicationAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationAdmin/Edit/5
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

        // GET: ApplicationAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationAdmin/Delete/5
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
