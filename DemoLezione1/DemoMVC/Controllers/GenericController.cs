using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class GenericController<X> : Controller where X : EntityBase
    {

        private readonly IConfiguration _configuration;
        private readonly IGenericData<X> _genericData;
        private readonly string _nameEntity;

        public GenericController(IConfiguration configuration, IGenericData<X> genericData, string nameEntity)
        {
            _configuration = configuration;
            _genericData = genericData;
            _nameEntity = nameEntity;
        }
        public IActionResult Index()
        {
            return View(_genericData.GetAll(_configuration["OrdinamentoStudenti"] ?? "Cognome"));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _genericData.Get(id);

            if (entity != null)
            {
                return View(entity);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(X entity)
        {
            _genericData.Create(entity);

            return RedirectToAction("Index", _nameEntity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _genericData.Get(id);

            if (entity != null)
            {
                return View(entity);
            }

            return RedirectToAction("Index", _nameEntity);
        }

        [HttpPost]
        public IActionResult Delete(X entity)
        {
            _genericData.Delete(entity.Id);

            return RedirectToAction("Index", _nameEntity);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _genericData.Get(id);

            if (entity != null)
            {
                return View(entity);
            }

            return RedirectToAction("Index", _nameEntity);
        }

        [HttpPost]
        public IActionResult Edit(X entity)
        {
            _genericData.Edit(entity);

            return RedirectToAction("Index", _nameEntity);
        }
    }
}
