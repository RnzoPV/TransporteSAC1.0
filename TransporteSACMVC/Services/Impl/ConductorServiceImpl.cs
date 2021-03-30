using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransporteSACMVC.Models;
using TransporteSACMVC.Entities;
using TransporteSACMVC.Utils;

namespace TransporteSACMVC.Services.Impl
{
    public  class ConductorServiceImpl : IConductorService
    {
        public  IEnumerable<ConductorModel> getAllConductor()
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
    }
}