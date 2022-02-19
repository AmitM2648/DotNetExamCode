using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsWebApp.Models
{
    public class Products
    {
        [Display(Name ="Product Id")]
        public int ProductId { get; set; }

        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="Product Name Required")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Display(Name ="Rate")]
        [Required(ErrorMessage ="Set the Rate of Product")]
        [DataType(DataType.Text)]
        public decimal Rate { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Product description is required")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Enter Product Category")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }
}