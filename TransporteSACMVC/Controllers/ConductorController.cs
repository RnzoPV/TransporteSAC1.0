using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TransporteSACMVC.Models;
using TransporteSACMVC.Entities;
using TransporteSACMVC.Utils;
using TransporteSACMVC.Services;
using TransporteSACMVC.Services.Impl;

namespace TransporteSACMVC.Controllers
{
    public class ConductorController : Controller
    {


        ConductorServiceImpl conductorService = new ConductorServiceImpl();

        // GET: Conductor
        public ActionResult Index()
        { 
            return View(conductorService.getAllConductor());
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