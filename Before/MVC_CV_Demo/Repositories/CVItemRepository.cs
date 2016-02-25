using MVC_CV_Demo;
using MVC_CV_Demo_Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CV_Demo_Data.Repositories
{
    public class CVItemRepository
    {
        public CVItemModel Add(CVItemModel model)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Guid newId = Guid.NewGuid();

                CVItem entity = new CVItem
                {
                    CVItemId = newId,
                    PersoonID=model.PersoonID,
                    Functienaam=model.Functienaam,
                    PeriodeVan=model.PeriodeVan,
                    PeriodeTot=model.PeriodeTot,
                    Beschrijving=model.Beschrijving,
                    BedrijfsID=model.BedrijfsID
                };

                entities.CVItem.Add(entity);

                int recordsAffected = entities.SaveChanges();
                if (recordsAffected != 1) return null;

                model.CVItemId = newId;

                return model;
            }
        }

        public CVItemModel Update(CVItemModel model)
        {

            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                CVItem entity = entities.CVItem.FirstOrDefault(w => w.CVItemId == model.CVItemId);
                if (entity == null) return null;

                entity.PersoonID = model.PersoonID;
                entity.Functienaam = model.Functienaam;
                entity.PeriodeVan = model.PeriodeVan;
                entity.PeriodeTot = model.PeriodeTot;
                entity.Beschrijving = model.Beschrijving;
                entity.BedrijfsID = model.BedrijfsID;

                int recordsAffected = entities.SaveChanges();
                return recordsAffected == 1 ? Fetch(model.CVItemId) : null;
            }
        }

        public bool Delete(Guid cvitemId)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                CVItem entity = entities.CVItem.First(w => w.CVItemId == cvitemId);
                entities.CVItem.Remove(entity);

                int recordsAffected = entities.SaveChanges();
                return recordsAffected == 1;
            }
        }

        public CVItemModel Fetch(Guid cvitemId)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                IQueryable<CVItem> cvitems = entities.CVItem.Where(w => w.CVItemId == cvitemId);

                IQueryable<CVItemModel> result = cvitems.Select(
                    model => new CVItemModel
                    {
                        CVItemId = model.CVItemId,
                        PersoonID = model.PersoonID,
                        Functienaam = model.Functienaam,
                        PeriodeVan = model.PeriodeVan,
                        PeriodeTot = model.PeriodeTot,
                        Beschrijving = model.Beschrijving,
                        BedrijfsID = model.BedrijfsID
                    }
                );

                return result.FirstOrDefault();
            }
        }

        public List<CVItemModel> GetAll()
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                IQueryable<CVItem> cvitems = entities.CVItem;

                IQueryable<CVItemModel> result = cvitems.Select(model => new CVItemModel
                {
                    CVItemId = model.CVItemId,
                    PersoonID = model.PersoonID,
                    Functienaam = model.Functienaam,
                    PeriodeVan = model.PeriodeVan,
                    PeriodeTot = model.PeriodeTot,
                    Beschrijving = model.Beschrijving,
                    BedrijfsID = model.BedrijfsID
                }
                );

                return result.ToList();
            }
        }
    }
}
