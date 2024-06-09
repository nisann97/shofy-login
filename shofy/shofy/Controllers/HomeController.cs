using System.Diagnostics;
using shofy.Models;
using Microsoft.AspNetCore.Mvc;
using shofy.Data;
using Microsoft.EntityFrameworkCore;
using shofy.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using shofy.Services.Interfaces;

namespace shofy.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly ISliderService _sliderService;
    public HomeController(AppDbContext context, ISliderService sliderService)
    {
        _context = context;
        _sliderService = sliderService;
    }
   

    public async Task<IActionResult> Index()
    {

        List<Slider> sliders = await _sliderService.GetAllSlidersAsync();
        List<SliderVM> sliderVM = new(); 

        foreach (var item in sliders)
        {
            sliderVM.Add(new()
            {
                Title = item.Title,
                Description = item.Description,
                Image = item.Image
            }
            );
        }

        return View(sliderVM);
    }



}

