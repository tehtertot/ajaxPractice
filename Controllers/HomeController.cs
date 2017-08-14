using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ajaxNotesTest.Factory;
using ajaxNotesTest.Models;

namespace ajaxNotesTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteFactory _notes;
        public HomeController(NoteFactory noteFactory) {
            _notes = noteFactory;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        [Route("/notes")]
        public JsonResult AllNotes() {
            List<Note> allNotes = _notes.FindAll();
            return Json(allNotes);
        }
    }
}
