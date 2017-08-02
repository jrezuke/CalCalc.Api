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
    public class FormulasController : Controller
    {
        private CalCalcDbContext _dbContext;

        public FormulasController(CalCalcDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IEnumerable<FormulaList> Get()
        {
            return _dbContext.FormulaList.ToList();
        }
    }
}