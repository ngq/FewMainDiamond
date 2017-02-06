using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.ViewModel
{
    public class SKUViewModel
    {
        public int Id { get; set; }
        public string SKUNo { get; set; }
        public decimal Weight { get; set; }
        public string Shape { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Cut { get; set; }
        public string Polishing { get; set; }
        public string Symmetry { get; set; }
        public string Fluorescence { get; set; }
        public decimal Price { get; set; }
        public string Coffee { get; set; }
        public string Milk { get; set; }
    }
}
