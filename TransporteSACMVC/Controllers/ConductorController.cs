using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TransporteSACMVC.Models;
using TransporteSACMVC.Entities;
using TransporteSACMVC.Servicio;

namespace TransporteSACMVC.Controllers
{
    public class ConductorController : Controller
    {

        IEnumerable<ConductorModel> getAll()
        {
            List<Conductor> conductors;
            List<ConductorModel> conductorModels = new List<ConductorModel>();
            using (TransporteSACDBEntities db = new TransporteSACDBEntities())
            {
                conductors = db.Conductor.ToList();
                /*conductors = (from c in db.Conductor select new ConductorModel{ 
                    Id = c.id,
                    Nombre = c.nombre,
                    ape_pat = c.ape_pat,
                    ape_mat = c.ape_mat,
                    Telefono = c.telefono
                }).ToList();*/
            }
            foreach (Conductor conductorE in conductors)
            {
                ConductorModel conductorM = Converter.entity2model(conductorE);
                conductorModels.Add(conductorM);
            }
            return conductorModels;
        }

        // GET: Conductor
        public ActionResult Index()
        { 
            return View(getAll());
        }
        public ActionResult createConductor()
        {
            return View(new ConductorModel());
        }
        [HttpPost]
        public ActionResult createConductor(ConductorModel conductor)
        {
            if(ModelState.IsValid){
                using (TransporteSACDBEntities db = new TransporteSACDBEntities())
                {
                    db.Conductor.Add(Converter.model2enity(conductor));
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(conductor); 
        }
        public ActionResult updateConductor(int id)
        {

            Conductor conductorE;
            using (TransporteSACDBEntities db = new TransporteSACDBEntities())
            {
                 conductorE = db.Conductor.Find(id);
            }
            ConductorModel conductorM = Converter.entity2model(conductorE);
            return View(conductorM);

        }
        [HttpPost]
        public ActionResult updateConductor(ConductorModel conductorModel)
        {
        if (ModelState.IsValid)
        {
            Conductor conductorE = Converter.model2enity(conductorModel);
            using (TransporteSACDBEntities db = new TransporteSACDBEntities()) {
                db.Entry(conductorE).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
                return RedirectToAction("Index");
            }
            return View(conductorModel);
        }
        [HttpGet]
        public ActionResult deleteConductor(int id)
        {
            using (TransporteSACDBEntities db = new TransporteSACDBEntities())
            {
                var conductor = db.Conductor.Find(id);
                db.Entry(conductor).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }
        public ActionResult detailConductor(int id)
        {
            Conductor conductorE;
            using (TransporteSACDBEntities db = new TransporteSACDBEntities())
            {
                conductorE = db.Conductor.Find(id);
            }
            ConductorModel conductorM = Converter.entity2model(conductorE);
            return View(conductorM);
        }
    }
}