using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcDemo4.BL.Interface;
using MvcDemo4.BL.Models;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.Controllers
{
    public class EmployeeController : Controller
    {
      
        #region Feilds 
        //Loosly Coupled
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;
        private readonly ICityRepository city;
        private readonly IDistrictRepository district;

        //Toughtly coupled 
        //DepartmentRep Department;
        //DepartmentRep Department = new DepartmentRep();

        #endregion


        #region Ctor

        public EmployeeController(ICityRepository city , IDistrictRepository district,IEmployeeRep employee, IDepartmentRep department , IMapper mapper)
        {
            this.city = city;
            this.district = district;
            this.employee = employee;
            this.department = department;
            this.mapper = mapper;
        }


        #endregion


        #region Actions
        public IActionResult Index()
        {
            var data = employee.Get();
            var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var DetailPage = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(DetailPage);
            SelectList listitems = new SelectList(department.Get(), "Id", "Name" , model.DepartmentId);

            ViewBag.DepartmentList = listitems;  
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Create(data);
                    return RedirectToAction("Index");
                }


                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
                return View(model);
            }
            catch (Exception ex)
            {

                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
                return View(model);
            }
        }


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(EmployeeVM model)
        //{

        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var data = mapper.Map<Employee>(model);
        //            employee.Create(data);
        //            return RedirectToAction("Index");
        //        }


        //        ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name");
        //        return View(model);
        //    }
        //}

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Edit(data);
                    return RedirectToAction("Index");
                }
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

                return View(model);

            }
            catch (Exception)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

                return View(model);
            }
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {

            var data = employee.GetById(id);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {
            try
            {
                var data = mapper.Map<Employee>(model);
                employee.Delete(data);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);


                return View(model);
            }
        }



        #endregion


        #region AJAX Call

        public JsonResult GetCityDataByCountryId(int ctryId)
        {
            var data = city.Get(a=>a.CountryId== ctryId);

            var model = mapper.Map<IEnumerable<CityViewModel>>(data);
            return Json(model);
        }

        public JsonResult GetDistrictDataByCityId(int ctyid)
        {
            var data = district.Get(a => a.CityId == ctyid);

            var model = mapper.Map<IEnumerable<DistrictViewModel>>(data);
            return Json(model);
        }


        #endregion


    }
}
