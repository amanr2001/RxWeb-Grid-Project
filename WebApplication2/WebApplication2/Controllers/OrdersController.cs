using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
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

        public OrdersController(MiniprojectContext context, Icity city, Icar icar, Iobject iobject, IobjType iobjType, Iimage iimage, Iuser iuser, Ioutlet ioutlet,Iorder order,Iorderitem iorderitem)
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
        }


        //[HttpGet("get")]
    


    

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ordercar")]
        public async Task<IActionResult> bookcar([FromBody] bookcarDTO bookcarDTO)
        {
            try
            {
                var orders = _order.GetAll();
                var car = _cars.GetAll();
            var ord = orders.FirstOrDefault(x=>x.Userid==bookcarDTO.Userid);
            var carexist = _context.Orderitems.FirstOrDefault(x => x.Carid == bookcarDTO.Carid);
            if(ord == null && carexist==null)
            {

            Order order = new Order();
            order.Orderstatus = 10;
            order.CreatedBy = bookcarDTO.CreatedBy;
            order.ModifiedBy = bookcarDTO.ModifiedBy;   
            order.Userid = bookcarDTO.Userid;
            order.CreatedDate = DateTime.Now;
            order.ModifiedDate = DateTime.Now;
            await _order.Add(order);
            
            Orderitem item = new Orderitem();   
                item.Orderid=order.Orderid;
                item.Carid= bookcarDTO.Carid;
                await _orderitem.Add(item);
                return Ok(item.Orderitem1);
            }
            else if(carexist==null && ord!=null)
            {
                //var orditems = _context.Orderitems.FirstOrDefault(x => x.Orderid == ord.Orderid);
                Orderitem i = new Orderitem();
                i.Orderid = ord.Orderid;
                i.Carid= bookcarDTO.Carid;
                await _orderitem.Add(i);
                return Ok(i.Orderitem1);
                
            }
            else
            {
                return Ok(carexist.Orderitem1);
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            


        }

        // DELETE: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> getbookedcars(int id)
        {
            try
            {

            var order = _order.GetAll();
            var orditems = _orderitem.GetAll();
            var obj = _object.GetAll();
            var city = _city.GetAll();
            var car = _cars.GetAll();

            var res = (from o in order
                       where o.Userid == id
                       select new
                       {
                           
                           orderitem = (from item in orditems
                                        where item.Orderid == o.Orderid
                                        select new
                                        {
                                            
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
                                                        images = (from t in _img.GetAll()
                                                                  join v in car on t.Carid equals v.Carid
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
                                                    })
                                        })
                       }).FirstOrDefault();
            return Ok(res);
            }
            catch   (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("deletebookedcars/{id}")]
        public IActionResult delcar(int id)
        {
            try
            {

            var orditem = _orderitem.GetAll();
            var o =orditem.FirstOrDefault(x => x.Carid == id);
           
            var z = _context.Orders.FirstOrDefault(x => x.Orderid == o.Orderid);
            if (z==null )
            {
                _context.Orders.Remove(z);
                _context.SaveChanges();

            }
            _context.Orderitems.Remove(o);
            _context.SaveChanges();
            return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Orderid == id)).GetValueOrDefault();
        }
    }
}
