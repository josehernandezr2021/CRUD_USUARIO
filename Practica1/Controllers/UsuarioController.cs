using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practica1.Models;

namespace Practica1.Controllers
{
    public class UsuarioController : Controller
    {
        //El Static es para guardar datops de manera que se esta ejecutando
        static List<UsuarioViewModel> usuarios = new List<UsuarioViewModel>()
        {
        new UsuarioViewModel() {Id=1,Nombre="Jose", Correo="Jose@gmail.com", Usuario="Jose"},
        new UsuarioViewModel() {Id=2,Nombre="Andres", Correo="Andres@gmail.com", Usuario="Andres"},
        new UsuarioViewModel() {Id=3,Nombre="Francisco", Correo="Francisco@gmail.com", Usuario="Francisco"}

        };
        //Constructor
        public UsuarioController() 
            {
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Detalle(int id)
        {
            UsuarioViewModel u = ObtenerUsuario(id);
            return View(u);
        }

        // GET: UsuarioController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(UsuarioViewModel user)
        {
            try
            {
                //Calcular el id, hayt que ocultar desde la vista el la columna id
                user.Id = calcularId();
                usuarios.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int calcularId()
        {
            //Sumar el id
            return usuarios.Select(s => s.Id).Max()+1;
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Editar (int id, UsuarioViewModel user)
        {
            UsuarioViewModel u = ObtenerUsuario(id);
            return View(u);
        }

        private UsuarioViewModel ObtenerUsuario(int id)
        {
            return usuarios.FirstOrDefault(f => f.Id == id);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioViewModel user)
        {
            try
            {
                UsuarioViewModel u = ObtenerUsuario(id);
                u.Nombre = user.Nombre;
                u.Correo = user.Correo;
                u.Usuario = user.Usuario;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UsuarioViewModel u = ObtenerUsuario(id);
                usuarios.Remove(u);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }
           
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public class usuarios
    {
    }
}
