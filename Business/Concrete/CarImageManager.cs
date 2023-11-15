using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Image;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(ImageLimitExceeded(carImage.CarID));

            if (result != null)
                return result;

            carImage.ImagePath = ImageHelper.Upload(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            CarImage carImage = _carImageDal.Get(c => c.CarImageId == id);
            ImageHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, int id)
        {
            CarImage carImage = _carImageDal.Get(c => c.CarImageId == id);
            string result = ImageHelper.Update(file, carImage.ImagePath);
            carImage.ImagePath = result;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult ImageLimitExceeded(int carId)
        {
            var imagesCount = _carImageDal.GetAll(c => c.CarID == carId).Count;
            if (imagesCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();

        }
    }
}
