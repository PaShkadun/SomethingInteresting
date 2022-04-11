using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.Models;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _service;
        private readonly IMapper _mapper;

        public TestController(ITestService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: TestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        public async Task<ActionResult> Create(PersonModel person)
        {
            var dto = await _service.Create(_mapper.Map<PersonDto>(person));

            return new JsonResult(_mapper.Map<PersonModel>(dto));
        }

        // POST: TestController/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: TestController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
