using System;
using System.ComponentModel.DataAnnotations;

namespace YummyCookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [StringLength(120, MinimumLength = 5)]
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }
        [Range(5, 180)]
        [Display(Name = "Time to completion (mins)")]
        public int Time { get; set; }
        public string Difficulty { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "We don't h8 here, only positive values allowed.")]
        [Display(Name = "Number of likes")]
        public int NoLikes { get; set; }
        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; }
        public string Process { get; set; }
        [Display(Name = "Tips and tricks")]
        public string TipsAndTricks { get; set; }
    }
}
