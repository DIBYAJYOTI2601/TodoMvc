using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult TodoList()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(Todo newTask)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(newTask);
                _context.SaveChanges();
                return RedirectToAction("TodoList");
            }

            return View(newTask);
        }

        [HttpGet]
        public IActionResult UpdateTask(int Id)
        {
            var todo = _context.Todos.Find(Id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }
        [HttpPost]
        public IActionResult UpdateTask(Todo todo,int Id)
        {
            if(Id!=todo.TodoId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Todos.Update(todo);
                _context.SaveChanges();
                return RedirectToAction("TodoList");
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult DeleteTask(int Id)
        {
            var todo = _context.Todos.Find(Id);
            if (todo == null) {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("TodoList");
        }
        
       
        

    }
}
