using PagedList.Core;
using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.Models.ViewModels;

namespace System.Web.UI.Mappings
{
    public class ManualMapping
    {
        public Models.ViewModels.vw_File MapToFileViewModel(DataAccessLayer.Models.File map)
        {
            return new Models.ViewModels.vw_File()
            {
                Id = map.Id,
                Content = map.Content,
                CreateDateTime = map.CreateDateTime,
                FileExtension = map.FileExtension,
                FileSize = map.FileSize,
                Title = map.Title,
                LastModified = map.LastModified
            };
        }

        //internal PagedList<vw_File> MapToFileViewModel(List<File> lists)
        //{
        //    PagedList<vw_File> result = null;
        //    foreach (var item in lists)
        //    {
        //        result.
        //    }
        //    throw new NotImplementedException();
        //}
    }
}
