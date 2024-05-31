using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcDemo4.BL.Interface;
using MvcDemo4.BL.Models;
using MvcDemo4.BL.Repository;

namespace MvcDemo4.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerRepository repository;
        private readonly IMapper mapper;

        public TrainerController(ITrainerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = repository.GetTrainers();

            var model = mapper.Map<IEnumerable<TrainerViewModel>>(data);    

            return View(model);
        }
    }
}
