using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Proyect.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ProyectViewModel{
        public string nombre{ get; set; }
        public Guid id{get;set;}
        public bool comprado{get;set;}
    }
}