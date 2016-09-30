using Exam.Model;
using RestSharp;
using System.Collections.Generic;

namespace Exam.Web
{
    public class CustomerRepository
    {
        public const string URL_API = "http://localhost:58536/api";

        public List<Customer> GetList()
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.GET);
            request.Resource = "/customer";

            return client.Execute<List<Customer>>(request).Data;
        }

        public void Add(Customer customer)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.PUT);
            request.Resource = "/customer";
            request.AddJsonBody(customer);
            client.Execute(request);
        }

        public Customer GetById(int id)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.GET);
            request.Resource = $"/customer/{id}";
            return client.Execute<Customer>(request).Data;
        }

        public void Update(Customer customer)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.POST);
            request.Resource = "/customer";
            request.AddJsonBody(customer);
            client.Execute(request);
        }

        public void Delete(Customer customer)
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/customer";
            request.AddJsonBody(customer);
            client.Execute(request);
        }
    }
}