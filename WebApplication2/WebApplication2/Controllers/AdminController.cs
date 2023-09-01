using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using System.Collections;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly Icity _city;
        private readonly Icar _cars;
        private readonly Iobject _object;
        private readonly IobjType _objtype;
        private readonly Iimage _img;
        private readonly Iuser _user;
        private readonly Ioutlet _outlet;
        private readonly Iorder _order;
        private readonly Iorderitem _orderitem;
        private readonly Irole _role;

        // GET: api/<AdminController>
        public AdminController(MiniprojectContext context, Icity city, Icar icar, Iobject iobject, IobjType iobjType, Iimage iimage,
            Iuser iuser, Ioutlet ioutlet, Iorder order, Iorderitem iorderitem, Irole irole)
        {
            _context = context;
            _city = city;
            _cars = icar;
            _object = iobject;
            _objtype = iobjType;
            _img = iimage;
            _user = iuser;
            _outlet = ioutlet;
            _order = order;
            _orderitem = iorderitem;
            _role = irole;
        }
        [HttpPost]
        public IActionResult getselldata([FromBody] demoDto demo)
        {
            try
            {
                var cars = _cars.GetAll();
                var user = _user.GetAll();
                var obj = _object.GetAll();
                var outlets = _outlet.GetAll();

                var query = from x in cars
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
                                user = (from u in user
                                        where u.Userid == x.Userid
                                        select new
                                        {
                                            u.Username,
                                            u.Useremail
                                        }).FirstOrDefault(),
                                approval = (from a in obj
                                            where a.ObjId == x.Isapproved
                                            select a.Name).FirstOrDefault(),
                            };

                if (!string.IsNullOrEmpty(demo.val))
                {
                    query = query.Where(x => x.Carbrand.ToLower().Contains(demo.val.ToLower()) || x.Carmodel.ToLower().Contains(demo.val.ToLower()) || x.Price.ToString().ToLower().Contains(demo.val.ToLower())); ;
                }

                switch (demo.sortby)
                {
                    case "carbrand":
                        query = query.OrderBy(x => x.Carbrand);
                        break;
                    case "carmodel":
                        query=query.OrderBy(x => x.Carmodel);
                        break;
                    default:
                        query = query.OrderBy(x => x.Carid);
                        break;
                }

                query= demo.orderby ? query:query.Reverse();
                
                
                var result = query
                    .Skip((demo.pagenum - 1) * demo.pagesize)
                    .Take(demo.pagesize)
                    .ToList();

                return Ok(new { result ,len=query.Count()});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("outlets")]
        public IActionResult outlets()
        {
            try
            {

            var outlets = _outlet.GetAll();

            var outlet = (from a in outlets
                          select a.Outletlocation);
            return Ok(outlet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   
     
        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AdminApprovalDTO adminApproval)
        {
            try
            {

            var cars = _cars.GetAll();
            //var cardata = _context.Cars.FirstOrDefault(x=> x.Carid == id);  
            var cardata = cars.FirstOrDefault(x => x.Carid == id);
            cardata.Sellerprice= adminApproval.Sellerprice;
            cardata.Isapproved = 28;
            cardata.Outletid = adminApproval.outlet;
            _context.SaveChanges();
            }
           catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delcardata(int id)
        {
            try
            {

            var cars = _cars.GetAll();
            var car = cars.FirstOrDefault(x => x.Carid == id);
            if (car == null)
            {
                return BadRequest("CAR NOT FOUND");
            }
                var img = _img.GetAll();
            var images = img.FirstOrDefault(x => x.Carid == car.Carid);
            if (images != null)
            {
                _context.Images.Remove(images);
                _context.SaveChanges();

            }
            
            var testcar = _context.Testds.FirstOrDefault(x => x.Carid == car.Carid);
            if (testcar != null)
            {
                _context.Testds.Remove(testcar);
                _context.SaveChanges();


            }

                _cars.Delete(car);
            _context.SaveChanges();
            return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("Denyreq/{id}")]
        public IActionResult Denycarreq(int id)
        {
            var c = _cars.GetAll();
            var car = c.FirstOrDefault(x=>x.Carid == id);
            if (car == null)
            {
                return BadRequest("car not found");
            }
            else
            {
                car.Isapproved = 29;
                _context.SaveChanges();
                return Ok();
            }
        }


        [HttpGet("getusers")]
        public async Task<IActionResult> Getusers() 
        {
            try
            {

            var user = _user.GetAll();

            var role = _role.GetAll();
            var res = (from u in user
                       where u.Roleid == 2
                       select new
                       {
                           u.Userid,
                           u.Username,
                           u.Useremail,
                           role = (from x in role
                                   where x.Role1 == "User"
                                   select x.Role1).FirstOrDefault()
                       }) ;
            return Ok(res);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orderdata")]
        public async Task<IActionResult> getorderdata()
        {
            try
            {

            var order = _order.GetAll();
            var orditems = _orderitem.GetAll();
            var obj = _object.GetAll();
            var city = _city.GetAll();
            var car = _cars.GetAll();

            var res = (from o in order
                       select new
                       {
                           o.Orderid,
                           o.Userid,
                           o.Orderitems.Count,
                           orderitem = (from item in orditems
                                        where item.Orderid == o.Orderid
                                        select new
                                        {
                                            item.Orderid,
                                            cars = (from x in car
                                                    where x.Carid == item.Carid
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
                                                      
                                                        city = (from c in city
                                                                where c.Cityid == x.Cityid
                                                                select c.Cityname).Distinct().FirstOrDefault(),
                                                    }).FirstOrDefault()
                                        })
                       }) ;
            return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = _city.GetAll().ToList();
                var res = (from c in cities
                           select new
                           {
                               c.Cityid,
                               c.Cityname,
                           });
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Addoutlets")]
        public async Task<IActionResult> Addoutlets([FromBody] AddOutlets newoutlet)
        {
            try
            {
                Outlet outlet = new Outlet();
                outlet.Cityid = newoutlet.Cityid;
                outlet.Outletlocation = newoutlet.Outletlocation;
               await _outlet.Add(outlet);
                return Ok(outlet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("addcitites")]
        public async Task<IActionResult> addcities([FromBody] addcityDto city)
        {
            try
            {
                City city1 = new City();
                city1.Cityname = city.Cityname;
               await _city.Add(city1);
                return Ok(city1);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}
