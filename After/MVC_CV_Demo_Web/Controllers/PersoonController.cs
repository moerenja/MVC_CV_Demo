using MVC_CV_Demo_Data.Repositories;
using MVC_CV_Demo_Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV_Demo_Web.Controllers
{
    public class PersoonController : Controller
    {
		private PersoonRepository rep = new PersoonRepository();
		// GET: Persoon
		public ActionResult Index()
        {
			List<PersoonModel> personen = rep.GetAll();
			return View(personen);
		}

		// GET: Persoon/Details/5
		public ActionResult Details(Guid? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PersoonModel persoon = rep.Fetch(id.GetValueOrDefault());
			if (persoon == null)
			{
				return HttpNotFound();
			}

			return View(persoon);
		}

        // GET: Persoon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persoon/Create
        [HttpPost]
        public ActionResult Create(PersoonModel persoon)
        {
			if (ModelState.IsValid)
			{
				rep.Add(persoon);

				return RedirectToAction("Index");
			};

			return View(persoon);
		}

		// GET: Persoon/Edit/5
		public ActionResult Edit(Guid? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PersoonModel persoon = rep.Fetch(id.GetValueOrDefault());
			if (persoon == null)
			{
				return HttpNotFound();
			}

			return View(persoon);
		}

        // POST: Persoon/Edit/5
        [HttpPost]
        public ActionResult Edit(PersoonModel persoon)
        {
			if (ModelState.IsValid)
			{
				persoon=rep.Update(persoon);

				return RedirectToAction("Index");
			};
			return View(persoon);
		}

		// GET: Persoon/Delete/5
		public ActionResult Delete(Guid? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PersoonModel persoon = rep.Fetch(id.GetValueOrDefault());
			if (persoon == null)
			{
				return HttpNotFound();
			}

			return View(persoon);
		}

		// POST: Persoon/Delete/5
		[HttpPost]
		public ActionResult Delete(Guid id)
		{
			rep.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
