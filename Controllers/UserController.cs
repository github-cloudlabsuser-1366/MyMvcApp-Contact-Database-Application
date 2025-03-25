using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

    // GET: User
    public ActionResult Index()
    {
        // Muestra la lista de usuarios
        return View(userlist);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Devuelve un error 404 si no se encuentra el usuario
        }
        return View(user); // Muestra los detalles del usuario
    }

    // GET: User/Create
    public ActionResult Create()
    {
        // Muestra el formulario para crear un nuevo usuario
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
      
            // Agrega el nuevo usuario a la lista
            user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1; // Genera un nuevo ID
            userlist.Add(user);
            return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios
        
        //        return View(user); // Si hay errores de validación, vuelve a mostrar el formulario
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Devuelve un error 404 si no se encuentra el usuario
        }
        return View(user); // Muestra el formulario para editar el usuario
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {

            // Busca el usuario existente por ID
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra el usuario
            }

            // Actualiza los datos del usuario
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;

            return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios
        //}
       // return View(user); // Si hay errores de validación, vuelve a mostrar el formulario
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Devuelve un error 404 si no se encuentra el usuario
        }
        return View(user); // Muestra la confirmación para eliminar el usuario
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Devuelve un error 404 si no se encuentra el usuario
        }

        // Elimina el usuario de la lista
        userlist.Remove(user);
        return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios
    }
}