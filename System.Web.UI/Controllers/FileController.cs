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
            var files = fileRepository.Find(page, int.Parse(_config.GetSection("PaginatedCount").Value));
            
            //PagedList.Core.PagedList<Models.ViewModels.vw_File> vw_Files = files.ToList().ConvertAll(mapping.MapToFileViewModel);
            //PagedList.Core.PagedList<Models.ViewModels.vw_File> vw_Files = mapping.MapToFileViewModel(files.ToList());//.ConvertAll();
            return View(files);
        }

        //[HttpPost]
        //public IActionResult Index(int page)
        //{
        //    var files = fileRepository.Find(page, int.Parse(_config.GetSection("PaginatedCount").Value));
        //    //PagedList.Core.PagedList<Models.ViewModels.vw_File> vw_Files = files.ToList().ConvertAll(mapping.MapToFileViewModel);
        //    //PagedList.Core.PagedList<Models.ViewModels.vw_File> vw_Files = mapping.MapToFileViewModel(files.ToList());//.ConvertAll();
        //    return View(files);
        //}
    }
}
