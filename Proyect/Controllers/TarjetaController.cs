using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyect.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Proyect.Data;
namespace Proyect.Controllers

{
    [Authorize]
    public class TarjetaController : Controller

    {
        private UserManager<ApplicationUser> _userManager { get; }
        /// Aquí usamamos DI para obtener el DbContext
        private readonly ApplicationDbContext _context;
        /// Aquí usamamos DI para obtener el DbContext
        public TarjetaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            _context = context;
        }

        public IActionResult Index()

        {

            return View();

        }



        public async Task<IActionResult>  Validar(string tarjetanum,string cantidad)

        {
            double dato=Convert.ToDouble(cantidad);
            float valor=(float)dato;
             Tarjeta tarjeta = new Tarjeta(tarjetanum);
            var user = await _userManager.GetUserAsync(User);
             if(user.Id!=null){
                HomeController.activado=true;
            }
            else{
                HomeController.activado=false;
            }
             foreach(var mi in _context.Users){
                 if(mi.Id==user.Id){
                     if(tarjeta.Valida==true){
                         mi.Efectivo=mi.Efectivo+valor;
                         float valores=(float)mi.Efectivo;
                         HomeController.dinero=valores;
                         _context.SaveChanges();
                         ViewBag.agregado=true;
                         break;
                     }
                     else{
                         ViewBag.agregado=false;
                     }
                 }
                }

           
            
            return View();

        }





        public IActionResult Error()

        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

    }

}