using CoolStore.DataAccess.Repository;
using CoolStore.DataAccess.Repository.IRepository;
using CoolStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(products);
        }

        public IActionResult Details(int? id)
        {
			Product products = _unitOfWork.Product.Get(u => u.Id == id, incluceProperties: "Category");
            return View(products);
		}

		public IActionResult Privacy()
        {
            return View();
        }
    }
}
