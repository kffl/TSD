using System;
using System.ComponentModel.DataAnnotations;

namespace YummyCookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }
        [Display(Name = "Time to completion")]
        public int Time { get; set; }
        public string Difficulty { get; set; }
        [Display(Name = "Number of likes")]
        public int NoLikes { get; set; }
        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; }
        public string Process { get; set; }
        [Display(Name = "Tips and tricks")]
        public string TipsAndTricks { get; set; }
    }
}
