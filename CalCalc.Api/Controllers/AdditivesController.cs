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
    public class AdditivesController : Controller
    {
     private CalCalcDbContext _dbContext;

        public AdditivesController(CalCalcDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Additive> Get()
        {
            return _dbContext.Additive.ToList();
        } 

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var additive = _dbContext.Additive.Where(s => s.Id == id).FirstOrDefault();
            return Json(additive);
        }

        // POST api/additives
        [HttpPost]
        public JsonResult Post([FromBody]Additive additive)
        {
            if (additive != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(additive).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(additive);
                }
            }
            return Json("Not saved");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Additive additive)
        {
            _dbContext.Entry(additive).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(additive);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var additive = _dbContext.Additive.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Additive.Remove(additive);
            _dbContext.SaveChanges();
        }
    }
}