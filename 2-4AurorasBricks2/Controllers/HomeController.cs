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
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authorization;


namespace _2_4AurorasBricks2.Controllers
{
    public class HomeController : Controller
    {
        public ILegoRepository _repo;
        private readonly InferenceSession _session;
        private readonly ILogger<HomeController> _logger;
        private readonly string _onnxPath;

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
        [AllowAnonymous]
        public IActionResult Index()
        {
            var Model = new IndexHybridViewModel
            {
                Products = _repo.Products.OrderBy(p => p.ProductId),
                // BASED ON THE USER RATINGS AND FOR THOSE WHO AREN"T LOGGED IN
                PreLoadedRecommendations = new List<int> { 13, 21, 20, 12, 23 }
            };
            // if (User.IsInRole("Customer")
            if (User.Identity.IsAuthenticated)
            {
                // CODE THAT IS MEANT TO TAKE THE USER ID, FIND THE CORRESPONDING CUSTOMER ID, AND FETCH THEIR MOST PREVIOUS TRANSACTION
                //Random random = new Random();
                //int randomNumber = random.Next(0, 29135);

                ////(int)userID

                //// CUSTOMER IS ASSIGNED TO RANDOM NUMBER
                //var customer = _repo.Orders.FirstOrDefault(x => x.CustomerId == randomNumber);

                //// MOST RECENT TRANSACTION IS TAKEN FROM RANDOM CUSTOMER
                //var transaction = _repo.LineItems.FirstOrDefault(x => x.TransactionId == customer.TransactionId);

                //// TOP PRODUCT FROM TRANSACTION IS TAKEN FROM THE TRANSACTION
                //var product = _repo.Products.FirstOrDefault(x => x.ProductId == transaction.ProductId);

                //// ASSIGNING THE PRODUCT VARIABLE TO SOMETHING IDK WHAT"S GOING ON HERE 
                //var originalProduct = _repo.Products.FirstOrDefault(p => p.ProductId == randomNumber);

                //// BLANK LIST
                //var allProducts = new List<Product>();

                //// FOR LOOP GOING THROUGH THE LIST
                //for (int i = 1; i <= 5; i++)
                //{
                //    // Extract the value of the current rec_X column from the chosen product
                //    var recValue = (string)originalProduct.GetType().GetProperty("Rec_" + i).GetValue(originalProduct);

                //    // If the value is not null or empty, find products with the same name
                //    if (!string.IsNullOrEmpty(recValue))
                //    {
                //        var recProducts = _repo.Products.Where(x => x.Name == recValue).ToList();

                //        // Add the found products to the list of all products
                //        allProducts.AddRange(recProducts);
                //    }
                //}

                // RENAMING THE MODEL IF THE USER IS AUTHENTICATED
                Model = new IndexHybridViewModel
                {
                    Products = _repo.Products.OrderBy(p => p.ProductId),
                    // CODE THAT IS MEANT TO RETURN A DICTIONARY OF PRODUCT NAMES THAT SOMEHOW CONVERTS TO A NUMBER

                    //RecommendedProducts = new List<Product>
                    //{
                    //    { allProducts.Where(p => p.Pop_rec_1 == product.Name).ToList() },
                    //    { allProducts.Where(p => p.Pop_rec_2 == product.Name).ToList() },
                    //    { allProducts.Where(p => p.Pop_rec_3 == product.Name).ToList() },
                    //    { allProducts.Where(p => p.Pop_rec_4 == product.Name).ToList() },
                    //    { allProducts.Where(p => p.Pop_rec_5 == product.Name).ToList() }
                    //},

                    // TAKING THE L AND JUST ASSIGNING IT A PRELOADED DATASET THAT DIFFERS FROM A PERSON LOGGED IN.
                    PreLoadedRecommendations = new List<int> { 23, 19, 21, 22, 12 }
                };
            }
            return View(Model);
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
        [Authorize(Roles = "Admin")]
        public IActionResult EditProducts(int pageNum)
        {
            int pageSize = 10;

            //Ensure the page number is at least 1
            pageNum = Math.Max(1, pageNum);

            var viewModel = new ProjectsViewModel
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddProducts()
        {
            var newProduct = new Product();
            return View(newProduct);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditProductsSingle(int id)
        {
            var productToEdit = _repo.Products
                .Single(x => x.ProductId == id);

            return View("AddProducts", productToEdit);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteProducts(Product productToDelete)
        {
            _repo.DeleteProduct(productToDelete);

            return RedirectToAction("EditProducts");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditUsers()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult ProductDetail(int id)
        {
            // Retrieve the product with the specified ID
            var originalProduct = _repo.Products.FirstOrDefault(p => p.ProductId == id);

            var allProducts = new List<Product>();

            for (int i = 1; i <= 5; i++)
            {
                // Extract the value of the current rec_X column from the chosen product
                var recValue = (string)originalProduct.GetType().GetProperty("Rec_" + i).GetValue(originalProduct);

                // If the value is not null or empty, find products with the same name
                if (!string.IsNullOrEmpty(recValue))
                {
                    var recProducts = _repo.Products.Where(x => x.Name == recValue).ToList();

                    // Add the found products to the list of all products
                    allProducts.AddRange(recProducts);
                }
            }

            var productViewModel = new SingleProductViewModel
            {
                Products = _repo.Products.Where(x => x.ProductId == id),
                /*                Products = _repo.Products.FirstOrDefault(p => p.ProductId == id),*/ // Include the original product in the view model
                RecommendedProducts = new Dictionary<string, List<Product>>
                {
                    { "Rec_1", allProducts.Where(p => p.Rec_1 == originalProduct.Name).ToList() },
                    { "Rec_2", allProducts.Where(p => p.Rec_2 == originalProduct.Name).ToList() },
                    { "Rec_3", allProducts.Where(p => p.Rec_3 == originalProduct.Name).ToList() },
                    { "Rec_4", allProducts.Where(p => p.Rec_4 == originalProduct.Name).ToList() },
                    { "Rec_5", allProducts.Where(p => p.Rec_5 == originalProduct.Name).ToList() }
                }
            };

            return View(productViewModel);
        }

        [AllowAnonymous]
        public IActionResult Products(int pageNum, string? legoType, string? legoColor, int pageSize = 5)
        {

            //pageNum = pageNum <= 0 ? 1 : pagenum;
            //Ensure the page number is at least 1
            pageNum = Math.Max(1, pageNum);

            var viewModel = new ProjectsViewModel
            {
                Products = _repo.Products
                    .Where(x => (x.Category == legoType || legoType == null) && (x.PrimaryColor == legoColor || legoColor == null))
                    .OrderBy(p => p.ProductId)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = legoType == null ? _repo.Products.Count() : _repo.Products.Where(x => x.Category == legoType).Count()
                },

                CurrentLegoCategory = legoType,
                CurrentLegoColor = legoColor,
                CurrentPageSize = pageSize

            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Predict(int TransactionId, int CustomerId, byte Time, short Amount, Decimal Age, string DayOfWeek, string EntryMode, string TypeOfTransaction, string CountryOfTransaction, string ShippingAddress, string Bank, string TypeOfCard, string CountryOfResidence, string Gender)
        {
            var class_type_dict = new Dictionary<int, string>
            {
                {0, "0" },
                {1, "1"}
            };

            try
            {
                var input = new List<float>
                {
                    (float)TransactionId,
                    (float)CustomerId,
                    (float)Time,
                    (float)Amount,
                    (float)Age,

                    DayOfWeek == "Mon" ? 1 : 0,
                    DayOfWeek == "Sat" ? 1 : 0,
                    DayOfWeek == "Sun" ? 1 : 0,
                    DayOfWeek == "Thu" ? 1 : 0,
                    DayOfWeek == "Tue" ? 1 : 0,
                    DayOfWeek == "Wed" ? 1 : 0,

                    EntryMode == "PIN" ? 1 : 0,
                    EntryMode == "Tap" ? 1 : 0,

                    TypeOfTransaction == "Online" ? 1 : 0,
                    TypeOfTransaction == "POS" ? 1 : 0,

                    CountryOfTransaction  == "India" ? 1 : 0,
                    CountryOfTransaction  == "Russia" ? 1 : 0,
                    CountryOfTransaction  == "USA" ? 1 : 0,
                    CountryOfTransaction  == "United Kingdom" ? 1 : 0,

                    (ShippingAddress ?? CountryOfTransaction) == "India" ? 1 : 0,
                    (ShippingAddress ?? CountryOfTransaction) == "Russia" ? 1 : 0,
                    (ShippingAddress ?? CountryOfTransaction) == "USA" ? 1 : 0,
                    (ShippingAddress ?? CountryOfTransaction) == "United Kingdom" ? 1 : 0,

                    Bank == "HSBC" ? 1 : 0,
                    Bank == "Halifax" ? 1 : 0,
                    Bank == "Lloyds" ? 1 : 0,
                    Bank == "Metro" ? 1 : 0,
                    Bank == "Monzo" ? 1 : 0,
                    Bank == "RBS" ? 1 : 0,

                    TypeOfCard == "Visa" ? 1 : 0,

                    CountryOfResidence  == "India" ? 1 : 0,
                    CountryOfResidence  == "Russia" ? 1 : 0,
                    CountryOfResidence  == "USA" ? 1 : 0,
                    CountryOfResidence  == "United Kingdom" ? 1 : 0,

                    Gender == "M" ? 1 : 0
                };
                var inputTensor = new DenseTensor<float>(input.ToArray(), new[] { 1, input.Count });

                var inputs = new List<NamedOnnxValue>
                {
                    NamedOnnxValue.CreateFromTensor("float_input", inputTensor)
                };

                using (var results = _session.Run(inputs))
                {
                    var prediction = results.FirstOrDefault(item => item.Name == "output_label")?.AsTensor<long>().ToArray();
                    if (prediction != null && prediction.Length > 0)
                    {
                        var fraudDecision = class_type_dict.GetValueOrDefault((int)prediction[0], "Unknown");
                        ViewBag.Prediction = fraudDecision;
                    }
                    else
                    {
                        ViewBag.Prediction = "Error: Unable to make a prediction";
                    }
                }
                _logger.LogInformation("Prediction executed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during the prediction: {ex.Message}");
                ViewBag.Prediction = "Error during prediction.";
            }
            return View("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ReviewOrders() //Home Controller for Reviewing Orders
        {
            var records = _repo.Orders.Take(20).ToList(); // I need to pass the ORDERS and the CUSTOMERS to accurately use the ONNX file, which expects values from both tables.
            var customers = _repo.Customers.ToList();
            var predictions = new List<FraudPrediction>();
            var class_type_dict = new Dictionary<int, string> // This is what I want to return.
            {
                { 0, "0" }, // I may change the "Not Fraud" to be a 0 in the future
                { 1, "1" }
            };

            foreach (var record in records) // Going through each record 
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == record.CustomerId);

                var input = new List<float>
                {
                    // Reassigning anything that isn't float to a float.
                    (float)record.TransactionId,
                    (float)record.CustomerId,
                    (float)record.Time,

                    // Fix amount if it's null by doing ??
                    (float)(record.Amount ?? 0),

                    (float)customer.Age,

                    record.DayOfWeek == "Mon" ? 1 : 0, // I need to dummy code the data so it goes through my ONNX file properly.
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
                var inputTensor = new DenseTensor<float>(input.ToArray(), new[] { 1, input.Count }); // I'm going to pass the input into an array.

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
        public IActionResult ConfirmPage(int fraud = 0)
        {

            return View("CartConfirmation", fraud);
        }
    }
}
