using Microsoft.AspNetCore.Mvc;
using myeasytime.Data;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myEasyTime.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {

        DataContext dataContext;
        public ApiController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("GetConges")]
        public IActionResult GetConges()
        {
            var conges = dataContext.Conges.ToList();

            return Json(conges);
        }
        
        [HttpGet]
        [Route("GetDemandesConges")]
        public IActionResult GetDemandesConges()
        {
            var demandesconges = dataContext.DemandesConges.ToList();

            return Json(demandesconges);
        }
    }
}
