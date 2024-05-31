using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcDemo4.BL.Interface;
using MvcDemo4.DAL.Database;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer db;

        public EmployeeRep(DbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> Get()
        {
           var data =  db.Employee.Include("Department").Select(a => a);
            return data;

        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
        public void Create(Employee obj)
        {
           
            
            db.Employee.Add(obj);
            db.SaveChanges();
        }
        public void Edit(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Employee obj)
        {
            db.Entry(obj).State= EntityState.Deleted;
            db.SaveChanges();
        }

        public IEnumerable<Employee> SearchByName(string name)
        {
             var data = db.Employee.Where(a=>a.Name.Contains(name)).Select(a => a);
            return data;
        }
    }
}
