using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;

        public EntriesController()
        {
            _entriesRepository = new EntriesRepository();
        }

        public ActionResult Index()
        {
            List<Entry> entries = _entriesRepository.GetEntries();

            // Calculate the total bugs.
            int totalBugs = entries.Where(e => e.Exclude = false).Count();
            int numberOfActiveDays = entries.Select(e => e.Date).Distinct().Count();

            ViewBag.TotalBugs = totalBugs;
            ViewBag.AverageDailyBugs = (totalBugs / (double) numberOfActiveDays);

            return View(entries);
        }

        public ActionResult Add()
        {
            var entry = new Entry()
            {
                Date = DateTime.Today
            };
            
            SetupBugSelectListItems();
            return View( entry );
        }
        
        [System.Web.Mvc.HttpPost]
        public ActionResult Add( Entry entry )
        {
            ValidateEntry( entry );

            if (ModelState.IsValid)
            {
                _entriesRepository.AddEntry(entry);

                return RedirectToAction("Index");
            }
            
            SetupBugSelectListItems();
            return View( entry );
        }

        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Entry entry = _entriesRepository.GetEntry((int) id);

            if (entry == null)
            {
                return HttpNotFound();
            }

            SetupBugSelectListItems();
            return View(entry);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(Entry entry)
        {
            ValidateEntry(entry);

            if (ModelState.IsValid)
            {
                _entriesRepository.UpdateEntry(entry);
                TempData["Message"] = "Your entry was successfully updated!";

                return RedirectToAction("Index");
            }

            SetupBugSelectListItems();
            return View(entry);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Entry entry = _entriesRepository.GetEntry((int) id);
            if (entry == null)
            {
                return HttpNotFound();
            }

            return View(entry);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id)
        {
            _entriesRepository.DeleteEntry(id);
            TempData["Message"] = "Your entry was successfully deleted!";
            return RedirectToAction("Index");
        }

        private void ValidateEntry(Entry entry)
        {
            // If there aren't any "Status" field validation errors
            // Then make sure the status is set to Open.
        }

        private void SetupBugSelectListItems()
        {
            ViewBag.BugSelectListItems = new SelectList( Data.Data.Bugs, "Id", "Name" );
        }
    }
}