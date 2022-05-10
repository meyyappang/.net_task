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
    public class EmployeeController : ControllerBase
    {
        private readonly CRUDContext _CRUDContext;

        public EmployeeController(CRUDContext CRUDContext)
        {

            _CRUDContext = CRUDContext;

        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _CRUDContext.Employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _CRUDContext.Employees.SingleOrDefault(x => x.EmployeeId == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _CRUDContext.Employees.Add(employee);
            _CRUDContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            employee.EmployeeId = id;
            _CRUDContext.Employees.Update(employee);
            _CRUDContext.SaveChanges();

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if(item != null)
            {
                _CRUDContext.Employees.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
