using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcDemo4.BL.Interface;
using MvcDemo4.BL.Models;
using MvcDemo4.BL.Repository;
using MvcDemo4.DAL.Entity;
using NToastNotify;

namespace MvcDemo4.Controllers
{
    public class DepartmentController : Controller
    {

        #region Feilds 
        //Loosly Coupled
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        //Toughtly coupled 
        //DepartmentRep Department;
        //DepartmentRep Department = new DepartmentRep();

        #endregion


        #region Ctor

        public DepartmentController(IDepartmentRep department,IMapper mapper , IToastNotification toastNotification)
        {
            this.department = department;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }


        #endregion


        #region Actions
        public IActionResult Index()
        {
            var data = department.Get();
            var model = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var DetailPage = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(DetailPage);

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var  data = mapper.Map<Department>(model);
                    department.Create(data);
                    toastNotification.AddSuccessToastMessage("Department added succsuflly");
                    return RedirectToAction("Index");
                    
                }
                toastNotification.AddErrorToastMessage("Error");
                return View(model);
               

            }
            catch (Exception)
            {

                toastNotification.AddErrorToastMessage("Error");
                return View(model);
                
            }
            
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Edit(data);
                    return RedirectToAction("Index");
                }

                return View(model);

            }
            catch (Exception)
            {

                return View(model);
            }
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {

            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            try
            {
                var data = mapper.Map<Department>(model);
                department.Delete(data);
                return RedirectToAction("Index");

            }
            catch 
            {

                return View(model);
            }
        }



        #endregion





    }
}
