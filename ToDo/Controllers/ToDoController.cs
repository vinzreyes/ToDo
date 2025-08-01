using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;
using System.Linq;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ToDoIndexViewModel
            {
                ToDoList = _context.ToDos.ToList(),
                NewToDo = new Models.ToDo()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.ToDo newToDo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDos.Add(newToDo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            var model = new ToDoIndexViewModel
            {
                ToDoList = _context.ToDos.ToList(),
                NewToDo = newToDo
            };
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ToDo.Models.ToDo toDo)
        {
            if (id != toDo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.ToDos.Update(toDo);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var toDos = _context.ToDos.FirstOrDefault(x => x.Id == id);
            if (toDos == null)
            {
                return NotFound();
            }

            return View(toDos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var toDos = _context.ToDos.FirstOrDefault(x => x.Id == id);
            if (toDos != null)
            {
                _context.ToDos.Remove(toDos);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
