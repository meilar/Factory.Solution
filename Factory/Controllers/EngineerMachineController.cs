using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class EngineerMachineController : Controller
    {
      private readonly FactoryContext _db;
      public EngineerMachineController(FactoryContext db)
      {
        _db = db;
      }
      [HttpPost]
      public ActionResult Edit(int EngineerId, int MachineId)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = MachineId });
        _db.SaveChanges();
        return RedirectToAction("Details", "Home");
      }
    }
}