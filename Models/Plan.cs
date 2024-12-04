using System;
using System.Collections.Generic;

namespace IS_nal.Models
{
    public class Plan
    {
        public int PlanID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? TrainerID { get; set; }
    public  Trainer? Trainer { get; set; }
    }
}