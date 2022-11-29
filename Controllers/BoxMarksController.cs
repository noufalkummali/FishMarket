using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishMarketing.Models;
using FishMarketing.Data;
using FishMarketing.ViewModel;
using FishMarketing.Settings;
using Microsoft.AspNetCore.Http;

namespace FishMarketing.Controllers
{
    public class BoxMarksController : Controller
    {
        private readonly IBoxMarks boxMarks;
        public BoxMarksController(IBoxMarks _boxMarks)
        {
            boxMarks = _boxMarks;
        }

        // GET: BoxMarks
        public IActionResult Index()
        {
            //var t = HttpContext.Session.GetInt32("UserLoginId");

            var boxMarkList =  boxMarks.GetBoxMarksList();
            List<BoxMarkVm> boxMarkListVm = new List<BoxMarkVm> ();
            foreach(var bMark in boxMarkList)
            {
                boxMarkListVm.Add(new BoxMarkVm {

                    BoxMarkId= bMark.BoxMarkId,
                    BoxMarkName= bMark.BoxMarkName,
                    Remarks= bMark.Remarks
                });
            }

            
            return View(boxMarkListVm.OrderBy(a=>a.BoxMarkName));
        }

        // GET: BoxMarks/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var boxMark = await _context.BoxMarks
        //        .FirstOrDefaultAsync(m => m.BoxMarkId == id);
        //    if (boxMark == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(boxMark);
        //}

        // GET: BoxMarks/Create
        public IActionResult Create()
        {
            return View(new BoxMarkVm());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BoxMarkVm boxMarkVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BoxMark boxMark = new BoxMark
                    {
                        BoxMarkName = boxMarkVm.BoxMarkName,
                        Remarks = boxMarkVm.Remarks
                    };
                    string result = boxMarks.AddBoxMark(boxMark);
                    if(result== "OK")
                        return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                }
                //_context.Add(boxMark);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(boxMarkVm);
        }

        // GET: BoxMarks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var boxMark = await _context.BoxMarks.FindAsync(id);
            var boxMark = boxMarks.GetBoxMark(id??0);
            if (boxMark == null)
            {
                return NotFound();
            }
            BoxMarkVm boxMarkVm = new BoxMarkVm {
                BoxMarkId = boxMark.BoxMarkId,
                BoxMarkName= boxMark.BoxMarkName,
                Remarks= boxMark.Remarks
            };
            return View(boxMarkVm);
        }

        //// POST: BoxMarks/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BoxMarkVm boxMarkVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BoxMark boxMark = new BoxMark
                    {
                        BoxMarkId= boxMarkVm.BoxMarkId,
                        BoxMarkName = boxMarkVm.BoxMarkName,
                        Remarks = boxMarkVm.Remarks
                    };
                    string result = boxMarks.UpdateBoxMark(boxMark);
                    if (result == "OK")
                        return RedirectToAction(nameof(Index));
                }
                catch
                {

                }
                
            }
            return View(boxMarkVm);
        }

        // GET: BoxMarks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var boxMark = boxMarks.GetBoxMark(id ?? 0);           
            if (boxMark == null)
            {
                return NotFound();
            }
            string result = boxMarks.DeleteBoxMark(boxMark);
            return RedirectToAction(nameof(Index));
        }

        //// POST: BoxMarks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var boxMark = await _context.BoxMarks.FindAsync(id);
        //    _context.BoxMarks.Remove(boxMark);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BoxMarkExists(int id)
        //{
        //    return _context.BoxMarks.Any(e => e.BoxMarkId == id);
        //}
    }
}
