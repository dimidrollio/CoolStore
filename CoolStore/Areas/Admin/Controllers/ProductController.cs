using CoolStore.DataAccess.Repository.IRepository;
using CoolStore.Models;
using CoolStore.Models.ViewModels;
using CoolStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoolStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class ProductController : Controller
	{
		public IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_unitOfWork = unitOfWork;
		}
		[ActionName("Index")]
		public IActionResult Index()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
			return View(objProductList);
		}

		public IActionResult Upsert(int? id)
		{
			ProductVM productVM = new()
			{
				CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				}),
				Product = new Product()
			};
			if(id == null || id == 0)
			{
				//create
				return View(productVM);

			}
			else
			{
				//edit
				productVM.Product = _unitOfWork.Product.Get(x => x.Id == id);
				return View(productVM);
			}
		}

		[HttpPost] 
		public IActionResult Upsert(ProductVM obj, IFormFile? file)
		{
			//if validation is okay
			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string productPath = Path.Combine(wwwRootPath, @"images\product");

					//delete old if exists
					if(!string.IsNullOrEmpty(obj.Product.ImgUrl)) 
					{
						var oldImagePath =
							Path.Combine(wwwRootPath, obj.Product.ImgUrl.TrimStart('\\'));
						if(System.IO.File.Exists(oldImagePath))
						{
							System.IO.File.Delete(oldImagePath);
						}
					}

					using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					obj.Product.ImgUrl = @"\images\product\" + fileName;
				}

				if (obj.Product.Id == 0)
				{
					_unitOfWork.Product.Add(obj.Product);
				}
				else
				{
					_unitOfWork.Product.Update(obj.Product);
				}
				_unitOfWork.Save();
				TempData["success"] = "Product created successfully!";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var productToDelete = _unitOfWork.Product.Get(u => u.Id == id);
			if (productToDelete == null)
			{
				return Json( new { success = false, message = "Could not delete that."});
			}
			else
			{
				var oldImagePath =
							Path.Combine(_webHostEnvironment.WebRootPath, productToDelete.ImgUrl.TrimStart('\\'));
				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}

				_unitOfWork.Product.Remove(productToDelete);
				_unitOfWork.Save();
				return Json(new { success = true, message = "Deleted successfully" });
			}
		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAll(int id)
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
			return Json(new { data = objProductList });
		}

		#endregion
	}
}
