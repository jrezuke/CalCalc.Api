
using CalCalc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CalCalc.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalEntriesController : Controller
    {
        private CalCalcDbContext _dbContext;

        public CalEntriesController(CalCalcDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<CalEntry> Get()
        {
            return _dbContext.CalEntry.ToList();
        }

        [Route("GetBySubject/{id}", Name = "GetBySubject")]
        public IEnumerable<CalEntry> GetBySubject(int id)
        {
            return _dbContext.CalEntry.Where(s => s.SubjectId == id).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var entry = _dbContext.CalEntry.Where(c => c.Id == id).FirstOrDefault();
            return Json(entry);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] Models.CalEntry entry)
        {
            if(entry != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(entry).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(entry);
                }
            }
            return Json("Not saved");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]CalEntry entry)
        {
            _dbContext.Entry(entry).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(entry);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entry = _dbContext.CalEntry.Where(c => c.Id == id).FirstOrDefault();
            _dbContext.CalEntry.Remove(entry);
            _dbContext.SaveChanges();
        }
    }
}
