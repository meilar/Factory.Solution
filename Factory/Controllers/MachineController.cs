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

      public static List<Engineer> GetEngineers(ICollection<EngineerMachine> joinEntities)
      {
        List<Engineer> engineers = new List<Engineer>();
        foreach(EngineerMachine join in joinEntities)
        {
          int id = join.EngineerId;
          Engineer thisEngineer = MachineController._db.Engineers.FirstOrDefault(e => e.EngineerId == id);
          engineers.Add(thisEngineer);
        }
        return engineers;
      }

    }
}