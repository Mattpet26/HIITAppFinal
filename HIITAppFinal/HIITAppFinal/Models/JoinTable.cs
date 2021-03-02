using System;
using System.Collections.Generic;
using System.Text;

namespace HIITAppFinal.Models
{
    public class JoinTable
    {
        public int ItemId { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public Item Item { get; set; }
    }
}
