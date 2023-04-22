using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.ViewModels
{
    public class CheckOptionVM
    {
        //Used fro a Checkbox
        public int ID { get; set; }
        public string DisplayText { get; set; }
        public bool Assigned { get; set; }
    }
}
