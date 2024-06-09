using System;
using System.ComponentModel.DataAnnotations;
namespace shofy.ViewModels.Slider
{
	public class SliderCreateVM
	{
        
        [Required]
        public List<IFormFile> Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

