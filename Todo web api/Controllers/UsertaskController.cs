using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_web_api.Context;
using Todo_web_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsertaskController : ControllerBase


    {
        private readonly CRUDContext _CRUDContext;

        public UsertaskController(CRUDContext CRUDContext)
        {

            _CRUDContext = CRUDContext;

        }


        // GET: api/<UsertaskController>
        [HttpGet]
        public IEnumerable<Usertask> Get()
        {
            return _CRUDContext.Usertasks;
        }

        // GET api/<UsertaskController>/5
        [HttpGet("{id}")]
        public Usertask Get(int id)
        {
            return _CRUDContext.Usertasks.SingleOrDefault(x => x.Task_id == id);
        }

        // POST api/<UsertaskController>
        [HttpPost]
        public void Post([FromBody] Usertask usertask)
        {

            _CRUDContext.Usertasks.Add(usertask);
            _CRUDContext.SaveChanges();
        }

        // PUT api/<UsertaskController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Usertask usertask)
        {
            _CRUDContext.Usertasks.Update(usertask);
            _CRUDContext.SaveChanges();

        }

        // DELETE api/<UsertaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Usertasks.FirstOrDefault(x => x.Task_id == id);
            if (item != null)
            {
                _CRUDContext.Usertasks.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
