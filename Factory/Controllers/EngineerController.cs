using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class EngineerController : Controller
    {
      private readonly FactoryContext _db;
      public EngineerController(FactoryContext db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        ViewBag.Engineers = _db.Engineers.ToList();
        return View();
      }
      public ActionResult Create()
      {
        ViewBag.Machines = _db.Machines.ToList();
        ViewBag.Engineers = _db.Engineers.ToList();
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
        return View();
      }
    }
}