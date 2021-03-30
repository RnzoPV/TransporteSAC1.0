using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TransporteSACMVC.Entities;
using TransporteSACMVC.Models;

namespace TransporteSACMVC.Servicio
{
    public static class Converter
    {
        public static ConductorModel entity2model(Conductor conductorEntity) {
            ConductorModel conductorModel = new ConductorModel();
            conductorModel.Id = conductorEntity.id;
            conductorModel.Nombre = conductorEntity.nombre;
            conductorModel.ape_pat = conductorEntity.ape_pat;
            conductorModel.ape_mat = conductorEntity.ape_mat;
            conductorModel.Telefono = conductorEntity.telefono;
            return conductorModel;
        }
        public static Conductor model2enity(ConductorModel conductorModel)
        {
            Conductor conductorEntity = new Conductor();
            conductorEntity.id  = conductorModel.Id;
            conductorEntity.nombre = conductorModel.Nombre;
            conductorEntity.ape_pat = conductorModel.ape_pat;
            conductorEntity.ape_mat = conductorModel.ape_mat;
            conductorEntity.telefono = conductorModel.Telefono;
            return conductorEntity;
        }
    }
}