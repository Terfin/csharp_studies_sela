using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [ForeignKey("Id")]
        [Required]
        public virtual CommonRoom Room { get; set; }
        [ForeignKey("Id")]
        [Required]
        public virtual CommonPerson Guest { get; set; }
        [ForeignKey("Id")]
        [Required]
        public virtual CommonEmployee Employee { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
