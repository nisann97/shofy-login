using System;
using shofy.Services.Interfaces;
using shofy.Data;

using shofy.Models;
using Microsoft.EntityFrameworkCore;

namespace shofy.Services
{
	public class SliderService : ISliderService
	{
		private readonly AppDbContext _context;

		public SliderService(AppDbContext context)
		{
			_context = context;
		}

		 public async Task<List<Slider>> GetAllSlidersAsync()
        {
			return await _context.Sliders.ToListAsync();
        }
    }
}

