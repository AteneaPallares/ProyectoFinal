using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Proyect.Models;
using Proyect.Models.AccountViewModels;
using Proyect.Services;
using Proyect;
using Proyect.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Proyect.Data;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApiClient;
namespace Proyect.Controllers
{
    [Authorize]
    public class ComprarController : Controller
    {
          private UserManager<ApplicationUser> _userManager { get; }
        private readonly ApplicationDbContext _context;

        public ComprarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _userManager = userManager;

            _context = context;



        }
        
           public async Task<IActionResult> Index(ProyectViewModel dato,string opcion)
        {         
            var user = await _userManager.GetUserAsync(User);
            if(user.Id!=null){
                HomeController.activado=true;
            }
            else{
                HomeController.activado=false;
            }
             foreach(var mi in _context.Users){
                 if(mi.Id==user.Id){
                     float mu=(float)mi.Efectivo;
                        HomeController.dinero=mu;
                 }
                }
            var y=WebApiClient.Program.ProcessRepositories(opcion).Result;
            if(y.items==null){
                ViewBag.error=true;
            }
            else{
                ViewBag.error=false;
            }
            ViewBag.lista=y;
            var d =y;
          return View();
        }
        public async Task<IActionResult> Opcion(){
            var user = await _userManager.GetUserAsync(User);
             if(user.Id!=null){
                HomeController.activado=true;
            }
            else{
                HomeController.activado=false;
            }
             foreach(var mi in _context.Users){
                 if(mi.Id==user.Id){
                     float mu=(float)mi.Efectivo;
                        HomeController.dinero=mu;
                 }
                }
            return View();
        }
         public async Task<IActionResult>  Comprado(Ropa m)
        {
            var user = await _userManager.GetUserAsync(User);
             if(user.Id!=null){
                HomeController.activado=true;
            }
            else{
                HomeController.activado=false;
            }
            m.OwnerId = new Guid(user.Id);
            _context.Prenda.Add(m);
            _context.SaveChanges();
            foreach(var d in _context.Users){
                if(d.Id==m.OwnerId.ToString()){
                    if(d.Efectivo-m.precio>0){
                        float x=(float)m.precio;
                        d.Efectivo=d.Efectivo-x;
                        float y=(float)d.Efectivo;
                        HomeController.dinero=y;
                        _context.SaveChanges();
                        ViewBag.comprar=true;
                        ViewBag.lista=_context.Prenda;
                    }
                    else{
                        ViewBag.comprar=false;
                    }
                }
            }
            ViewBag.identidad=new Guid(user.Id);
            
            return View();
            
        }
        public async Task<IActionResult>  MisCompras(){
             var user = await _userManager.GetUserAsync(User);
              if(user.Id!=null){
                HomeController.activado=true;
            }
            else{
                HomeController.activado=false;
            }
             ViewBag.lista=_context.Prenda;
             ViewBag.identidad=new Guid(user.Id);
             return View();
        }


    }

}