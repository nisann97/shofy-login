using System;
using shofy.Models;
namespace shofy.Services.Interfaces
{
	public interface ISliderService
	{
		Task<List<Slider>> GetAllSlidersAsync();
	}
}

