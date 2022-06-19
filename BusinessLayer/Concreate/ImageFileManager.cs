using BusinessLayer.Abstract;
using DataAccsesLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
   public class ImageFileManager:IImageFileService
    {
        IImageFileDal _ImageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _ImageFileDal = imageFileDal;
        }

        public List<ImageFile> GetList()
        {
            return _ImageFileDal.List();
        }
    }
}
