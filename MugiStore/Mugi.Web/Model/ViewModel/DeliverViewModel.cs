using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class DeliverViewModel
    {
        public OrderedViewModel Order { get; set; }
        public List<StaffInDeliverViewModel> Staffs { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int StaffId { get; set; }
    }

    public class StaffInDeliverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
