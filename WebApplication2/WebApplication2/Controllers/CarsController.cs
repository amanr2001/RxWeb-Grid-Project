using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;
using Image = WebApplication2.Models.Image;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly Icity _city;
        private readonly Icar _cars;
        private readonly Iobject _object;
        private readonly IobjType _objtype;
        private readonly Iimage _img;
        private readonly Iuser _user;
        private readonly Ioutlet _outlet;
        private readonly Iwishlist _wishlist;

        public CarsController(MiniprojectContext context, Icity city, Icar icar, Iobject iobject, IobjType iobjType, Iimage iimage, Iuser iuser,Ioutlet ioutlet, Iwishlist iwishlist)
        {
            _context = context;
            _city = city;
            _cars = icar;
            _object = iobject;
            _objtype = iobjType;
            _img = iimage;
            _user=iuser;
            _outlet = ioutlet;
            _wishlist = iwishlist;
        }

        // GET: api/Cars
        [HttpGet]
        public IActionResult GetCars()
        {
            var carsdata = from x in _context.Cities
                           group x by x.Cityid into g
                           select new
                           {
                               type = g.Key,
                               xs = from a in g
                                    select new
                                    {
                                        a.Cars
                                    }


                           };
            return Ok(carsdata);
        }

        // GET: api/Cars/5
        [HttpPost("p")]
        public IActionResult GetCar(string name)
        {
            //var data = from x in _context.Cars 
            //           where x.Cartype==name
            //           select x;
            //   return Ok(data);


            List<string> list = new List<string>();
            List<Car> cars = new List<Car>();
            list.Add(name);
            IQueryable<Car> filterdata = null;
            foreach (var car in list)
            {
                filterdata = from x in _context.Cars
                             where x.Carmodel == car || x.Carbrand == car 
                             || x.Fueltype.ToString() == car
                             select x;
                foreach (var i in filterdata)
                {
                    cars.Add(i);
                }
            }
            return Ok(cars);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCar(int id, Car car)
        //{
        //    if (id != car.Carid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(car).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Car>> PostCar(Car car)
        //{
        //    if (_context.Cars == null)
        //    {
        //        return Problem("Entity set 'MiniprojectContext.Cars'  is null.");
        //    }
        //    _context.Cars.Add(car);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCar", new { id = car.Carid }, car);
        //}

        // DELETE: api/Cars/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCar(int id)
        //{
        //    if (_context.Cars == null)
        //    {
        //        return NotFound();
        //    }
        //    var car = await _context.Cars.FindAsync(id);
        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cars.Remove(car);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Carid == id)).GetValueOrDefault();
        }

        [HttpPost("insertdata/{id}")]

        public async Task<IActionResult> insertdata([FromBody] sellcar sellcar,int id)
        {
            try
            {

            Car car = new Car();
            car.Carbrand = sellcar.Carbrand;
            car.Carmodel = sellcar.Carmodel;
            car.Cartype = sellcar.Cartype;
            car.Price = sellcar.Price;
            car.Modelyear = sellcar.Modelyear;
           
            car.Fueltype = sellcar.Fueltype;
            car.Owner = sellcar.Owner;
            car.Seats = sellcar.Seats;
            car.Cityid = sellcar.Cityid;
            car.Kmdriven = sellcar.Kmdriven;
            //car.Sellerprice = sellcar.Sellerprice;
            car.CreatedDate = DateTime.Now;
            car.ModifiedDate = DateTime.Now;
            car.Status = 7;
            car.Isapproved = 30;
            car.Userid = id;
            car.CreatedBy = id;
            car.ModifiedBy = 1;
            //_context.Cars.Add(car);
            //_context.SaveChanges();

            await _cars.Add(car);

            Image image = new Image();
            image.Frontview = sellcar.Frontview;
            image.Backview = sellcar.Backview;
            image.Rightside = sellcar.Rightside;
            image.Leftside = sellcar.Leftside;
            image.Carid = car.Carid;

         await   _img.Add(image);
            //_context.Images.Add(image);
            //_context.SaveChanges();
            return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getallcars")]

        public IActionResult getallcars()
        {
            try
            {

            var cars = _cars.GetAll();
            var city = _city.GetAll();
            var obj = _object.GetAll();     
            var outlet = _outlet.GetAll();
            var wishlist = _wishlist.GetAll();
            var objtype = _objtype.GetAll();
            var result = (from x in cars
                          where x.Status==7 && x.Isapproved == 28
                         select new
                         {
                             x.Carid,
                             x.Carbrand,
                             x.Carmodel,
                             x.Price,
                            
                             x.Cartype,
                             x.Modelyear.Value.Year,
                             x.Kmdriven,
                             x.Sellerprice,
                             x.CreatedDate,
                             x.ModifiedDate,

                             fuel = (from f in obj
                                     where f.ObjId == x.Fueltype
                                     select f.Name).FirstOrDefault(),

                             //(from z in cars
                             // join o in obc on z.Fueltype equals o.ObjId

                             // select new
                             // {
                             //     o.Name
                             // }),

                             images = (from t in _img.GetAll()
                                      join v in cars on t.Carid equals v.Carid
                                      where x.Carid == v.Carid
                                      select new
                                      {
                                          t.Leftside,
                                          t.Rightside,
                                          t.Backview,
                                          t.Frontview
                                      }).FirstOrDefault(),
                             owner = (from z in obj
                                      where z.ObjId == x.Owner
                                      select z.Name).FirstOrDefault(),
                             seats = (from t in obj
                                      where t.ObjId == x.Seats
                                      select t.Name).FirstOrDefault(),
                             city = (from c in city
                                     where c.Cityid == x.Cityid
                                     select c.Cityname).Distinct().FirstOrDefault(),
                             status = (from u in obj
                                       where u.ObjId == x.Status
                                  select u.Name).FirstOrDefault(),
                                  loc = (from l in outlet
                                         where l.Outletid==x.Outletid
                                         select l.Outletlocation).FirstOrDefault(),
                            wishl = (from w in wishlist
                                     where w.Carid==x.Carid
                                     select new
                                     {
                                         w.Userid, w.Carid,w.Wishliststatus
                                     }).FirstOrDefault(),

                         });

                     

            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deleteRequest/{id}")]
        public IActionResult DelRequest(int id)
        {
            try
            {

            var cars = _cars.GetAll();
            var car = cars.FirstOrDefault(x=>x.Carid == id);
            if(car == null)
            {
                return BadRequest("CAR NOT FOUND");

            }
            else if (car.Isapproved != 28)
                {


            var img = _img.GetAll();
            var images = img.FirstOrDefault(x => x.Carid == car.Carid);

            if(images != null)
            {
                _context.Images.Remove(images);
                _context.SaveChanges();

            }
            var testcar = _context.Testds.FirstOrDefault(x => x.Carid == car.Carid);
            if(testcar != null)
            {
                _context.Testds.Remove(testcar);
                _context.SaveChanges();


            }
              
            _cars.Delete(car);
            _context.SaveChanges();
            return Ok();
                
                }
                else
                {
                    return BadRequest("Car is already sold");
                }
            }
            catch(Exception ex) { 
            return BadRequest(ex.Message);
            }
        }


        [HttpGet("similarcars/{carbrand}")]
        public async Task<IActionResult> similarcars(string carbrand)
        {
            try
            {

            var cars = _cars.GetAll();
            var city = _city.GetAll();
            var obj = _object.GetAll();
            var outlet = _outlet.GetAll();
            var objtype = _objtype.GetAll();
            var result = (from x in cars
                          where x.Carbrand == carbrand && x.Status==7
                          select new
                          {
                              x.Carid,
                              x.Carbrand,
                              x.Carmodel,
                              x.Price,
                              x.Cartype,
                              x.Modelyear.Value.Year,
                              x.Kmdriven,
                              x.Sellerprice,
                              x.CreatedDate,
                              x.ModifiedDate,

                              fuel = (from f in obj
                                      where f.ObjId == x.Fueltype
                                      select f.Name).FirstOrDefault(),


                              images = (from t in _img.GetAll()
                                        join v in cars on t.Carid equals v.Carid
                                        where x.Carid == v.Carid
                                        select new
                                        {
                                            t.Leftside,
                                            t.Rightside,
                                            t.Backview,
                                            t.Frontview
                                        }).FirstOrDefault(),


                              city = (from c in city
                                      where c.Cityid == x.Cityid
                                      select c.Cityname).Distinct().FirstOrDefault(),

                              loc = (from l in outlet
                                     where l.Outletid == x.Outletid
                                     select l.Outletlocation).FirstOrDefault()
                          });



            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("sellrequests/{id}")]
        public IActionResult sellreq(int id)
        {
            try
            {

            var cars = _cars.GetAll();
            var user = _user.GetAll();
                var obj = _object.GetAll();
                var result = (from x in cars
                              where x.Userid == id && x.Status == 7
                              select new
                              {
                                  x.Carid,
                                  x.Carbrand,
                                  x.Carmodel,
                                  x.Price,

                                  x.Cartype,
                                  x.Modelyear.Value.Year,
                                  x.Kmdriven,
                                  x.Sellerprice,
                                  x.CreatedDate.Value.Date,
                                  x.ModifiedDate,
                                  x.Userid,
                                  stat = (from o in obj
                                          where o.ObjId == x.Isapproved
                                          select new
                                          {
                                              o.Name
                                          }).FirstOrDefault()
                              }); ;
            return Ok(result);
            }
            catch(Exception ex)
            {
                    return BadRequest(ex.Message);
            }
        }


        [HttpGet("carmodels")]
        public IActionResult carmodels()
        {
            try
            {

            var cars = _cars.GetAll();
            var fuel = _object.GetAll();
            var ans = (from x in cars

                       select x.Carbrand).Distinct();
                    

            return Ok(ans);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("carmodelsdata")]
        public IActionResult carmodeldata()
        {
            try
            {

            var cars = _cars.GetAll();
            var fuel = _object.GetAll();
            var ans = (from x in cars

                       select new
                       {
                           
                           x.Carbrand
                       }).Distinct();
                    

            return Ok(ans);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        [HttpGet("carmodelsdataa/{val}")]
        [EnableCors("AllowOrigin")]
        public IActionResult carmodeldataa(string val)
        {
            try
            {

            var cars = _cars.GetAll();
            var fuel = _object.GetAll();
                //var ans = (from x in cars

                //           select new
                //           {

                //               x.Carbrand
                //           }).Distinct();
                var ans = (from x in cars
                           where x.Carbrand.ToLower().Contains(val.ToLower()) 
                           select new
                           {
                               x.Carbrand
                           }).Distinct();
                    

            return Ok(ans);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
