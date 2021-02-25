using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

    public class CarImageManager : ICarImageService
    {
        ICarImageDAL _carImageDAL;

        public CarImageManager(ICarImageDAL carImageDAL)
        {
            _carImageDAL = carImageDAL;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId) );
            if (result != null)
            {
                return result;
            }
            var createdImage = TakeFileName(carImage).Data;
            _carImageDAL.Add(createdImage);
            return new SuccessResult();

        }
        public IResult Delete(CarImage carImage)
        {
            File.Delete(carImage.ImagePath);
            _carImageDAL.Delete(carImage);
            return new SuccessResult();
        }
        public IResult Update(CarImage carImage)
        {
            var updatedImage = TakeFileName(carImage).Data;
            File.Copy(carImage.ImagePath, updatedImage.ImagePath);
            File.Delete(carImage.ImagePath);
            _carImageDAL.Update(updatedImage);
            return new SuccessResult();
        }
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDAL.Get(p => p.Id == id));
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll());
        }
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckCarImageNull(id));
        }

        private IResult CheckCarImageLimitExceeded(int carid)
        {
            var carImageCount = _carImageDAL.GetAll(p => p.CarId == carid).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<CarImage> TakeFileName(CarImage carImage)
        {
            var guidName = Guid.NewGuid().ToString() + ".jpg";
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"~\Content\img");
            string source = Path.Combine(carImage.ImagePath);
            string result = $@"{path}\{guidName}";
            try
            {
                File.Move(source, path + @"\" + guidName);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<CarImage>(exception.Message);
            }
            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now });
        }
        private List<CarImage> CheckCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"Content\img\logo.jpg");
            var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDAL.GetAll(p => p.CarId == id);
        }

    }
}
