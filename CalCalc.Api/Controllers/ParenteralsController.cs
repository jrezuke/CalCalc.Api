using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalCalc.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CalCalc.Api.Controllers
{
    [Route("api/[controller]")]
    public class ParenteralsController : Controller
    {
        private CalCalcDbContext _dbContext;

        public ParenteralsController(CalCalcDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IEnumerable<Parenteral> Get()
        {
            return _dbContext.Parenteral.ToList();
        }

        [HttpPost]
        public JsonResult Post([FromBody]Parenteral parenteral)
        {
            if (parenteral != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(parenteral).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(parenteral);
                }
            }
            return Json("Not saved");

        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Parenteral parenteral)
        {
            _dbContext.Entry(parenteral).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(parenteral);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var parenteral = _dbContext.Parenteral.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Parenteral.Remove(parenteral);
            _dbContext.SaveChanges();
        }

    }
}