using Exam.Model;
using Exam.Repository;
using System.Linq;
using System.Web.Http;

namespace Exam.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly BaseRepository<Customer> _repository;
        public CustomerController()
        {
            _repository = new BaseRepository<Customer>();
        }

        [HttpPut]
        public IHttpActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_repository.Add(customer));
        }

        [HttpPost]
        public IHttpActionResult Update(Customer customer)
        {
            var oldCustomer = _repository.GetById(x => x.CustomerId == customer.CustomerId);
            if (oldCustomer == null) return NotFound();
            return Ok(_repository.Update(oldCustomer, customer));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.GetById(x => x.CustomerId == id));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var list = _repository.GetList().Take(30).ToList();
            return Ok(list);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Customer customer)
        {
            return Ok(_repository.Delete(customer));
        }
    }
}
