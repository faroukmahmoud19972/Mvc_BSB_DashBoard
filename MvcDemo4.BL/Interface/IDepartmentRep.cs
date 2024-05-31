using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemo4.BL.Models;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Interface
{
    public interface IDepartmentRep
    {
        //IEnumerable<DepartmentVM> Get();
        //DepartmentVM GetById(int id);
        //void Create (DepartmentVM obj);
        //void Edit (DepartmentVM obj);
        //void Delete (int Id);



        IEnumerable<Department> Get();
        Department GetById(int id);
        void Create(Department obj);
        void Edit(Department obj);
        void Delete(Department obj);


    }
}
