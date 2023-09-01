using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDrivecontroller : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly Icar _car;
        private readonly Iuser _user;
        private readonly Itestdrive _testdrive;
        private readonly Iimage _img;
        private readonly Iobject _obj;

        private enum status
        {
            Interested = 15,
            Completed,
            Cancelled

        }
        public TestDrivecontroller(MiniprojectContext context, Icar icar,Iuser iuser, Itestdrive itestdrive,Iimage iimage,Iobject iobject)
        {
            
            _context = context;
            _car =  icar;
            _user = iuser;
            _testdrive = itestdrive;
            _img = iimage;
            _obj = iobject;
        }

        [HttpPost("interestedTestdrive")]
        public async Task<IActionResult> Testdriveinterest([FromBody] interestedtestdrivedto td)
        {
            try
            {

            var user =await _user.GetById(td.Userid);
            var car =await _car.GetById(td.carid);
            var testduserid =  _testdrive.GetAll();
            var z1 = testduserid.Any(x => x.Userid == td.Userid && x.Carid == td.carid);
            //var z2 = testduserid.Any(x => x.Carid == td.carid);

            Testd testd = new Testd();
            if(!(z1 )) 
            {
            testd.Userid = user.Userid;
            testd.CreatedBy = user.Userid;
            testd.Carid = car.Carid;
            testd.CreatedDate = DateTime.Now;
            testd.TestStatus = (int)status.Interested;
           await _testdrive.Add(testd);
            return Ok(testd);
            }
            else
            {
                var t = testduserid.FirstOrDefault(x => x.Carid == td.carid && x.Userid == td.Userid);
                return Ok(t);

            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
         


        }


        [HttpGet("getinterestedTD/{id}")]
        public async Task<IActionResult> Getintdata(int id)
        {
            try
            {

            var car = _car.GetAll();
            var testd = _testdrive.GetAll();
            var user = _user.GetAll();
            var res = from t in testd
                      where t.Userid==id && t.TestStatus== (int)status.Interested
                      select new
                      {
                          t.Testdid,
                          t.Userid,
                          cars = (from x in car
                                 where x.Carid == t.Carid
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
                          images = (from i in _img.GetAll()
                                    join v in car on i.Carid equals v.Carid
                                    where x.Carid == v.Carid
                                    select new
                                    {
                                        i.Leftside,
                                        i.Rightside,
                                        i.Backview,
                                        i.Frontview
                                    }).FirstOrDefault(),
                                     fuel = (from f in _obj.GetAll()
                                             where f.ObjId ==x.Fueltype
                                             select f.Name).FirstOrDefault(),
                                 }).FirstOrDefault(),
                          user = (from u in user
                                  where u.Userid == t.Userid
                                  select u.Userid).FirstOrDefault()
                                 



                      };

            return Ok(res);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetcompletedTD/{id}")]
        public async Task<IActionResult> GetcompletedTD(int id)
        {
            try
            {

            var car = _car.GetAll();
            var testd = _testdrive.GetAll();
            var user = _user.GetAll();
            var res = from t in testd
                      where t.Userid == id && t.TestStatus == (int)status.Completed
                      select new
                      {
                          t.Testdid,
                          t.Date,t.Location,
                          t.Userid,
                          cars = (from x in car
                                  where x.Carid == t.Carid
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
                                      images = (from i in _img.GetAll()
                                                join v in car on i.Carid equals v.Carid
                                                where x.Carid == v.Carid
                                                select new
                                                {
                                                    i.Leftside,
                                                    i.Rightside,
                                                    i.Backview,
                                                    i.Frontview
                                                }).FirstOrDefault(),
                                      fuel = (from f in _obj.GetAll()
                                              where f.ObjId == x.Fueltype
                                              select f.Name).FirstOrDefault(),
                                  }).FirstOrDefault(),
                          user = (from u in user
                                  where u.Userid == t.Userid
                                  select u.Userid).FirstOrDefault()




                      };

            return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("ConfirmedTd/{id}")]

        public async Task<IActionResult> TDconfirmation([FromBody] ConfirmedTestDrive confval,int id)
        {
            try
            {

            var testr = await _testdrive.GetById(id);
                if(testr == null)
                {
                    return BadRequest("ride not found");
                }
                testr.Date = confval.Date;
                testr.Location= confval.Location;
                testr.ModifiedDate = confval.ModifiedDate;
                testr.TestStatus = 16;
                testr.ModifiedBy = confval.ModifiedBy;
              await  _testdrive.Update(testr);

                return Ok(testr);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
         
            
        }

        [HttpGet("GETIME/{dat}/{id}")]
        public async Task<IActionResult> time(DateTime dat,int id)
        {
            try
            {

            Console.WriteLine(dat);
            var test = _testdrive.GetAll();

            var res = (from t in test
                       where t.TestStatus == 16 && t.Carid==id && t.Date.Value.Date == dat.Date && t.Date.Value.Month==dat.Month && t.Date.Value.Year == dat.Year
                       select t.Date.Value.Hour).ToList();
            return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
