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
    public class MainPagesController : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly ImainPage _mainpage;
        private readonly Iobject _obj;

        public MainPagesController(MiniprojectContext context,ImainPage imainPage,Iobject iobject)
        {
            _context = context;
            _mainpage = imainPage;
            _obj = iobject;
        }

        // GET: api/MainPages
        [HttpGet]
        public async Task<IActionResult> GetMainPages()
        {
            var mainPdata = _mainpage.GetAll();
            var obj = _obj.GetAll();
            var res = new
            {
                topbanner = (from x in mainPdata
                             where x.MainPageType == 31 && x.PageStatus==34
                             select new
                             {
                                 x.ImageUrl,
                                 x.ImageTitle,
                                 x.ImageText,
                                 x.MainId
                                 
                             }),
            DesktopHorizontalScroll = (from x in mainPdata
                                       where x.MainPageType == 32
                                       select new
                                       {
                                           x.ImageUrl,
                                           x.ImageTitle,
                                           x.ImageText,
                                           x.MainId
                                       }),
                DesktopCarFunctionalityCard= (from x in mainPdata
                                              where x.MainPageType == 33
                                              select new
                                              {
                                                  x.ImageUrl,
                                                  x.ImageTitle,
                                                  x.ImageText,
                                                  x.MainId
                                              })

            };
                           
            return Ok(res);
            
        }

        // GET: api/MainPages/5
        [HttpGet("AdminPanelTab")]
        public async Task<ActionResult<MainPage>> GetMainPage()
        {

            try
            {
                var mainpage = (from x in _mainpage.GetAll()
                                select new
                                {
                                    data = (from o in _obj.GetAll()
                                            where o.ObjId==x.MainPageType
                                           select new
                                           {
                                               x.ImageTitle,x.ImageUrl,x.ImageText,x.MainId,
                                               o.Name,x.MainPageType,x.PageStatus,
                                               pstatus=(from u in _obj.GetAll()
                                                  where u.ObjId==x.PageStatus
                                                  select u.Name).FirstOrDefault(),
                                              
                                           }).FirstOrDefault()
                                });
                return Ok(mainpage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/MainPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainPage(int id, [FromBody] AddFrontPagedata addData)
        {
            try
            {
                var data = _mainpage.GetAll();
                var mainPage = data.FirstOrDefault(x => x.MainId == id);
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model Invalid");
                }
                else
                {
                    mainPage.ImageUrl = addData.ImageUrl;
                    mainPage.ImageTitle = addData.ImageTitle;
                    mainPage.ImageText = addData.ImageText;
                    mainPage.MainPageType = addData.MainPageType;
                    mainPage.PageStatus = addData.PageStatus;
                    await _mainpage.Update(mainPage);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/MainPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MainPage>> PostMainPage([FromBody] AddFrontPagedata addData)
        {
            try
            {
                MainPage mainPage = new MainPage();
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model Invalid");
                }
                else
                {
                    mainPage.ImageUrl = addData.ImageUrl;
                    mainPage.ImageTitle = addData.ImageTitle;
                    mainPage.ImageText = addData.ImageText;
                    mainPage.MainPageType = addData.MainPageType;
                    mainPage.PageStatus = addData.PageStatus;
                   await _mainpage.Add(mainPage);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE: api/MainPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainPage(int id)
        {
            try
            {
                var data = _mainpage.GetAll();
                var mainPage = data.FirstOrDefault(x => x.MainId == id);
                if(mainPage == null)
                {
                    return BadRequest("Data not Found");

                }
                else
                {
                    await _mainpage.Delete(mainPage);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MainPageExists(int id)
        {
            return (_context.MainPages?.Any(e => e.MainId == id)).GetValueOrDefault();
        }
    }
}
