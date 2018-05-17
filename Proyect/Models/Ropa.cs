using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Proyect.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Ropa
    {

        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double precio { get; set; }
        public int id_del_producto { get; set; }
        public string Tamano { get; set; }
        public Guid OwnerId { get; set; }
        public Guid id { get; set; }
        public DateTimeOffset? Comprada { get; set; }
        public string imagen { get; set; }
        public Ropa()
        {
            id = Guid.NewGuid();

            Comprada = DateTimeOffset.Now;


        }

    }
}