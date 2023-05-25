using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca_De_Clases;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessLeaderController : ControllerBase
    {
        private readonly dbContext _context;

        public BusinessLeaderController(dbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessLeader
        //[HttpGet]
        //public ActionResult<int> Getplaneta()
        //{
        //  if (_context.planeta == null)
        //  {
        //      return NotFound();
        //  }
        //    return _context.planeta.ToListAsync();
        //}
    }
}
