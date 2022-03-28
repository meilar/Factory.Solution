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
      public ActionResult AddEngineer()
      {
        ViewBag.Machines = _db.Machines.ToList();
        ViewBag.Engineers = _db.Engineers.ToList();
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
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
    public ActionResult Edit(int id)
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      ViewBag.Engineers = _db.Engineers.ToList();
      var thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine m, int EngineerId)
    {
      _db.Entry(m).State = EntityState.Modified;
      _db.SaveChanges();
      if(EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = m.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new {id = m.MachineId});
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult RemoveEngineer(int id)
    {
      var thisJoin = _db.EngineerMachine.FirstOrDefault(engineerMachine => engineerMachine.EngineerMachineId == id);
      _db.EngineerMachine.Remove(thisJoin);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}