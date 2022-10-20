using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductAssignmentEntity.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductAssignmentUI.Controllers
{
    public class ProductController : Controller
    {
        private IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> productresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Product/GetProducts";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        productresult = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
                    }
                }
            }
            return View(productresult);
        }

        public IActionResult ProductEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEntry(Product product)
        {
            if (ModelState.IsValid)
            {
                ViewBag.status = "";
                using (HttpClient client = new HttpClient())
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Product/AddProduct";
                    using (var response = await client.PostAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewBag.status = "Ok";
                            ViewBag.message = "Product details saved successfully!";
                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Entries!";
                        }
                    }
                }
            }
            return View();
        }
    }
}
