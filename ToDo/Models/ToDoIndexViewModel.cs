// Path: ViewModels/ToDoIndexViewModel.cs
using System.Collections.Generic;

namespace ToDo.Models      // <-- MUST match your Razor @model directive
{
    public class ToDoIndexViewModel
    {
        public IEnumerable<ToDo> ToDoList { get; set; }
            = new List<ToDo>();

        public ToDo NewToDo { get; set; }
            = new ToDo();
    }
}
