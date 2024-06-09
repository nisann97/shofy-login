using System;
using System.Collections.Generic;
using System.Linq;
using shofy.Services.Interfaces;
using shofy.Services;
using System.Threading.Tasks;
using shofy.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;
using shofy.Data;
using shofy.Models;
using shofy.ViewModels;
using Microsoft.EntityFrameworkCore;
using shofy.Areas.Admin.Helpers.Extensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shofy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
    

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            List<SliderVM> result = sliders.Select(m => new SliderVM { Id = m.Id, Title = m.Title, Description = m.Description, Image = m.Image}).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            foreach (var item in request.Image)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "File must be only image format");
                }

                if (!item.CheckFileSize(200))
                {
                    ModelState.AddModelError("Image", "Image size must be max 200 kb");
                }

            }
            foreach (var item in request.Image)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                string path = Path.Combine(_env.WebRootPath, "img", fileName);

                await item.SaveFileToLocalAsync(path);
                await _context.Sliders.AddAsync(new Slider { Image = fileName });
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }


        //[HttpGet]

        //public async Task<IActionResult> Detail(int? id)
        //{
        //    if (id == null) return BadRequest();
        //    Slider slider = await _context.Sliders.Where(m => m.Id == id).FirstOrDefaultAsync();
        //    if (slider == null) return NotFound();

        //    return View(new SliderDetailVM { Image = slider.Image });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return BadRequest();

        //    Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

        //    if (slider == null) return NotFound();

        //    string path = Path.Combine(_env.WebRootPath, "img", slider.Image);
        //    path.DeleteFileFromLocal();
        //    _context.Sliders.Remove(slider);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}


        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null) return BadRequest();

        //    Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
        //    if (slider == null) return NotFound();
        //    return View(new SliderEditVM { Image = slider.Image });
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        //{
        //    if (id == null) return BadRequest();

        //    var slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
        //    if (slider == null) return NotFound();

        //    if (request.NewImage is null) return RedirectToAction(nameof(Index));

        //    if (!request.NewImage.CheckFileType("image/"))
        //    {
        //        ModelState.AddModelError("NewImage", "File must be only image format");
        //        request.Image = slider.Image;
        //        return View(request);
        //    }

        //    if (!request.NewImage.CheckFileSize(200))
        //    {
        //        ModelState.AddModelError("NewImage", "Image size must be max 200 kb");
        //        request.Image = slider.Image;
        //        return View(request);
        //    }



        //    string oldPath = Path.Combine(_env.WebRootPath, "img", slider.Image);
        //    if (System.IO.File.Exists(oldPath))
        //    {
        //        System.IO.File.Delete(oldPath);
        //    }

        //    string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

        //    string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

        //    await request.NewImage.SaveFileToLocalAsync(newPath);
        //    slider.Image = fileName;

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}



    }
}



