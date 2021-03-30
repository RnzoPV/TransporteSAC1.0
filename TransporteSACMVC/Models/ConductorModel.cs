using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace TransporteSACMVC.Models
{
    public class ConductorModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Display(Name = "Ape. Paterno")]
        [StringLength(30)]
        public string ape_pat { get; set; }
        [Display(Name = "Ape. Materno")]
        [StringLength(30)]
        public string ape_mat { get; set; }
        [Display(Name = "Telefono")]
        [StringLength(11)]
        public string Telefono { get; set; }
    }
}