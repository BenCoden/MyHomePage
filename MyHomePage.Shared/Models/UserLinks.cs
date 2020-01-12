using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHomePage.Models
{
    public class UserLinks
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Text is required")]
        public string Text { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ImageUrl is required")]
        public string ImageUrl { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Url is required")]
        public string Url { get; set; }

        public bool InvertImageColors { get; set; }
        public string BackgroundColor { get; set; }
    }
}