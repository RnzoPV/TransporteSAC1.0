using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransporteSACMVC.Models;
using TransporteSACMVC.Entities;

namespace TransporteSACMVC.Services
{
     interface IConductorService
    {
         IEnumerable<ConductorModel> getAllConductor();
    }
}
