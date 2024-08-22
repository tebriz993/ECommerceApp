using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Tech.BusinessLogic.Abstract;
using Tech.BusinessLogic.Dtos;

namespace Tech.ECommerce.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController(IProductService productService,
                                   ICategoryService categoryService,
                                   IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }


        public async Task<IActionResult> GetProduct()
        {
            var products = await _productService.GetAllProduct();
            return Json(products);
        }


        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoryList();
            return Json(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct([FromRoute] int? id = null)
        {
            if (id is not null)
            {
                var product = await _productService.GetProductByIdAsync(id.Value);
                return View(product);
            }

            return View(new ProductAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddDto product)
        {

            if (ModelState.IsValid)
            {
                await _productService.AddProduct(product);
                return Json(new { message = "Product was added successfully!" });
                
            }

            return View(product);
           

        }



        [HttpGet]
        public async Task<IActionResult> RemoveProduct([FromRoute] int id )
        {
            await _productService.Remove(id);
            return Json(new { message = "Product was deleted successfully!" });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {

            try
            {
                if (image is not null && image.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                    string uniqeFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqeFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    string imagePath = Path.Combine("/uploads", uniqeFileName);
                    string imageUrl = Url.Content(imagePath);


                    return Json(new { image = imageUrl });
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Json(new { message = "Product was added successfully!" });
        }
    }
}
