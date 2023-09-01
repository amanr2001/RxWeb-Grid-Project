using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly Icity _city;
        private readonly Icar _cars;
        private readonly Iobject _object;
        private readonly IobjType _objtype;
        private readonly Iimage _img;
        private readonly Irole _role;
        private readonly Iwishlist _wishlist;
        private readonly Iorder _order;
        private readonly Iorderitem _orderitem;
        private readonly Iuser _user;
        private readonly Ioutlet _outlet;

        public WishlistsController(MiniprojectContext context, Icity city, Icar icar, Iobject iobject, IobjType iobjType, Iimage iimage,
            Iuser iuser, Ioutlet ioutlet, Iorder order, Iorderitem iorderitem, Irole irole,Iwishlist iwishlist)
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
            _wishlist= iwishlist;
        }

        // GET: api/Wishlists
        //[HttpGet]
        //public async Task<IActionResult> GetWishlists()
        //{

        //}

        [HttpPost("wishlist")]

        public async Task<IActionResult> wishlist([FromBody] WishListDTO wishListval)
        {
            var wishL = _context.Wishlists.FirstOrDefault(x=>x.Carid== wishListval.Carid && x.Userid== wishListval.Userid);
            if (wishL == null)
            {
                Wishlist wishlist = new Wishlist();
                wishlist.Carid = wishListval.Carid;
                wishlist.Userid = wishListval.Userid;
                wishlist.Wishliststatus = true;
               await _wishlist.Add(wishlist);
                return Ok(wishlist);   
            }
            else if (wishL != null)
            {
                if(wishL.Wishliststatus == true)
                {

                wishL.Wishliststatus = false;
                await _context.SaveChangesAsync();
                return Ok(wishL);
                }
                else
                {
                    wishL.Wishliststatus = true;
                    await _context.SaveChangesAsync();
                    return Ok(wishL);

                }
            }
            else
            {
                return BadRequest("Already in Wishlist");
            }
        }


        [HttpGet("UserWishlist/{id}")]
        public async Task<IActionResult> getuserswishlist(int id)
        {
            try
            {
                var cars = _cars.GetAll();
                var city = _city.GetAll();
                var obj = _object.GetAll();
                var outlet = _outlet.GetAll();
                var wishlist = _wishlist.GetAll();
                var objtype = _objtype.GetAll();
                var res = (from w in wishlist
                           where w.Wishliststatus == true && w.Userid == id
                           select new
                           {
                               car = (from x in cars
                                      where x.Status == 7 && x.Isapproved == 28 && x.Carid == w.Carid
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
                                                 where l.Outletid == x.Outletid
                                                 select l.Outletlocation).FirstOrDefault(),


                                      }).FirstOrDefault()
                           }) ;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        private bool WishlistExists(int id)
        {
            return (_context.Wishlists?.Any(e => e.Wishlistid == id)).GetValueOrDefault();
        }
    }
}
