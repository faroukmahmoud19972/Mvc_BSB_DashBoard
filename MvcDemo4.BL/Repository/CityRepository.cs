using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemo4.BL.Interface;
using MvcDemo4.BL.Models;
using MvcDemo4.DAL.Database;
using MvcDemo4.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MvcDemo4.BL.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly DbContainer db;

        //DbContainer db = new DbContainer();
        public CityRepository(DbContainer db)
        {
            this.db = db;
        }
        
        public IEnumerable<City> Get(Expression<Func<City, bool>> filter = null)
        {
            

            if (filter==null)
            {
                var data = db.City.Select(a => a);
                return data;
            }
            else
            {
                return db.City.Where(filter);
            }
        }

        public City GetById(int id)
        {
            var data = db.City.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
      










        //public class DepartmentRep : IDepartmentRep
        //{
        //    private readonly DbContainer db;

        //    //DbContainer db = new DbContainer();
        //    public DepartmentRep(DbContainer db)
        //    {
        //        this.db = db;
        //    }

        //    public IEnumerable<DepartmentVM> Get()
        //    {
        //        var data = db.Department.Select(a => new DepartmentVM
        //        {
        //            Id = a.Id,
        //            Code = a.Code,
        //            Name = a.Name
        //        });
        //        return data;
        //    }

        //    public DepartmentVM GetById(int id)
        //    {
        //        var data = db.Department.Where(a => a.Id == id).Select(a => new DepartmentVM
        //        {
        //            Id = a.Id,
        //            Code = a.Code,
        //            Name = a.Name
        //        }).FirstOrDefault();
        //        return data;
        //    }
        //    public void Create(DepartmentVM obj)
        //    {
        //        Department d = new Department();
        //        d.Id = obj.Id;
        //        d.Name = obj.Name;
        //        d.Code = obj.Code;
        //        db.Department.Add(d);
        //        db.SaveChanges();
        //    }
        //    public void Edit(DepartmentVM obj)
        //    {
        //        var olddata = db.Department.Find(obj.Id);
        //        olddata.Name = obj.Name;
        //        olddata.Code = obj.Code;
        //        db.SaveChanges();

        //    }

        //    public void Delete(int Id)
        //    {
        //        var data = db.Department.Find(Id);
        //        db.Department.Remove(data);
        //        db.SaveChanges();
        //    }





    }
    }
