using EmployeeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDBEntities entities = new EmployeeDBEntities();
            var emplist = entities.Employees.ToList();
            foreach (var item in emplist)
            {
                Console.WriteLine(item.empId+" "+item.empName+" "+item.designation+" "+item.DOJ);
            }
            Console.Read();
        }
    }
}
