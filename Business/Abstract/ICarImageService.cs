﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetByCarId(int carId);
        IDataResult<Image> GetByImageId(int ImageId);
        IResult Add(IFormFile file, Image carImage);
        IResult Delete(Image carImage);
        IResult Update(IFormFile file, Image carImage);
    }
}
