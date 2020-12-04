using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ManufacturerDTO
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public override string ToString() => $"{ManufacturerName}";
    }
}
