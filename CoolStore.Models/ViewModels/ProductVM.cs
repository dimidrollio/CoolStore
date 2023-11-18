using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolStore.Models.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }

		[ValidateNever]
		[DisplayName("Category")]
		public IEnumerable<SelectListItem> CategoryList { get; set; }

	}
}
