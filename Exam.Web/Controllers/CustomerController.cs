using Exam.Model;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _repository;

        public CustomerController()
        {
            _repository = new CustomerRepository();
        }

        public ActionResult Index()
        {
            return View(_repository.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _repository.GetById(id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _repository.GetById(id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            _repository.Delete(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var customer = _repository.GetById(id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }
    }
}