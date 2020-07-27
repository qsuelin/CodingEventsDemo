using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddTagViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be betwwen 3 and 20 charactres long")]
        public string Name { get; set; }

        public AddTagViewModel()
        {
        }
        
    }
}
