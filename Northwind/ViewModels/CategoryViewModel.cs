using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] picture { get; set; }

        public CategoryViewModel()
        {

        }

        public CategoryViewModel(Category entity)
        {
            CategoryID = entity.CategoryID;
            CategoryName = entity.CategoryName;
            Description = entity.Description;
            picture = entity.Picture;
        }
    }
}