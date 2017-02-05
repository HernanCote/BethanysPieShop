using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        public ViewResult List()
        {
            var model = new PiesListViewModel();

            model.CurrentCateogry = "Cheese Cakes";
            model.Pies = _pieRepository.Pies;

            return View(model);
        }
    }
}
