using MVC_CV_Demo_Data.Repositories;
using MVC_CV_Demo_Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV_Demo_Web.Controllers
{
    public class CVItemController : Controller
    {
		private CVItemRepository rep = new CVItemRepository();
		private PersoonRepository persrep = new PersoonRepository();
		private BedrijfRepository bedrrep = new BedrijfRepository();
		// GET: CVItem
		public ActionResult Index()
        {
			List<CVItemModel> bedrijven = rep.GetAll();
			return View(bedrijven);
		}

        // GET: CVItem/Details/5
        public ActionResult Details(Guid id)
        {
			CVItemModel cvitem = rep.Fetch(id);
			if (cvitem == null)
			{
				return HttpNotFound();
			}

			return View(cvitem);
		}

		// GET: CVItem/Create
		public ActionResult Create()
		{
			ViewBag.PersoonID = new SelectList(persrep.GetAll(), "PersoonId", "Naam");
			ViewBag.BedrijfsId = new SelectList(bedrrep.GetAll(), "BedrijfsId", "Bedrijfsnaam");
			return View();
		}

		// POST: CVItem/Create
		[HttpPost]
		public ActionResult Create(CVItemModel cvitem)
		{

			if (ModelState.IsValid)
			{
				rep.Add(cvitem);

				return RedirectToAction("Index");
			};
			ViewBag.PersoonID = new SelectList(persrep.GetAll(), "PersoonId", "Naam");
			ViewBag.BedrijfsId = new SelectList(bedrrep.GetAll(), "BedrijfsId", "Bedrijfsnaam");
			return View(cvitem);
		}
		// GET: CVItem/Edit/5
		public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CVItem/Edit/5
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

        // GET: CVItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CVItem/Delete/5
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
