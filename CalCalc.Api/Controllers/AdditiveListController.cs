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
    public class AdditiveListController:Controller
    {
        private CalCalcDbContext _dbContext;

        public AdditiveListController(CalCalcDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<AdditiveList> Get()
        {
            return _dbContext.AdditiveList.ToList();
        }
    }
}
