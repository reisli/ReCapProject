using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(List<IFormFile> files,CarImage carImage)
        {
            if (files.Count <= 0)
                return new ErrorResult(Messages.FileNotFound);

            
            var result = FileHelper.Upload(files,ImagePaths.CarImagePath).Data;

            foreach (var path in result)
            {
                carImage.ImagePath = path;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
            }

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            CarImage carImageDeleted = _carImageDal.Get(c => c.CarID == carImage.CarID);
            var result=FileHelper.Delete(carImageDeleted.ImagePath);
            if (result.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
