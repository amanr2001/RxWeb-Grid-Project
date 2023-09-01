using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using WebApplication2.Interfaces;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjController : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly Icity _city;
        private readonly Icar _cars;
        private readonly Iobject _object;
        private readonly IobjType _objtype;
        private readonly Iimage _img;
        private readonly Iuser _user;
        private readonly Ioutlet _outlet;

        public ObjController(MiniprojectContext context, Icity city, Icar icar, Iobject iobject, IobjType iobjType, Iimage iimage, Iuser iuser, Ioutlet ioutlet)
        {
            _context = context;
            _city = city;
            _cars = icar;
            _object = iobject;
            _objtype = iobjType;
            _img = iimage;
            _user = iuser;
            _outlet = ioutlet;

        }
        // GET: api/<ObjController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var obj = _object.GetAll();
            var petrol = (from p in obj
                          where p.Typeid == 2
                          select new
                          {
                              p.Name,
                              p.ObjId
                          });
            var owner = (from o in obj
                          where o.Typeid == 3
                         select   new
                         {
                             o.Name,
                             o.ObjId
                         });

            var seats = (from s in obj
                          where s.Typeid == 4
                         select   new
                         {
                             s.Name,
                             s.ObjId
                         });

            var km = (from k in obj
                      where k.Typeid ==11
                      select   new
                      {
                          k.Name,
                          k.ObjId
                      });
            var modelyear = (from m in obj
                      where m.Typeid == 12
                      select new
                      {
                          m.Name,
                          m.ObjId
                      });
            var cities = (from city in _city.GetAll()
                          select new
                          {
                              city.Cityid,
                              city.Cityname
                          }
                          );

            var res = new
            {
                petrol = petrol,
                owner = owner,
                seats = seats,
                km = km,
                modelyear = modelyear,
                city = cities,
            };
            return Ok(res);

        }




    }
}
