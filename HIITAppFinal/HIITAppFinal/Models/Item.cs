using System;
using System.Collections.Generic;

namespace HIITAppFinal.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; } //nameof
        public string Description { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}