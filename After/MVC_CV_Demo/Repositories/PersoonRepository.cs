using MVC_CV_Demo;
using MVC_CV_Demo_Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CV_Demo_Data.Repositories
{
    public class PersoonRepository
    {
        public PersoonModel Add(PersoonModel model)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Guid newId = Guid.NewGuid();

                Persoon entity = new Persoon
                {
                    PersoonId=newId,
                    Naam=model.Naam,
                    Voornaam=model.Voornaam,
                    Voorvoegsels=model.Voorvoegsels
                };

                entities.Persoon.Add(entity);

                int recordsAffected = entities.SaveChanges();
                if (recordsAffected != 1) return null;

                model.PersoonId = newId;

                return model;
            }
        }

        public PersoonModel Update(PersoonModel model)
        {

            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Persoon entity = entities.Persoon.FirstOrDefault(w => w.PersoonId == model.PersoonId);
                if (entity == null) return null;

                entity.Naam = model.Naam;
                entity.Voornaam = model.Voornaam;
                entity.Voorvoegsels = model.Voorvoegsels;

                int recordsAffected = entities.SaveChanges();
                return recordsAffected == 1 ? Fetch(model.PersoonId) : null;
            }
        }

        public bool Delete(Guid persoonId)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                Persoon entity = entities.Persoon.First(w => w.PersoonId == persoonId);
                entities.Persoon.Remove(entity);

                int recordsAffected = entities.SaveChanges();
                return recordsAffected == 1;
            }
        }
        public PersoonModel Fetch(Guid persoonId)
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                IQueryable<Persoon> cvitems = entities.Persoon.Where(w => w.PersoonId == persoonId);

                IQueryable<PersoonModel> result = cvitems.Select(
                    model => new PersoonModel
                    {
                        PersoonId = model.PersoonId,
                        Naam = model.Naam,
                        Voornaam = model.Voornaam,
                        Voorvoegsels = model.Voorvoegsels
                    }
                );

                return result.FirstOrDefault();
            }
        }

        public List<PersoonModel> GetAll()
        {
            using (MVC_CV_DemoEntities entities = new MVC_CV_DemoEntities())
            {
                return entities.Persoon.Select(
                                    model => new PersoonModel
                                    {
                                        PersoonId = model.PersoonId,
                                        Naam = model.Naam,
                                        Voornaam = model.Voornaam,
                                        Voorvoegsels = model.Voorvoegsels
                                    }
                                ).ToList();
            }
        }
    }
}
