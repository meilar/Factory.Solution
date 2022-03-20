using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class MachineController : Controller
    {
      private readonly FactoryContext _db;
      public MachineController(FactoryContext db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        ViewBag.Machines = _db.Machines.ToList();
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
      [HttpPost]
      public ActionResult Create(Machine machine, int EngineerId)
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        if(EngineerId != 0)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId});
          _db.SaveChanges();
        }
        return RedirectToAction("Details", new {id = machine.MachineId});
      }

    public ActionResult Details(int id)
    {
      ViewBag.Engineers = _db.Engineers.ToList();
      var thisMachine = _db.Machines
        .Include(machine => machine.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
    }
}