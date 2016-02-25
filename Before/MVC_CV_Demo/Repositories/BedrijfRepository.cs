using MVC_CV_Demo;
using MVC_CV_Demo_Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CV_Demo_Data.Repositories
{
    public class BedrijfRepository
    {
        public BedrijfModel Add(BedrijfModel model)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Guid newId = Guid.NewGuid();

                Bedrijf entity = new Bedrijf
                {
                    BedrijfsId = newId,
                    Bedrijfsnaam = model.Bedrijfsnaam
                };

                entities.Bedrijf.Add(entity);

                int recordsAffected = entities.SaveChanges();
                if (recordsAffected != 1) return null;

                model.BedrijfsId = newId;

                return model;
            }
        }

        public BedrijfModel Update(BedrijfModel model)
        {

            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Bedrijf entity = entities.Bedrijf.FirstOrDefault(w => w.BedrijfsId == model.BedrijfsId);
                if (entity == null) return null;

                entity.Bedrijfsnaam = model.Bedrijfsnaam;

                int recordsAffected = entities.SaveChanges();
                return recordsAffected == 1 ? Fetch(model.BedrijfsId) : null;
            }
        }

        public bool Delete(Guid bedrijfsId)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Bedrijf entity = entities.Bedrijf.First(w => w.BedrijfsId == bedrijfsId);
                entities.Bedrijf.Remove(entity);

                int recordsAffected = entities.SaveChanges();
                return recordsAffected == 1;
            }
        }

        public BedrijfModel Fetch(Guid bedrijfsId)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                IQueryable<Bedrijf> cvitems = entities.Bedrijf.Where(w => w.BedrijfsId == bedrijfsId);

                IQueryable<BedrijfModel> result = cvitems.Select(
                    model => new BedrijfModel
                    {
                        BedrijfsId = model.BedrijfsId,
                        Bedrijfsnaam = model.Bedrijfsnaam
                    }
                );

                return result.FirstOrDefault();
            }
        }

        public List<BedrijfModel> GetAll()
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                IQueryable<Bedrijf> cvitems = entities.Bedrijf;

                IQueryable<BedrijfModel> result = cvitems.Select(
                    model => new BedrijfModel
                    {
                        BedrijfsId = model.BedrijfsId,
                        Bedrijfsnaam = model.Bedrijfsnaam
                    }
                );

                return result.ToList();
            }
        }
    }
}
