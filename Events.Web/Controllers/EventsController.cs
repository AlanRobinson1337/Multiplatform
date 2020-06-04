using Events.Data;
using Events.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Web.Extensions;

namespace Events.Web.Controllers
{
    public class EventsController : BaseController
    {
        [Authorize]
        // GET: Events
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = this.LoadEvent(id);
            if(eventToEdit == null)
            {
                this.AddNotification("cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }
            var model = EventInputModel.CreateFromEvent(eventToEdit);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventInputModel model)
        {
            var eventToEdit = this.LoadEvent(id);
            if(eventToEdit == null)
            {
                this.AddNotification("cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }
            if(eventToEdit != null && this.ModelState.IsValid)
            {
                eventToEdit.Title = model.Title;
                eventToEdit.StartDateTime = model.StartDateTime;
                eventToEdit.Duration = model.Duration;
                eventToEdit.Description = model.Description;
                eventToEdit.Location = model.Location;
                eventToEdit.IsPublic = model.IsPublic;

                this.db.SaveChanges();
                this.AddNotification("Event Edited", NotificationType.INFO);
                return this.RedirectToAction("My");
            }
            return this.View(model);
        }

        private Event LoadEvent(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventToEdit = this.db.Events.Where(e => e.Id == id).FirstOrDefault(e => e.AuthorId == currentUserId || isAdmin);
            return eventToEdit;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel model)
        {
            if(model != null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };
                this.db.Events.Add(e);
                this.db.SaveChanges();
                //Display notification message "event Created".
                this.AddNotification("Event Created.", NotificationType.INFO);
                return this.RedirectToAction("My");
            }
            return this.View(model);
        }

        public ActionResult My()
        {
            string currentUserId = this.User.Identity.GetUserId();
            var events = this.db.Events
                .Where(e => e.AuthorId == currentUserId)
                .OrderBy(e => e.StartDateTime)
                .Select(EventViewModel.ViewModel);

            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);
            return View(new UpcomingPassedEventsViewModel()
            {
                UpcomingEvents = upcomingEvents,
                PassedEvents = passedEvents
            });
        }
    }
}