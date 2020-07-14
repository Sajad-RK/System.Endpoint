using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web.UI.Models;
using System.DataAccessLayer.Models;
using System.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace System.Web.UI.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        //private System.Services.Repositories.IUnitOfWork _unitOfWork;
        //private readonly Services.Repositories.IBaseRepository<File> _baseRepository;
        private readonly Services.Repositories.IFileRepository fileRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, /*IUnitOfWork unitOfWork,*/ IFileRepository fileRepository, IConfiguration configuration)
        {
            _logger = logger;
            //_unitOfWork = unitOfWork;
            this.fileRepository = fileRepository;
            _config = configuration;
        }
        //[Authorize]
        public IActionResult Index()
        {
            string str = "342180027762901";
            string str1 = "2776290";
            int index = str.IndexOf(str1, 6);
            var prefix = str.Substring(0, index);
            var postfix = str.Substring(index + str1.Length);
            string pad = "007874121";
            pad = pad.PadRight(12, '0');
            
            return View();
        }
        public IActionResult DataList()
        {
            var dataFiles = fileRepository.Find(10, int.Parse(_config.GetSection("PaginatedCount").Value));
            return View(dataFiles);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
