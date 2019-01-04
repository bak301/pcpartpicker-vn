using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcPartPickerBackendAPI.Models;

namespace PcPartPickerBackendAPI.ViewModels
{
    public class PartViewModel : Part
    {
        // Part
        public int Price { get; set; }
        public string Merchant { get; set; }
        public string Url { get; set; }
        public string Images { get; set; }
    }
}
