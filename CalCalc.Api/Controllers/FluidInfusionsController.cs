using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalCalc.Api.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CalCalc.Api.Controllers
{
    [Route("api/[controller]")]
    public class FluidInfusionsController : Controller
    {
        private CalCalcDbContext _dbContext;

        public FluidInfusionsController(CalCalcDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<FluidInfusion> Get()
        {
            return _dbContext.FluidInfusion.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var fluidInfusion = _dbContext.FluidInfusion.Where(s => s.Id == id).FirstOrDefault();
            return Json(fluidInfusion);
        }

        // POST api/FluidInfusions
        [HttpPost]
        public JsonResult Post([FromBody]FluidInfusion fluidInfusion)
        {
            if (fluidInfusion != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(fluidInfusion).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(fluidInfusion);
                }
            }
            return Json("Not saved");

        }

    
        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]FluidInfusion fluidInfusion)
        {
            _dbContext.Entry(fluidInfusion).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(fluidInfusion);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var fluidInfusion = _dbContext.FluidInfusion.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.FluidInfusion.Remove(fluidInfusion);
            _dbContext.SaveChanges();
        }
    }
}
