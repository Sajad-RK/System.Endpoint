using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.IO;
using System.Linq;
using System.Services.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace System.Web.UI.Controllers
{

    public class FileController : Controller
    {
        private readonly Services.Repositories.IFileRepository fileRepository;
        private readonly IConfiguration _config;
        //Mappings.ManualMapping mapping;
        public FileController(IFileRepository fileRepository, IConfiguration configuration/*, Mappings.ManualMapping mapping*/)
        {
            this.fileRepository = fileRepository;
            this._config = configuration;
            //this.mapping = mapping;
        }
        public IActionResult Index(int page)
        {
            var files = fileRepository.Find((page == 0 ? 1 : page), int.Parse(_config.GetSection("PaginatedCount").Value));
            return View(files);
        }

        public IActionResult AddNewItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewItem(DataAccessLayer.Models.File file)
        {
            if (ModelState.IsValid)
            {
                fileRepository.Add(file);
                fileRepository.Save();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult UpdateItem(int id)
        {
            var file = fileRepository.Find(a => a.Id == id);
            if (file != null)
                return View();
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateItem(DataAccessLayer.Models.File file)
        {
            fileRepository.Update(file);
            fileRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
