using System.Collections.Generic;
namespace ui.Models
{
    public class BarberModel
    {
        public List<string> BarberIds { get; set; }
        public List<string> Names { get; set; }
        public string SelectedBarber { get; set; }
        public string CustomerId { get; set; }
    }
}