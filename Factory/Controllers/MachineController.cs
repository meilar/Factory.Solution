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
    }
}