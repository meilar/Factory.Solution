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

      public static Machine GetMachine(int id)
      {

        var thisMachine = _db.Machines
          .Include(machine => machine.JoinEntities)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(machine => machine.MachineId ==id);
        
        return thisMachine;
      }
    }
}