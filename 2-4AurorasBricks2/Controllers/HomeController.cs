using _2_4AurorasBricks2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Identity.Client;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using _2_4AurorasBricks2.Models.ViewModels;
using System.Drawing.Printing;
using NuGet.ProjectModel;


namespace _2_4AurorasBricks2.Controllers
{
    public class HomeController : Controller
    {
        public ILegoRepository _repo;
        private readonly InferenceSession _session;
        private readonly ILogger<HomeController> _logger;
        private readonly string _onnxPath;
        //Some people have made an ONX Path Variable and defined it to the _session model
        public HomeController(ILegoRepository temp, ILogger<HomeController> logger, IHostEnvironment hostEnvironment)
        {
            _repo = temp;
            _logger = logger;
            _onnxPath = System.IO.Path.Combine(hostEnvironment.ContentRootPath, "fraudulent_pipeline.onnx");

            try
            {
                _session = new InferenceSession(_onnxPath);
                _logger.LogInformation("ONNX model loaded successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading the ONNX model: {ex.Message}");
            }
        }

        public IActionResult Index()
        {
            var viewModel = new ProjectsListViewModel
            {
                Products = _repo.Products
                    .OrderBy(p => p.ProductId) // Ensure there's some ordering, if not already
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult EditProducts(int pageNum)
        {
            int pageSize = 10;

            //Ensure the page number is at least 1
            pageNum = Math.Max(1, pageNum);

            var viewModel = new ProjectsListViewModel
            {
                Products = _repo.Products
                    .OrderBy(p => p.ProductId)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Products.Count()
                },

            };
            return View(viewModel);

        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            var newProduct = new Product();
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult AddProducts(Product response)
        {
            var maxProductId = _repo.Products.Max(p => (int?)p.ProductId) ?? 0;
            response.ProductId = maxProductId + 1;

            _repo.AddProduct(response);
            return RedirectToAction("EditProducts");
            //if (ModelState.IsValid)
            //{
            //    _repo.AddProduct(response);
            //    return RedirectToAction("EditProducts");
            //}
            //else
            //{
            //    return View(response);
            //}
        }
        [HttpGet]
        public IActionResult EditProductsSingle(int id)
        {
            var productToEdit = _repo.Products
                .Single(x => x.ProductId == id);

            return View("AddProducts", productToEdit);
        }

        [HttpPost]
        public IActionResult EditProductsSingle(Product updatedProduct)
        {
            _repo.EditProduct(updatedProduct);

            return RedirectToAction("EditProducts");

            //if (ModelState.IsValid)
            //{
            //    _repo.EditProduct(updatedProduct);

            //    return RedirectToAction("EditProducts");
            //}
            //else
            //{
            //    return View("AddProducts", updatedProduct);
            //}
        }
        
        [HttpGet]
        public IActionResult DeleteProducts(int id)
        {
            var productToDelete = _repo.Products
                .Single(x => x.ProductId == id);

            return View("DeleteProducts", productToDelete);
        }

        [HttpPost]
        public IActionResult DeleteProducts(Product productToDelete)
        {
            _repo.DeleteProduct(productToDelete);

            return RedirectToAction("EditProducts");
        }
        public IActionResult EditUsers()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ReviewOrders()
        {
            var records = _repo.Orders.Take(20).ToList();
            var customers = _repo.Customers.ToList();
            var predictions = new List<FraudPrediction>();
            var class_type_dict = new Dictionary<int, string>
            {
                { 0, "Not Fraud" },
                { 1, "Fraud" }
            };

            foreach (var record in records)
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == record.CustomerId);

                var input = new List<float>
                {
                    (float)record.TransactionId, 
                    (float)record.CustomerId,
                    (float)record.Time,

                    // Fix amount if it's null by doing ??
                    (float)(record.Amount ?? 0),

                    (float)customer.Age,

                    record.DayOfWeek == "Mon" ? 1 : 0,
                    record.DayOfWeek == "Sat" ? 1 : 0,
                    record.DayOfWeek == "Sun" ? 1 : 0,
                    record.DayOfWeek == "Thu" ? 1 : 0,
                    record.DayOfWeek == "Tue" ? 1 : 0,
                    record.DayOfWeek == "Wed" ? 1 : 0,

                    record.EntryMode == "PIN" ? 1 : 0,
                    record.EntryMode == "Tap" ? 1 : 0,

                    record.TypeOfTransaction == "Online" ? 1 : 0,
                    record.TypeOfTransaction == "POS" ? 1 : 0,

                    record.CountryOfTransaction  == "India" ? 1 : 0,
                    record.CountryOfTransaction  == "Russia" ? 1 : 0,
                    record.CountryOfTransaction  == "USA" ? 1 : 0,
                    record.CountryOfTransaction  == "United Kingdom" ? 1 : 0,


                    (record.ShippingAddress ?? record.CountryOfTransaction) == "India" ? 1 : 0,
                    (record.ShippingAddress ?? record.CountryOfTransaction) == "Russia" ? 1 : 0,
                    (record.ShippingAddress ?? record.CountryOfTransaction) == "USA" ? 1 : 0,
                    (record.ShippingAddress ?? record.CountryOfTransaction) == "United Kingdom" ? 1 : 0,

                    record.Bank == "HSBC" ? 1 : 0,
                    record.Bank == "Halifax" ? 1 : 0,
                    record.Bank == "Lloyds" ? 1 : 0,
                    record.Bank == "Metro" ? 1 : 0,
                    record.Bank == "Monzo" ? 1 : 0,
                    record.Bank == "RBS" ? 1 : 0,

                    record.TypeOfCard == "Visa" ? 1 : 0,

                    customer.CountryOfResidence  == "India" ? 1 : 0,
                    customer.CountryOfResidence  == "Russia" ? 1 : 0,
                    customer.CountryOfResidence  == "USA" ? 1 : 0,
                    customer.CountryOfResidence  == "United Kingdom" ? 1 : 0,

                    customer.Gender == "M" ? 1 : 0

                };
                var inputTensor = new DenseTensor<float>(input.ToArray(), new[] { 1, input.Count });

                var inputs = new List<NamedOnnxValue>
                {
                    NamedOnnxValue.CreateFromTensor("float_input", inputTensor)
                };

                string PredictionResult;
                using (var results = _session.Run(inputs))
                {
                    var prediction = results.FirstOrDefault(item => item.Name == "output_label")?.AsTensor<long>().ToArray();
                    PredictionResult = prediction != null && prediction.Length > 0 ? class_type_dict.GetValueOrDefault((int)prediction[0], "Unknown") : "Error in prediction.";
                }

                predictions.Add(new FraudPrediction { Order = record, Prediction = PredictionResult });
            }

            return View(predictions);
        }
    }
}
