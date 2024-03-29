﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,ReCapProjectContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                    join cl in context.Colors on c.ColorId equals cl.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    select new CarDetailDto()
                        {BrandName = b.Name, CarName = c.Description, ColorName = cl.Name, DailyPrice = c.DailyPrice};
                return result.ToList();
            }
        }
    }
}
