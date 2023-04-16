using Microsoft.AspNetCore.Mvc;
using CRUD.Datos;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class SuperHomeController : Controller
    {
        ContactoDatos _ContactoDatos= new ContactoDatos();
        public IActionResult Listar()
        {
            //La vista Mostrara una lista de contactos 

            var lista = _ContactoDatos.Listar();
            return View(lista);
        }

        public IActionResult Guardar()
        {
            // Metdodo solo devuelve las vista 
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //metodo recibe el objeto para guardar en db 

            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Editar(int Idcontacto)
        {

            // Metdodo solo devuelve las vista
            var ocotacto = _ContactoDatos.Obtener(Idcontacto);
            return View(ocotacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Eliminar(int Idcontacto)
        {

            // Metdodo solo devuelve las vista
            var ocotacto = _ContactoDatos.Obtener(Idcontacto);
            return View(ocotacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

           
            var respuesta = _ContactoDatos.Delete(oContacto.IdContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
