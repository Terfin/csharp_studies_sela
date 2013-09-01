using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonRoom
    {
        [Key]
        public int Id { get; set; }
        public RoomTypes RoomType { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public bool IsOccupied { get; set; }
        public virtual List<CommonOrder> Order { get; set; }
    }
}
