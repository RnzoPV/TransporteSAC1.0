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
            try
            {
                return View(conductorService.getAllConductor());
            }
            catch (Exception e)
            {

                throw new Exception( e.ToString());
            }
           
        }
        public ActionResult createConductor()
        {
            try
            {
                return View(new ConductorModel());
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
            
        }
        [HttpPost]
        public ActionResult createConductor(ConductorModel conductor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TransporteSACDBEntities db = new TransporteSACDBEntities())
                    {
                        db.Conductor.Add(Converter.model2enity(conductor));
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(conductor);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.ToString());
            }

        }
        public ActionResult updateConductor(int id)
        {
            try
            {
                Conductor conductorE;
                using (TransporteSACDBEntities db = new TransporteSACDBEntities())
                {
                    conductorE = db.Conductor.Find(id);
                }
                ConductorModel conductorM = Converter.entity2model(conductorE);
                return View(conductorM);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }


        }
        [HttpPost]
        public ActionResult updateConductor(ConductorModel conductorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Conductor conductorE = Converter.model2enity(conductorModel);
                    using (TransporteSACDBEntities db = new TransporteSACDBEntities())
                    {
                        db.Entry(conductorE).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(conductorModel);
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
       
        }
        [HttpGet]
        public ActionResult deleteConductor(int id)
        {
            try
            {
                using (TransporteSACDBEntities db = new TransporteSACDBEntities())
                {
                    var conductor = db.Conductor.Find(id);
                    db.Entry(conductor).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
           
        }
        public ActionResult detailConductor(int id)
        {
            try
            {
                Conductor conductorE;
                using (TransporteSACDBEntities db = new TransporteSACDBEntities())
                {
                    conductorE = db.Conductor.Find(id);
                }
                ConductorModel conductorM = Converter.entity2model(conductorE);
                return View(conductorM);
            }
            catch (Exception e)
            {

                throw new Exception( e.ToString());
            }

        }
    }
}