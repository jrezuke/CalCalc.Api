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
    public class EnteralsController : Controller
    {
        private CalCalcDbContext _dbContext;

        public EnteralsController(CalCalcDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Enteral> Get()
        {
            return _dbContext.Enteral.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var enteral = _dbContext.Enteral.Where(s => s.Id == id).FirstOrDefault();
            return Json(enteral);
        }

        // POST api/enterals
        [HttpPost]
        public JsonResult Post([FromBody]Enteral enteral)
        {
            if (enteral != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(enteral).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(enteral);
                }
            }
            return Json("Not saved");

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Enteral enteral)
        {
            _dbContext.Entry(enteral).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(enteral);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var enteral = _dbContext.Enteral.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Enteral.Remove(enteral);
            _dbContext.SaveChanges();
        }
    }
}
