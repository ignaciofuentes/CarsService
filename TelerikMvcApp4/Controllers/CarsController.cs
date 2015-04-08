using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TelerikMvcApp4.Controllers
{

    public class CarsController : ApiController
    {

        CarsDb db;
        public CarsController()
        {
            db = new CarsDb();
        }

        public IEnumerable<CarViewModel> Get()
        {
            return (from c in db.Cars
                    select new CarViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Price = c.Price,
                        Sold = c.Sold
                    });
        }

        public CarViewModel Post(CarViewModel car)
        {
            if (car != null && ModelState.IsValid)
            {
                var newCar = new Car { Name = car.Name, Price = car.Price, Sold = car.Sold };
                // db.Add(newCar);
                db.Cars.Add(newCar);
                db.SaveChanges();
                car.Id = newCar.Id;
            }
            return car;
        }
        public void Put(int id, [FromBody]CarViewModel car)
        {

            if (car != null && ModelState.IsValid)
            {
                var dbCar = db.Cars.Where(c => c.Id == car.Id).SingleOrDefault();
                if (dbCar != null)
                {
                    dbCar.Name = car.Name;
                    dbCar.Price = car.Price;
                    dbCar.Sold = car.Sold;

                }


            }
            db.SaveChanges();

        }

        public void Delete(int id)
        {

            var dbCar = db.Cars.Single(c => c.Id == id);
            db.Cars.Remove(dbCar);


            db.SaveChanges();
        }
    }
}
