using _2_4AurorasBricks2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2_4AurorasBricks2.Models;
using Microsoft.Identity.Client;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;


namespace _2_4AurorasBricks2.Controllers
{
    public class HomeController : Controller
    {
        public ILegoRepository _repo;
        private readonly InferenceSession _session;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILegoRepository temp, ILogger<HomeController> logger)
        {
            _repo = temp;
            _logger = logger;

            try
            {
                _session = new InferenceSession("C:\\Users\\oliverescobar\\Source\\Repos\\2-4AurorasBricks2\\2-4AurorasBricks2\\fraudulent_pipeline.onnx");
                _logger.LogInformation("ONNX model loaded successfully.");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error loading the ONNX model: {ex.Message}");
            }
        }

        public IActionResult Index()
        {
            return View();
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
        public IActionResult EditProducts()
        {
            var oneCart = _repo.Products.ToList();
            return View(oneCart);
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

        [HttpPost]
        public IActionResult Predict(int fraud)
        {
            var class_type_dict = new Dictionary<int, string>
            {
                { 0, "Not Fraud" },
                { 1, "Fraud" }
            };

            try
            {
                // I should add variables below in the curly braces according to what I want to add in the fraud pipeline, which I think should be everything ...  
                var input = new List<int> { };
                var inputTensor = new DenseTensor<int>(input.ToArray(), new[] { 1, input.Count });

                var inputs = new List<NamedOnnxValue>
                {
                    NamedOnnxValue.CreateFromTensor("float_input", inputTensor)
                };

                using (var results = _session.Run(inputs))
                {
                    var prediction = results.FirstOrDefault(item => item.Name == "output_label")?.AsTensor<long>().ToArray();
                    if (prediction != null && prediction.Length > 0)
                    {
                        // Use the prediction to get the fraud from the dictionary
                        var fraudPrediction = class_type_dict.GetValueOrDefault((int)prediction[0], "Unknown");
                        ViewBag.Prediction = fraudPrediction;
                    }
                    else
                    {
                        ViewBag.Prediction = "Error: Unable to make a prediction.";
                    }
                }

                _logger.LogInformation("Prediction executed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during prediction: {ex.Message}");
                ViewBag.Prediction = "Error during prediction.";
            }

            return View("ReviewOrders");
        }

        public IActionResult ReviewOrders()
        {
            var records = _repo.Orders.ToList();
            var predictions = new List<FraudPrediction>();

            var class_type_dict = new Dictionary<int, string>
            {
                { 0, "Not Fraud" },
                { 1, "Fraud" }
            };

            foreach (var record in records)
            {
                var input = new List<float>
                {
                    record.TransactionId, record.CustomerId
                    //record.TransactionId, record.CustomerId, record.Date, record.DayOfWeek,
                    //record.Time, record.EntryMode, record.Amount, record.TypeOfTransaction,
                    //record.CountryOfTransaction, record.ShippingAddress, record.Bank, record.TypeOfCard
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
