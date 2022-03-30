using Microsoft.AspNetCore.Mvc;
using MVCIntro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntro.Controllers
{
    public class CategoryController : Controller
    {
        //Dummy Data (guya veri tabanından okudugumuz liste olsun bu)
        private readonly List<Category> _categories = new List<Category>() 
        { 
            new Category(){Id=1,Name="İçecekler"},
            new Category(){Id=2,Name="Yiyecekler"},
            new Category(){Id=3,Name="Elektronik"},
        };
        public IActionResult Index()
        {
            return View(_categories);
        }
    }
}
