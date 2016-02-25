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
    public class BedrijfController : Controller
    {
		private BedrijfRepository rep = new BedrijfRepository();
		// GET: Bedrijf
		public ActionResult Index()
        {
			List<BedrijfModel> bedrijven = rep.GetAll();
			return View(bedrijven);
		}

		[Route("Bedrijf/Details/{id:Guid}")]
		// GET: Bedrijf/Details/5
		public ActionResult Details(Guid id)
        {

			BedrijfModel bedrijf = rep.Fetch(id);
			if (bedrijf == null)
			{
				return HttpNotFound();
			}

			return View(bedrijf);
		}

        // GET: Bedrijf/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bedrijf/Create
        [HttpPost]
        public ActionResult Create(BedrijfModel bedrijf)
        {
			if (ModelState.IsValid)
			{
				rep.Add(bedrijf);

				return RedirectToAction("Index");
			};

			return View(bedrijf);
		}

        // GET: Bedrijf/Edit/5
        public ActionResult Edit(Guid id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BedrijfModel bedrijf = rep.Fetch(id);
			if (bedrijf == null)
			{
				return HttpNotFound();
			}

			return View(bedrijf);
		}

        // POST: Bedrijf/Edit/5
        [HttpPost]
        public ActionResult Edit(BedrijfModel bedrijf)
        {
			if (ModelState.IsValid)
			{
				rep.Update(bedrijf);

				return RedirectToAction("Index");
			};
			return View(bedrijf);
		}

        // GET: Bedrijf/Delete/5
        public ActionResult Delete(Guid? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BedrijfModel bedrijf = rep.Fetch(id.GetValueOrDefault());
			if (bedrijf == null)
			{
				return HttpNotFound();
			}

			return View(bedrijf);
		}

        // POST: Bedrijf/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
			rep.Delete(id);
			return RedirectToAction("Index");
		}

		[Route("Bedrijf/Details/{naam}")]
		public ActionResult Details(string naam)
		{
			if (naam == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			BedrijfModel bedrijf = rep.ZoekOpNaam(naam);
			if (bedrijf == null)
			{
				return HttpNotFound();
			}

			return View(bedrijf);
		}
	}
}
