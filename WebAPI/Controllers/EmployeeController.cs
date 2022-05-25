using EmployeeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDBEntities entities = new EmployeeDBEntities();

        public IEnumerable<Employee> Get()
        {
            return entities.Employees.ToList();
        }
        public HttpResponseMessage Get(int id)
        {
            var entity = entities.Employees.FirstOrDefault(e => e.empId == id);
            if(entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Id  : "+id+" not found.");
            }
        }

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.Created, employee);
                msg.Headers.Location = new Uri(Request.RequestUri +"/"+ employee.empId.ToString());
                return msg;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            
        }
        public HttpResponseMessage Put(int id,[FromBody] Employee employee)
        {
            var entity = entities.Employees.FirstOrDefault(e => e.empId == id);
            try
            {
                if (entity != null)
                {
                    entity.empName = employee.empName;
                    entity.DOJ = employee.DOJ;
                    entity.designation = employee.designation;
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Id : " + id + " updated successfully!!!.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Id : " + id + " not found to update.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            var entity = entities.Employees.FirstOrDefault(e => e.empId == id);
            try
            {
                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Id : " + id + " not found.");
                }
                else
                {
                    entities.Employees.Remove(entity);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee ID : " + id + " gets deleted successfully.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            
            
        }
    }
}
