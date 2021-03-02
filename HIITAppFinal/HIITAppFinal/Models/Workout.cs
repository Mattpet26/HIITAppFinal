using System;
using System.Collections.Generic;
using System.Text;

namespace HIITAppFinal.Models
{
    public class Workout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sets { get; set; }
        public int Timer { get; set; }
        public int RestTime { get; set; }
    }
}
